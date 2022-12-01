using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : State
{
    [SerializeField] private Transform camera;
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnTrm;

    public override void Enter(PlayerFSM fsm)
    {
        
    }

    public override void Execute(PlayerFSM fsm)
    {
        
    }

    public override void Exit(PlayerFSM fsm)
    {
        
    }

    public void Dead()
    {
        player.position = respawnTrm.position;
        camera.position = player.position;
    }
}
