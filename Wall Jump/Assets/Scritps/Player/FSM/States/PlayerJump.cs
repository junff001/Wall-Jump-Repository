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
        Jump();
    }

    public override void Execute(PlayerFSM fsm)
    {
        for (int i = 0; i < transitionConditions.Count; i++)
        {
            transitionConditions[i].Condition(fsm);
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
       
    }

    public void Jump()
    {
        Debug.Log("มกวม");

        if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
        {
            rigidbody.AddForce(new Vector2(-1, 1.5f) * jumpPower, ForceMode2D.Impulse);
        }
        else if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
        {
            rigidbody.AddForce(new Vector2(1, 1.5f) * jumpPower, ForceMode2D.Impulse);
        }
    }
}
