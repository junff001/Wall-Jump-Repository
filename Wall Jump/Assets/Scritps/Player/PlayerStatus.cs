using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStatus
{
    public static bool CanJumping { get; set; } = false;
    public static int JumpingCount { get; set; } = 0;
    public static PlayerDirection Direction { get; set; } = PlayerDirection.Right;
}
