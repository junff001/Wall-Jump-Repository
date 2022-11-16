using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsStickToWall : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (PlayerStatus.CurrentState == PlayerState.StickToWall)
        {
            fsm.ChangeState(PlayerStatus.CurrentState);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            PlayerStatus.CurrentState = PlayerState.StickToWall;
        }
    }
}
