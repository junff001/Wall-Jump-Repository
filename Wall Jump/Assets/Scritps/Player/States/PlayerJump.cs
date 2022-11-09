using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : State
{
    [SerializeField] private float jumpPower;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;

    private readonly int isJumping = Animator.StringToHash("isJumping");

    public override void Enter(PlayerFSM fsm)
    {
        PlayerStatus.IsJumping = true;
        PlayerStatus.JumpingCount++;
        animator.SetBool(isJumping, PlayerStatus.IsJumping);
        Jump();
    }

    public override void Execute(PlayerFSM fsm)
    {
        
    }

    public override void Exit(PlayerFSM fsm)
    {
        PlayerStatus.IsJumping = false;
    }

    public void Jump()
    {
        Debug.Log("มกวม");

        if (PlayerStatus.Direction == PlayerDirection.Left)
        {
            rigidbody.AddForce(new Vector2(-1, 1.5f) * jumpPower, ForceMode2D.Impulse);
        }
        else if (PlayerStatus.Direction == PlayerDirection.Right)
        {
            rigidbody.AddForce(new Vector2(1, 1.5f) * jumpPower, ForceMode2D.Impulse);
        }
    }
}
