using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    public PlayerState currnetState { get; set; } = PlayerState.OnGround;
    public PlayerDirection currentDirection { get; set; } = PlayerDirection.Right;

    public bool canJumping { get; set; } = true;
    public bool IsTheWallCurrentlyFlipping { get; set; } = false;
    public Transform currentStickToWall { get; set; } = null;

    [Header("[ Components Variables ]")]
    public PlayerPhysic physic;
    public PlayerDirectionOfView directionOfView;
}
