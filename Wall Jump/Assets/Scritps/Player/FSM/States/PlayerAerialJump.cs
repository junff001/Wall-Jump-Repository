using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAerialJump : State
{
    [SerializeField] private float jumpPower;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private UnityEvent aerialJumpEvent;

    private readonly int isAerialJump = Animator.StringToHash("isAerialJump");

    public override void Enter(PlayerFSM fsm)
    {
        AerialJump();
        animator.SetBool(isAerialJump, true);
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
        animator.SetBool(isAerialJump, false);
    }

    public void AerialJump()
    {
        aerialJumpEvent.Invoke();
        rigidbody.velocity = Vector2.zero;

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
