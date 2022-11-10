using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchedToScreenOnce : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        Debug.Log("점프 조건 보는중");
        if (PlayerStatus.CurrentState == PlayerState.Jump)
        {
            fsm.ChangeState(PlayerState.Jump);
        }
    }
}
