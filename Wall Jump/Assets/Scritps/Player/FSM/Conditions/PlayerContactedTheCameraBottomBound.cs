using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContactedTheCameraBottomBound : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (PlayerStatus.CurrentState == PlayerState.Death)
        {
            fsm.ChangeState(PlayerState.Death); 
        }
    }
}
