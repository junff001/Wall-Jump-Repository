using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStickToWall : State
{
    [SerializeField] private Rigidbody2D rigidbody;

    public override void Enter(PlayerFSM fsm)
    {
        throw new System.NotImplementedException();
    }

    public override void Execute(PlayerFSM fsm)
    {
        throw new System.NotImplementedException();
    }

    public override void Exit(PlayerFSM fsm)
    {
        throw new System.NotImplementedException();
    }

    public void StickToWall()
    {
        rigidbody.gravityScale = 0;
        rigidbody.velocity = Vector2.zero;
    }
}
