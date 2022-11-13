using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStatus
{
    public static PlayerState CurrentState { get; set; } = PlayerState.Idle;
    public static PlayerDirection CurrentDirection { get; set; } = PlayerDirection.Right;

    public static int JumpingCount { get; set; } = 0;
}
