using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfPressedToScreenJumpOrAerialJumpOrFall_Bash : TransitionCondition
{
    public override void Condition(PlayerFSM fsm)
    {
        if (InputManager.Instance.isPress && PlayerStatus.CanBashAim)
        {
            PlayerStatus.CurrentState = PlayerState.BashAim;
        }

        if (PlayerStatus.CurrentState == PlayerState.BashAim)
        {
            fsm.ChangeState(PlayerState.BashAim);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bashable"))
        {
            PlayerStatus.CanBashAim = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bashable"))
        {
            PlayerStatus.CanBashAim = false;
        }
    }
}
