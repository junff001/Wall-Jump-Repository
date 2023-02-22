using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerAerialJump : State, IPressTheScreenToTransition
{
    [Header("[ Components ]")]
    [SerializeField] private PlayerPhysic physic;
    [SerializeField] private Animator animator;

    [Header("[ Jump ]")]
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpTime;

    [Header("[ Sprite ]")]
    [SerializeField] private PlayerDirectionOfView directionOfView;

    private PlayerFSM fsm;
    private readonly int isAerialJumping = Animator.StringToHash("isAerialJumping");

    public override void Enter(PlayerFSM fsm)
    {
        this.fsm = fsm;

        animator.SetBool(isAerialJumping, true);
        physic.VelocityZero();

        if (Player.Instance.currentDirection == EPlayerDirection.LEFT)
        {
            directionOfView.RightView();
        }
        else if (Player.Instance.currentDirection == EPlayerDirection.RIGHT)
        {
            directionOfView.LeftView();
        }

        AerialJump();
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
            case EPlayerState.BASIC_JUMP:
                fsm.ChangeState(EPlayerState.BASIC_JUMP);
                break;
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
        animator.SetBool(isAerialJumping, false);
        StopCoroutine(MarioJump());
    }

    void AerialJump()
    {
        StartCoroutine(MarioJump());
    }

    IEnumerator MarioJump()
    {
        float originTime = jumpTime;
        
        physic.GravityScaleZero();

        while (Player.Instance.currnetState == EPlayerState.AERIAL_JUMP && originTime > 0 && Input.GetMouseButton(0))
        {
            originTime -= Time.deltaTime;

            if (Player.Instance.currentDirection == EPlayerDirection.RIGHT)
            {
                Vector2 direction = new Vector2(1f, 1.75f);
                physic.SetVelocity(direction * jumpPower);
            }
            else if (Player.Instance.currentDirection == EPlayerDirection.LEFT)
            {
                Vector2 direction = new Vector2(-1f, 1.75f);
                physic.SetVelocity(direction * jumpPower);
            }

            yield return null;
        }
    }

    public void Transition()
    {
        //if (Player.Instance.canJumping)
        //{
        //    Player.Instance.currnetState = PlayerState.BashJump;
        //    fsm.ChangeState(Player.Instance.currnetState);
        //}  
    }
}
