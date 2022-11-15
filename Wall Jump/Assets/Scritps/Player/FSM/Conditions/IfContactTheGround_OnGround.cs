using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfContactTheGround_OnGround : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (PlayerStatus.CurrentState == PlayerState.OnGround)
        {
            fsm.ChangeState(PlayerState.OnGround); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerStatus.CurrentState = PlayerState.OnGround;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
