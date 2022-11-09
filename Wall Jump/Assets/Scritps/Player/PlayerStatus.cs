using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStatus
{
    public static bool IsJumping { get; set; } = false;
    public static int JumpingCount { get; set; } = 0;
    public static bool IsOnGround { get; set; } = false;
    public static bool IsStickToWall { get; set; } = false;

    public static PlayerDirection Direction { get; set; } = PlayerDirection.Right;
}
