using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirJump : State
{
    [SerializeField] private float jumpPower;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidbody;

    public void AirJump()
    {

    }

    public override void Enter(PlayerFSM fsm)
    {
        throw new System.NotImplementedException();
    }

    public override void Execute(PlayerFSM fsm)
    {
        throw new System.NotImplementedException();
    }

    public override void Exit(PlayerFSM fsm)
    {
        throw new System.NotImplementedException();
    }
}
