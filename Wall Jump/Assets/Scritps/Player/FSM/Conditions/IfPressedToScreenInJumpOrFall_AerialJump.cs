using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfPressedToScreenInJumpOrFall_AerialJump : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (InputManager.Instance.isPress)
        {
            PlayerStatus.CurrentState = PlayerState.AerialJump;
        }

        if (PlayerStatus.CurrentState == PlayerState.AerialJump)
        {
            fsm.ChangeState(PlayerState.AerialJump);
        }
    }
}
