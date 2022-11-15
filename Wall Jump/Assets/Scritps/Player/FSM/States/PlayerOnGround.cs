using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGround : State
{
    [SerializeField] private Animator animator;

    private readonly int isOnGround = Animator.StringToHash("isOnGround");

    public override void Enter(PlayerFSM fsm)
    {
        animator.SetBool(isOnGround, true);
    }

    public override void Execute(PlayerFSM fsm)
    {
        if (InputManager.Instance.isPress)
        {
            PlayerStatus.CurrentState = PlayerState.Jump;
        }

        for (int i = 0; i < transitionConditions.Count; i++)
        {
            transitionConditions[i].Condition(fsm);
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
        animator.SetBool(isOnGround, false);
    }
}
