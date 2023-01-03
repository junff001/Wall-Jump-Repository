using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStickToWall : PlayerIdle
{
    [Header("[ Player Variables ]")]
    [SerializeField] private PlayerPhysic physic;
    [SerializeField] private PlayerDirectionOfView directionOfView;

    [Header("[ Components Variables ]")]
    [SerializeField] private Animator animator;
    private readonly int isStickToWall = Animator.StringToHash("isStickToWall");

    public override void Enter(PlayerFSM fsm)
    {
        base.Enter(fsm);

        animator.SetBool(isStickToWall, true);

        directionOfView.ReverseView();
        physic.VelocityZero();
        physic.GravityScaleZero();
    }

    public override void Execute(PlayerFSM fsm)
    {
        base.Execute(fsm);

        switch (Player.Instance.currnetState)
        {
            case PlayerState.Death:
                fsm.ChangeState(PlayerState.Death);
                break;
            case PlayerState.BasicJump:
                fsm.ChangeState(PlayerState.BasicJump);
                break;
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
        base.Exit(fsm);

        animator.SetBool(isStickToWall, false);
        physic.SetGravityScale(1f);
        physic.SetLinerDrag(1f);
    }
}
