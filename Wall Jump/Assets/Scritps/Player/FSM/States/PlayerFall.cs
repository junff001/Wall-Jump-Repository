using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : State, IPressTheScreenToTransition
{
    [SerializeField] private Animator animator;

    private PlayerFSM fsm;
    private readonly int isFalling = Animator.StringToHash("isFalling");

    public override void Enter(PlayerFSM fsm)
    {
        this.fsm = fsm;
        animator.SetBool(isFalling, true);
    }

    public override void Execute(PlayerFSM fsm)
    {
        for (int i = 0; i < conditions.Count; i++)
        {
            conditions[i].Condition(fsm);
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
        animator.SetBool(isFalling, false);
        PlayerStatus.PreviousState = PlayerState.Fall;
    }

    public void PressTheScreenToTransition()
    {
        if (PlayerStatus.PreviousState == PlayerState.Jump)
        {
            PlayerStatus.CurrentState = PlayerState.AerialJump;
            fsm.ChangeState(PlayerStatus.CurrentState);
        }
        else if (PlayerStatus.PreviousState == PlayerState.OnGround || PlayerStatus.PreviousState == PlayerState.StickToWall)
        {
            PlayerStatus.CurrentState = PlayerState.Jump;
            fsm.ChangeState(PlayerStatus.CurrentState);
        }
        else if (PlayerStatus.PreviousState == PlayerState.AerialJump)
        {
            PlayerStatus.CurrentState = PlayerState.BashJump;
            fsm.ChangeState(PlayerStatus.CurrentState);
        }
    }
}
