using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerBasicJump : State, IPressTheScreenToTransition
{
    [Header("[ Components ]")]
    [SerializeField] private PlayerPhysic physic;
    [SerializeField] private Animator animator;

    [Header("[ Jump ]")]
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpTime;
    
    private PlayerFSM fsm;
    private readonly int isJumping = Animator.StringToHash("isJumping");

    public override void Enter(PlayerFSM fsm)
    {
        this.fsm = fsm;
        animator.SetBool(isJumping, true);

        if (!Player.Instance.isCurrentlyBouncedOffTheWall || !Player.Instance.isCurrentlySlippingTheWall)
        {
            Jump();
        } 
    }

    public override void Execute(PlayerFSM fsm)
    {
        switch (Player.Instance.currnetState)
        {
            case EPlayerState.SITCK_TO_WALL:
                fsm.ChangeState(EPlayerState.SITCK_TO_WALL);
                break;
            case EPlayerState.ON_GROUND:
                fsm.ChangeState(EPlayerState.ON_GROUND);
                break;
            case EPlayerState.DEATH:
                fsm.ChangeState(EPlayerState.DEATH);
                break;
            case EPlayerState.POSTURE_CORRECTION:
                fsm.ChangeState(EPlayerState.POSTURE_CORRECTION);
                break;
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
        animator.SetBool(isJumping, false);
        StopCoroutine(MarioJump());
    }

    public void Transition()
    {
        if (Player.Instance.canJumping)
        {
            Player.Instance.currnetState = EPlayerState.AERIAL_JUMP;
            fsm.ChangeState(Player.Instance.currnetState);
        }
    }

    void Jump()
    {
        StartCoroutine(MarioJump());
    }

    IEnumerator MarioJump()
    {
        float originTime = jumpTime;

        while (Player.Instance.currnetState == EPlayerState.BASIC_JUMP && originTime > 0 && Input.GetMouseButton(0))
        {
            originTime -= Time.deltaTime;

            if (Player.Instance.currentDirection == EPlayerDirection.RIGHT)
            {
                Vector2 direction = new Vector2(1, 1.75f);
                physic.SetVelocity(direction * jumpPower);
            }
            else if (Player.Instance.currentDirection == EPlayerDirection.LEFT)
            {
                Vector2 direction = new Vector2(-1, 1.75f);
                physic.SetVelocity(direction * jumpPower);
            }

            yield return null;
        }
    }
}
