using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnGround : PlayerIdle
{
    [Header("[ Components ]")]
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;

    private readonly int isOnGround = Animator.StringToHash("isOnGround");

    public override void Enter(PlayerFSM fsm)
    {
        rigidbody.velocity = Vector2.zero;
        base.Enter(fsm);    
        animator.SetBool(isOnGround, true);
    }

    public override void Execute(PlayerFSM fsm)
    {
        base.Execute(fsm);
    }

    public override void Exit(PlayerFSM fsm)
    {
        base.Exit(fsm);
        animator.SetBool(isOnGround, false);
    }
}
