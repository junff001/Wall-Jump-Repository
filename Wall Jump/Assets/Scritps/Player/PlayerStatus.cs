using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStatus
{
    public static PlayerState CurrentState { get; set; } = PlayerState.OnGround;
    public static PlayerDirection CurrentDirection { get; set; } = PlayerDirection.Right;

    public static bool IsTouchedWallHead { get; set; } = false;
    public static bool IsTouchedSideWall {get; set; } = false;
    public static bool Bashable { get; set; } = false;
    public static bool IsBashing { get; set; } = false;
    public static bool IsPostureCorrection { get; set; } = false;
}
