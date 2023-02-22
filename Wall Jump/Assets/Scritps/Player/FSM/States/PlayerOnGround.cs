using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGround : PlayerIdle
{
    [Header("[ Components Variables]")]
    [SerializeField] private PlayerPhysic physic;
    [SerializeField] private Animator animator;

    private readonly int isOnGround = Animator.StringToHash("isOnGround");

    public override void Enter(PlayerFSM fsm)
    {
        
        physic.VelocityZero();
        base.Enter(fsm);    
        animator.SetBool(isOnGround, true);
    }

    public override void Execute(PlayerFSM fsm)
    {
        base.Execute(fsm);

        switch (Player.Instance.currnetState)
        {
            case EPlayerState.DEATH:
                fsm.ChangeState(EPlayerState.DEATH);
                break;
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
        base.Exit(fsm);
        animator.SetBool(isOnGround, false);
    }
}
