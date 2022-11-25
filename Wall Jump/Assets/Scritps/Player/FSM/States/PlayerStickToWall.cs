using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStickToWall : PlayerIdle
{
    [SerializeField] private Transform player;
    [SerializeField] private PlayerFilp filp;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;
    [SerializeField] private float moveToTheWallLerpTime;
    [SerializeField] private float moveRange;

    private readonly int isStickToWall = Animator.StringToHash("isStickToWall");

    public override void Enter(PlayerFSM fsm)
    {
        rigidbody.velocity = Vector3.zero;
        base.Enter(fsm);
        animator.SetBool(isStickToWall, true);
        StickToWall();
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
        player.position = collider.bounds.center;

        yield return null;
    }
}
