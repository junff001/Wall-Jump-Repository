using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContactedTheGround : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (PlayerStatus.CurrentState == PlayerState.Idle)
        {
            fsm.ChangeState(PlayerState.Idle);
        }
    }
}
