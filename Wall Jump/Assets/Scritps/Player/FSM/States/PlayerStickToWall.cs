using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStickToWall : PlayerIdle
{
    [Header("[ Player Variables ]")]
    [SerializeField] private Transform player;
    [SerializeField] private PlayerPhysic physic;
    [SerializeField] private PlayerDirectionOfView directionOfView;

    [Header("[ Components Variables ]")]
    [SerializeField] private Animator animator;
    private readonly int isStickToWall = Animator.StringToHash("isStickToWall");


    [Header("[ Slipping Variables ]")]
    [SerializeField] private float slipDegree;
    [SerializeField] private float slippingWaitTime;

    public override void Enter(PlayerFSM fsm)
    {
        base.Enter(fsm);

        animator.SetBool(isStickToWall, true);
        physic.VelocityZero();
        physic.GravityScaleZero();
        StartCoroutine(Slipping());
        StickToWall();
    }

    public override void Execute(PlayerFSM fsm)
    {
        base.Execute(fsm);

        switch (PlayerStatus.CurrentState)
        {
            case PlayerState.Death:
                fsm.ChangeState(PlayerState.Death);
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

    private void StickToWall()
    {
        if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
        {
            directionOfView.RightView();
        }
        else if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
        {
            directionOfView.LeftView();
        }
    }

    public IEnumerator Slipping()
    {
        yield return new WaitForSeconds(slippingWaitTime);

        if (PlayerStatus.CurrentState == PlayerState.StickToWall || PlayerStatus.CurrentState == PlayerState.PostureCorrection)
        {
            physic.SetGravityScale(1f);
            physic.SetLinerDrag(slipDegree);
        }
    }
}
