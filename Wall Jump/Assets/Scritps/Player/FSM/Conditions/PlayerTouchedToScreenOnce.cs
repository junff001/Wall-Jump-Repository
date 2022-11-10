using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchedToScreenOnce : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        Debug.Log("���� ���� ������");
        if (PlayerStatus.CurrentState == PlayerState.Jump)
        {
            fsm.ChangeState(PlayerState.Jump);
        }
    }
}
