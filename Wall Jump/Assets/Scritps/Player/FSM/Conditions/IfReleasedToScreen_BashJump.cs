using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfReleasedToScreen_BashJump : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (InputManager.Instance.isRelease && PlayerStatus.CurrentState == PlayerState.BashAim)
        {
            PlayerStatus.CurrentState = PlayerState.BashJump;
        }

        if (PlayerStatus.CurrentState == PlayerState.BashJump)
        {
            fsm.ChangeState(PlayerState.BashJump);  
        }
    }
}
