using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfPressedToScreenThreeTimes_BashAim : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (PlayerStatus.CurrentState == PlayerState.BashAim)
        {
            fsm.ChangeState(PlayerState.BashAim);
        }
    }
}
