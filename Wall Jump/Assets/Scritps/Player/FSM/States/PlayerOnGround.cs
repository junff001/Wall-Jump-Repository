using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGround : State, IPressTheScreenToTransition
{
    [SerializeField] private Animator animator;

    private PlayerFSM fsm;
    private readonly int isOnGround = Animator.StringToHash("isOnGround");

    public override void Enter(PlayerFSM fsm)
    {
        this.fsm = fsm;
        animator.SetBool(isOnGround, true);
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
        animator.SetBool(isOnGround, false);
        PlayerStatus.PreviousState = PlayerState.OnGround;

    }

    public void PressTheScreenToTransition()
    {
        PlayerStatus.CurrentState = PlayerState.Jump;
        fsm.ChangeState(PlayerStatus.CurrentState);
    }
}
