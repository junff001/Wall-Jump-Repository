using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStickToWall : State, IPressTheScreenToTransition
{
    [SerializeField] private PlayerFilp filp;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;

    private PlayerFSM fsm;  
    private readonly int isStickToWall = Animator.StringToHash("isStickToWall");

    public override void Enter(PlayerFSM fsm)
    {
        this.fsm = fsm;
        animator.SetBool(isStickToWall, true);
        StickToWall();
    }

    public override void Execute(PlayerFSM fsm)
    {
        for (int i = 0; i < conditions.Count; i++)
        {
            conditions[i].Condition(fsm);
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
        animator.SetBool(isStickToWall, false);
        rigidbody.gravityScale = 1;
        PlayerStatus.PreviousState = PlayerState.StickToWall;
    }

    void StickToWall()
    {
        rigidbody.velocity = Vector2.zero;
        rigidbody.gravityScale = 0;
        filp.FilpX();
    }

    public void PressTheScreenToTransition()
    {
        PlayerStatus.CurrentState = PlayerState.Jump;
        fsm.ChangeState(PlayerStatus.CurrentState);
    }
}
