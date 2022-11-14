using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfPlayerIsFalling_Fall : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (PlayerStatus.CurrentState == PlayerState.Fall)
        {
            fsm.ChangeState(PlayerState.Fall);
        }
    }
}
