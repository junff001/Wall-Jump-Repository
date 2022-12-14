using Cinemachine;
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

    [Header("[ Move to the wall ]")]
    [SerializeField] private float moveToTheWallLerpTime;
    [SerializeField] private float moveRange;
    [SerializeField] private float moveHeight;

    private readonly int isStickToWall = Animator.StringToHash("isStickToWall");

    public override void Enter(PlayerFSM fsm)
    {      
        base.Enter(fsm);

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

    public void PostureCorrection(Collider2D collider)
    {
        if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
        {
            StartCoroutine(MoveToSideOfWall_Right(collider));  
        }
        else if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
        {
            StartCoroutine(MoveToSideOfWall_Left(collider));
        }
    }

    public IEnumerator MoveToSideOfWall_Right(Collider2D collider)
    {
        PlayerStatus.IsPostureCorrection = true;
        float timer = 0f;

        Vector3 contactPoint = player.position;
        Vector3 sideOfWallPoint = collider.bounds.center + new Vector3(collider.bounds.extents.x + moveRange, moveHeight, 0);

        while (timer < moveToTheWallLerpTime)
        {
            timer += Time.deltaTime;

            if (timer > moveToTheWallLerpTime)
            {
                timer = moveToTheWallLerpTime;
            }

            player.localScale = new Vector3(1f, player.localScale.y, player.localScale.z);
            player.position = Vector3.Lerp(contactPoint, sideOfWallPoint, timer / moveToTheWallLerpTime);

            yield return null;
        }

        PlayerStatus.CurrentState = PlayerState.StickToWall;
        PlayerStatus.IsPostureCorrection = false;
    }

    public IEnumerator MoveToSideOfWall_Left(Collider2D collider)
    {
        PlayerStatus.IsPostureCorrection = true;
        float timer = 0f;

        Vector3 contactPoint = player.position;
        Vector3 sideOfWallPoint = collider.bounds.center + new Vector3(-(collider.bounds.extents.x + moveRange), moveHeight, 0);

        while (timer < moveToTheWallLerpTime)
        {
            timer += Time.deltaTime;

            if (timer > moveToTheWallLerpTime)
            {
                timer = moveToTheWallLerpTime;
            }

            player.localScale = new Vector3(-1f, player.localScale.y, player.localScale.z);
            player.position = Vector3.Lerp(contactPoint, sideOfWallPoint, timer / moveToTheWallLerpTime);

            yield return null;
        }

        PlayerStatus.CurrentState = PlayerState.StickToWall;
        PlayerStatus.IsPostureCorrection = false;
    }
}
