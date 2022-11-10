using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStickToWall : State
{
    [SerializeField] private Rigidbody2D rigidbody;

    public override void Enter(PlayerFSM fsm)
    {

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

    }

    public void StickToWall()
    {
        rigidbody.gravityScale = 0;
        rigidbody.velocity = Vector2.zero;
    }
}
