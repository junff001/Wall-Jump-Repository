using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerPostureCorrection : State, IPressTheScreenToTransition
{
    [Header("[ Components ]")]
    [SerializeField] private Transform player;
    [SerializeField] private PlayerPhysic physic;
    [SerializeField] private PlayerDirectionOfView directionOfView;
    [SerializeField] private PlayerStickToWall stickToWall;
    [SerializeField] private Animator animator;

    [Header("[ Move to the wall ]")]
    [SerializeField] private float moveToTheWallLerpTime;
    [SerializeField] private float offsetAfterPostureCorrection;

    private PlayerFSM fsm;
    private readonly int isStickToWall = Animator.StringToHash("isStickToWall");

    public override void Enter(PlayerFSM fsm)
    {
        this.fsm = fsm;

        physic.VelocityZero();
        physic.GravityScaleZero();
    }

    public override void Execute(PlayerFSM fsm)
    {
        switch (Player.Instance.currnetState)
        {
            case PlayerState.Death:
                fsm.ChangeState(PlayerState.Death);
                break;
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
        if (Player.Instance.currentDirection == PlayerDirection.Left)
        {
            directionOfView.LeftView();
        }
        else if (Player.Instance.currentDirection == PlayerDirection.Right)
        {
            directionOfView.RightView();
        }

        animator.SetBool(isStickToWall, false);
        physic.SetGravityScale(1f);
        physic.SetLinerDrag(1f);
    }

    public void Transition()
    {
        Player.Instance.currnetState = PlayerState.BasicJump;
        fsm.ChangeState(Player.Instance.currnetState);
    }

    public IEnumerator MoveToSideOfWall(Transform postureCorrectionPoint, UnityAction changeDirectionEvent)
    {
        float currentTime = 0f;

        Vector3 contactPoint = player.position;

        if (Player.Instance.currentDirection == PlayerDirection.Left)
        {
            Player.Instance.currentDirection = PlayerDirection.Right;
        }
        else if (Player.Instance.currentDirection == PlayerDirection.Right)
        {
            Player.Instance.currentDirection = PlayerDirection.Left;
        }

        //changeDirectionEvent.Invoke();

        while (currentTime < moveToTheWallLerpTime && !Player.Instance.IsTheWallCurrentlyFlipping)
        {
            if (Player.Instance.currnetState == PlayerState.BasicJump)
            {
                yield break;
            }

            currentTime += Time.deltaTime;

            if (currentTime > moveToTheWallLerpTime)
            {
                currentTime = moveToTheWallLerpTime;
            }

            player.position = Vector3.Lerp(contactPoint, postureCorrectionPoint.position, currentTime / moveToTheWallLerpTime);

            yield return null;
        }

        animator.SetBool(isStickToWall, true);

        float posXAfterPostureCorrection = 0;

        if (Player.Instance.currentDirection == PlayerDirection.Left)
        {
            directionOfView.LeftView();
            posXAfterPostureCorrection = Player.Instance.transform.position.x - offsetAfterPostureCorrection;
        }
        else if (Player.Instance.currentDirection == PlayerDirection.Right)
        {
            directionOfView.RightView();
            posXAfterPostureCorrection = Player.Instance.transform.position.x + offsetAfterPostureCorrection;
        }

        if (!Player.Instance.IsTheWallCurrentlyFlipping)
        {
            Player.Instance.transform.position = new Vector3(posXAfterPostureCorrection, Player.Instance.transform.position.y, Player.Instance.transform.position.z);
        }
    }
}
