using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfTouchedToScreenThreeTimes_BashJump : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (PlayerStatus.CurrentState == PlayerState.BashJump)
        {
            fsm.ChangeState(PlayerState.BashJump);
        }
    }
}
