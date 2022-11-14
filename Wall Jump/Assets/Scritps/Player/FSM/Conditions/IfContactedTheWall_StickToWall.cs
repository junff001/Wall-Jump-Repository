using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IfContactedTheWall_StickToWall : TransitionCondition
{
    [SerializeField] private UnityEvent stickToWallEvent;

    public override void Condition(PlayerFSM fsm)
    {
        if (PlayerStatus.CurrentState == PlayerState.StickToWall)
        {
            fsm.ChangeState(PlayerState.StickToWall);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            PlayerStatus.CurrentState = PlayerState.StickToWall;
            PlayerStatus.JumpingCount = 0;
            stickToWallEvent.Invoke();
        }
    }
}
