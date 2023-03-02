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
            case PlayerState.BasicJump:
                fsm.ChangeState(PlayerState.BasicJump);
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
        Player.Instance.currnetState = PlayerState.BasicJump;
        fsm.ChangeState(Player.Instance.currnetState);
    }

    public IEnumerator MoveToSideOfWall(Transform postureCorrectionPoint, UnityAction changeVeiw)
    {
        Player.Instance.isPostureCorrecting = true;
        float currentTime = 0f;

        Vector3 contactPoint = player.position;

        #region 교정포인트로 러프 써서 이동
        while (currentTime < moveToTheWallLerpTime && !Player.Instance.isTheWallCurrentlyFlipping)
        {
            if (Player.Instance.currnetState == PlayerState.BasicJump)
            {
                changeVeiw.Invoke();
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
        #endregion

        changeVeiw.Invoke();

        Player.Instance.isPostureCorrecting = false;

        animator.SetBool(isStickToWall, true);

        float posXAfterPostureCorrection = 0;

        #region 자세교정 중 플립되지 않았다면 위치 설정
        if (Player.Instance.currentDirection == PlayerDirection.Left)
        {
            posXAfterPostureCorrection = Player.Instance.transform.position.x - offsetAfterPostureCorrection;
        }
        else if (Player.Instance.currentDirection == PlayerDirection.Right)
        {
            posXAfterPostureCorrection = Player.Instance.transform.position.x + offsetAfterPostureCorrection;
        }
        

        if (!Player.Instance.isTheWallCurrentlyFlipping)
        {
            Player.Instance.transform.position = new Vector3(posXAfterPostureCorrection, Player.Instance.transform.position.y, Player.Instance.transform.position.z);
        }
        #endregion
    }
}
