using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStickToWall : PlayerIdle
{
    [Header("[ Player ]")]
    [SerializeField] private Transform player;
    [SerializeField] private PlayerPhysic physic;
    [SerializeField] private PlayerDirectionOfView directionOfView;

    [Header("[ Components ]")]
    [SerializeField] private Animator animator;
    [SerializeField] private CircleCollider2D deadBoundCol;
    [SerializeField] private BoxCollider2D wallSensor;

    private readonly int isStickToWall = Animator.StringToHash("isStickToWall");

    public override void Enter(PlayerFSM fsm)
    {
        Debug.Log("º® ºÎÂø");
        base.Enter(fsm);

        //wallSensor.enabled = false;
        animator.SetBool(isStickToWall, true);
        physic.VelocityZero();
        physic.GravityScaleZero();
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

       // wallSensor.enabled = true;
        animator.SetBool(isStickToWall, false);
        physic.SetGravityScale(1f);
    }

    void StickToWall()
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
}
