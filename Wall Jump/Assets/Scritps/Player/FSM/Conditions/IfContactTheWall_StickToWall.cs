using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfContactTheWall_StickToWall : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (PlayerStatus.CurrentState == PlayerState.StickToWall)
        {
            fsm.ChangeState(PlayerState.StickToWall);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            PlayerStatus.CurrentState = PlayerState.StickToWall;
        }
           
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
