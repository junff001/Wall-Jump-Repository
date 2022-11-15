using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStickToWall : State
{
    [SerializeField] private UnityEvent stickToWallEvent;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;

    private readonly int isStickToWall = Animator.StringToHash("isStickToWall");

    public override void Enter(PlayerFSM fsm)
    {
        stickToWallEvent.Invoke();
        StickToWall();
        animator.SetBool(isStickToWall, true);
    }

    public override void Execute(PlayerFSM fsm)
    {
        for (int i = 0; i < transitionConditions.Count; i++)
        {
            transitionConditions[i].Condition(fsm);
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
        rigidbody.gravityScale = 1;
        animator.SetBool(isStickToWall, false);
    }

    public void StickToWall()
    {
        rigidbody.gravityScale = 0;
        rigidbody.velocity = Vector2.zero;
    }
}
