using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : State, IPressTheScreenToTransition
{
    private PlayerFSM fsm;

    public override void Enter(PlayerFSM fsm)
    {
        this.fsm = fsm;
    }

    public override void Execute(PlayerFSM fsm)
    {

    }

    public override void Exit(PlayerFSM fsm)
    {
        
    }

    public void Transition()
    {
        if (InputManager.Instance.isStart && !PlayerStatus.IsPostureCorrection)
        {
            if (PlayerStatus.Bashable && Input.GetMouseButtonUp(0))
            {
                PlayerStatus.CurrentState = PlayerState.BashJump;
                fsm.ChangeState(PlayerStatus.CurrentState);
            }
            else
            {
                PlayerStatus.CurrentState = PlayerState.BasicJump;
                fsm.ChangeState(PlayerStatus.CurrentState);
            }
        }
    }
}
