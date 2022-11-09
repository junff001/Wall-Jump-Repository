using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : State
{
    [SerializeField] private Animator animator;

    private readonly int isOnGround = Animator.StringToHash("isOnGround");

    public override void Enter(PlayerFSM fsm)
    {
        PlayerStatus.IsJumping = false;
        PlayerStatus.JumpingCount = 0;
        PlayerStatus.IsOnGround = true;

        animator.SetBool(isOnGround, PlayerStatus.IsOnGround);
    }

    public override void Execute(PlayerFSM fsm)
    {
        if (PlayerStatus.IsJumping)
        {
            fsm.ChangeState(PlayerState.Jump);
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
        PlayerStatus.IsOnGround = false;
    }
}
