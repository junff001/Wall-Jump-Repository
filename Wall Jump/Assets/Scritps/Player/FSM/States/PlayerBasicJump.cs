using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerBasicJump : State, IPressTheScreenToTransition
{
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpTime;
    [SerializeField] private float fallGravity;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;

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
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
        animator.SetBool(isJumping, false);
        StopCoroutine(MarioJump());
    }

    public void Transition()
    {
        PlayerStatus.CurrentState = PlayerState.AerialJump;
        fsm.ChangeState(PlayerStatus.CurrentState);
    }

    void Jump()
    {
        StartCoroutine(MarioJump());
    }

    IEnumerator MarioJump()
    {
        float originTime = jumpTime;
        rigidbody.gravityScale = 0;

        while (PlayerStatus.CurrentState == PlayerState.BasicJump && originTime > 0 && InputManager.Instance.isPress)
        {
            originTime -= Time.deltaTime;

        
            if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
            {
                rigidbody.velocity = new Vector2(1, 1.5f) * jumpPower;
            }
            else if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
            {
                rigidbody.velocity = new Vector2(-1, 1.5f) * jumpPower;
            }

            yield return null;
        }

        rigidbody.gravityScale = fallGravity;
    }
}