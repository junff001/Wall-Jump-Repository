using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStatus
{
    public static PlayerState CurrentState { get; set; } = PlayerState.OnGround;
    public static PlayerDirection CurrentDirection { get; set; } = PlayerDirection.Right;

    public static bool CanBashAim { get; set; } = false;
}
