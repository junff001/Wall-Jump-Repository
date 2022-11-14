using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfPressedToScreenInIdleState_Jump : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (PlayerStatus.CurrentState == PlayerState.Jump)
        {
            fsm.ChangeState(PlayerState.Jump);
        }
    }
}
