using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfTouchedToScreenTwice_AerialJump : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (PlayerStatus.CurrentState == PlayerState.AerialJump)
        {
            fsm.ChangeState(PlayerState.AerialJump);
        }
    }
}
