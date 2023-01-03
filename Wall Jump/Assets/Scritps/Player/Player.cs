using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    public PlayerState currnetState { get; set; } = PlayerState.OnGround;
    public PlayerDirection currentDirection { get; set; } = PlayerDirection.Right;

    public bool canJumping { get; set; } = true;
    public bool isPostureCorrecting { get; set; } = false;
    public bool isTheWallCurrentlyFlipping { get; set; } = false;
    public bool isCurrentlyBouncedOffTheWall { get; set; } = false;

    public Transform currentStickToWall { get; set; } = null;

    [Header("[ Components Variables ]")]
    public PlayerPhysic physic;
    public PlayerDirectionOfView directionOfView;
    public Animator animator;
}
