using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStickToWall : PlayerIdle
{
    [SerializeField] private Transform player;
    [SerializeField] private PlayerFilp filp;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;
    [SerializeField] private CameraFraming cameraFraming;
    [SerializeField] private float moveToTheWallLerpTime;
    [SerializeField] private float moveRange;
    [SerializeField] private float moveHeight;

    private readonly int isStickToWall = Animator.StringToHash("isStickToWall");

    public override void Enter(PlayerFSM fsm)
    {
        rigidbody.velocity = Vector3.zero;
        base.Enter(fsm);
        animator.SetBool(isStickToWall, true);
        StickToWall();
       // WallInquiry();
    }

    public override void Execute(PlayerFSM fsm)
    {
        base.Execute(fsm);
    }

    public override void Exit(PlayerFSM fsm)
    {
        base.Exit(fsm);
        animator.SetBool(isStickToWall, false);
        rigidbody.gravityScale = 1;
    }

    void StickToWall()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.gravityScale = 0;
        filp.FilpX();
    }

    public IEnumerator MoveToTheWall(Collider2D collider)
    {
        if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
        {
            float timer = 0f;
            Vector3 startPos = player.position;
            Vector3 targetPos = collider.bounds.center + new Vector3(-(collider.bounds.extents.x + moveRange), moveHeight, 0);

            while (timer < moveToTheWallLerpTime)
            {
                timer += Time.deltaTime;
                
                if (timer > moveToTheWallLerpTime)
                {
                    timer = moveToTheWallLerpTime;
                }

                player.localScale = new Vector3(-1, player.localScale.y, player.localScale.z);
                player.position = Vector3.Lerp(startPos, targetPos, timer / moveToTheWallLerpTime);

                yield return null;
            }
        }
        else if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
        {
            float timer = 0f;
            Vector3 startPos = player.position;
            Vector3 targetPos = collider.bounds.center + new Vector3(collider.bounds.extents.x + moveRange, moveHeight, 0);

            while (timer < moveToTheWallLerpTime)
            {
                timer += Time.deltaTime;

                if (timer > moveToTheWallLerpTime)
                {
                    timer = moveToTheWallLerpTime;
                }

                player.localScale = new Vector3(1, player.localScale.y, player.localScale.z);
                player.position = Vector3.Lerp(startPos, targetPos, timer / moveToTheWallLerpTime);

                yield return null;
            }
        }

        PlayerStatus.CurrentState = PlayerState.StickToWall;
    }

    public void WallInquiry()
    {
        for (int i = 0; i < GameManager.Instance.walls.Count; i++)
        {
            if (GameManager.Instance.CurrentStickToWall == GameManager.Instance.walls[i])
            {
                float wallsDistance = GameManager.Instance.walls[i + 1].position.x - GameManager.Instance.CurrentStickToWall.position.x;

                if (Mathf.Abs(wallsDistance) != GameManager.Instance.wallProperDistance && wallsDistance != 0)
                {
                    //cameraFraming.Framing(wallsDistance);
                }
            }
        }       
    }
}
