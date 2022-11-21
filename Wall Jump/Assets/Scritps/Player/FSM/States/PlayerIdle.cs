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
        if (PlayerStatus.Bashable)
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
