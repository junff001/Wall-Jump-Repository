using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnGround : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (PlayerStatus.CurrentState == PlayerState.OnGround)
        {
            fsm.ChangeState(PlayerStatus.CurrentState);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerStatus.CurrentState = PlayerState.OnGround;
        }
    }
}
