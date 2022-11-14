using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfPressedToScreenInIdleOrWall_Jump : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (InputManager.Instance.isPress)
        {
            PlayerStatus.CurrentState = PlayerState.Jump;
        }

        if (PlayerStatus.CurrentState == PlayerState.Jump)
        {
            fsm.ChangeState(PlayerState.Jump);
        }
    }
}
