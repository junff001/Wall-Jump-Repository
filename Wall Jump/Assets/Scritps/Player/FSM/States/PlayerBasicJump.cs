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
        switch (Player.Instance.currnetState)
        {
            case PlayerState.StickToWall:
                fsm.ChangeState(PlayerState.StickToWall);
                break;
            case PlayerState.OnGround:
                fsm.ChangeState(PlayerState.OnGround);
                break;
            case PlayerState.Death:
                fsm.ChangeState(PlayerState.Death);
                break;
            case PlayerState.PostureCorrection:
                fsm.ChangeState(PlayerState.PostureCorrection);
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
            Player.Instance.currnetState = PlayerState.AerialJump;
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

        while (Player.Instance.currnetState == PlayerState.BasicJump && originTime > 0 && Input.GetMouseButton(0))
        {
            originTime -= Time.deltaTime;

            if (Player.Instance.currentDirection == PlayerDirection.Right)
            {
                Vector2 direction = new Vector2(1, 1.75f);
                physic.SetVelocity(direction * jumpPower);
            }
            else if (Player.Instance.currentDirection == PlayerDirection.Left)
            {
                Vector2 direction = new Vector2(-1, 1.75f);
                physic.SetVelocity(direction * jumpPower);
            }

            yield return null;
        }
    }
}
