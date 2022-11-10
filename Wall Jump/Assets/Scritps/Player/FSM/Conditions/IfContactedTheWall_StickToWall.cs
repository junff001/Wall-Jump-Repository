using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfContactedTheWall_StickToWall : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (PlayerStatus.CurrentState == PlayerState.StickToWall)
        {
            fsm.ChangeState(PlayerState.StickToWall);
        }
    }
}
