using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBashJump : State
{
    public override void Enter(PlayerFSM fsm)
    {
        
    }

    public override void Execute(PlayerFSM fsm)
    {
        for (int i = 0; i < transitionConditions.Count; i++)
        {
            transitionConditions[i].Condition(fsm);
        }
    }

    public override void Exit(PlayerFSM fsm) 
    {
        
    }
}
