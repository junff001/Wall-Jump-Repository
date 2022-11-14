using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : State
{
    [SerializeField] private Animator animator;

    private readonly int isFalling = Animator.StringToHash("isFalling");

    public override void Enter(PlayerFSM fsm)
    {
        animator.SetBool(isFalling, true);
        Fall();
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
        animator.SetBool(isFalling, false);
    }

    public void Fall()
    {
        
    }
}
