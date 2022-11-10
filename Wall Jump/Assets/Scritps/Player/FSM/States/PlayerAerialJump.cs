using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAerialJump : State
{
    [SerializeField] private float jumpPower;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidbody;

    public void AirJump()
    {

    }

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
