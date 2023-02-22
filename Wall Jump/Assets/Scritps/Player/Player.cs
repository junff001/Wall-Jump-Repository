using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    public EPlayerState currnetState { get; set; } = EPlayerState.ON_GROUND;
    public EPlayerDirection currentDirection { get; set; } = EPlayerDirection.RIGHT;

    public bool canJumping { get; set; } = true;
    public bool isPostureCorrecting { get; set; } = false;
    public bool isTheWallCurrentlyFlipping { get; set; } = false;
    public bool isCurrentlyBouncedOffTheWall { get; set; } = false;
    public bool isCurrentlySlippingTheWall { get; set; } = false;

    public Transform currentStickToWall { get; set; } = null;

    [Header("[ Components Variables ]")]
    public PlayerPhysic physic;
    public PlayerDirectionOfView directionOfView;
    public Animator animator;
}
