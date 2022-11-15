using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfFalling_Fall : TransitionCondition
{
    [SerializeField] private Rigidbody2D rigidbody;

    public override void Condition(PlayerFSM fsm)
    {
        if (rigidbody.velocity.y < 0)
        {
            PlayerStatus.CurrentState = PlayerState.Fall;
        }

        if (PlayerStatus.CurrentState == PlayerState.Fall)
        {
            fsm.ChangeState(PlayerState.Fall);
        }
    }
}
