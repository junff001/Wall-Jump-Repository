using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] private float moveRange;
    [SerializeField] private float moveHeight;

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
        switch (PlayerStatus.CurrentState)
        {
            case PlayerState.Death:
                fsm.ChangeState(PlayerState.Death);
                break;
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
        animator.SetBool(isStickToWall, false);
        physic.SetGravityScale(1f);
        physic.SetLinerDrag(1f);
    }

    public void Transition()
    {
        PlayerStatus.CurrentState = PlayerState.BasicJump;
        fsm.ChangeState(PlayerStatus.CurrentState);
    }

    public IEnumerator MoveToSideOfWall(Transform postureCorrectionPoint)
    {
        float currentTime = 0f;

        Vector3 contactPoint = player.position;

        while (currentTime < moveToTheWallLerpTime)
        {
            if (PlayerStatus.CurrentState == PlayerState.BasicJump)
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
        StartCoroutine(stickToWall.Slipping());
    }
}
