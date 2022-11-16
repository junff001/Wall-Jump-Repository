using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDead : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (PlayerStatus.CurrentState == PlayerState.Death)
        {
            fsm.ChangeState(PlayerStatus.CurrentState);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathObject"))
        {
            PlayerStatus.CurrentState = PlayerState.Death;
        }
    }
}
