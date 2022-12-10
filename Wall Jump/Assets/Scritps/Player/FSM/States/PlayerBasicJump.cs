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
        Jump();
    }

    public override void Execute(PlayerFSM fsm)
    {
        switch (PlayerStatus.CurrentState)
        {
            case PlayerState.OnGround:
                fsm.ChangeState(PlayerState.OnGround);
                break;
            case PlayerState.StickToWall:
                fsm.ChangeState(PlayerState.StickToWall);
                break;
            case PlayerState.Death:
                fsm.ChangeState(PlayerState.Death);
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
        if (PlayerStatus.Bashable)
        {
            PlayerStatus.CurrentState = PlayerState.BashJump;
            fsm.ChangeState(PlayerStatus.CurrentState);
        }
        else
        {
            PlayerStatus.CurrentState = PlayerState.AerialJump;
            fsm.ChangeState(PlayerStatus.CurrentState);
        } 
    }

    void Jump()
    {
        StartCoroutine(MarioJump());
    }

    IEnumerator MarioJump()
    {
        float originTime = jumpTime;

        while (PlayerStatus.CurrentState == PlayerState.BasicJump && originTime > 0 && Input.GetMouseButton(0))
        {
            originTime -= Time.deltaTime;

            if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
            {
                Vector2 direction = new Vector2(1, 1.75f);
                physic.SetVelocity(direction * jumpPower);
            }
            else if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
            {
                Vector2 direction = new Vector2(-1, 1.75f);
                physic.SetVelocity(direction * jumpPower);
            }

            yield return null;
        }
    }
}
