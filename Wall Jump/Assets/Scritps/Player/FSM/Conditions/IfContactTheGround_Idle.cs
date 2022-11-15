using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfContactTheGround_Idle : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (PlayerStatus.CurrentState == PlayerState.Idle)
        {
            fsm.ChangeState(PlayerState.Idle); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerStatus.CurrentState = PlayerState.Idle;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
