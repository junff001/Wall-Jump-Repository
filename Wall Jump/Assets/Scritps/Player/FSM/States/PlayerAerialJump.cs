using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAerialJump : State, IPressTheScreenToTransition
{
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpTime;
    [SerializeField] private float fallGravity;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerFilp filp;

    private PlayerFSM fsm;
    private readonly int isAerialJumping = Animator.StringToHash("isAerialJumping");

    public override void Enter(PlayerFSM fsm)
    {
        this.fsm = fsm;
        animator.SetBool(isAerialJumping, true);
        rigidbody.velocity = Vector2.zero;
        filp.FilpX();
        AerialJump();
    }

    public override void Execute(PlayerFSM fsm)
    {
        switch (PlayerStatus.CurrentState)
        {
            case PlayerState.OnGround:
                fsm.ChangeState(PlayerState.OnGround);
                break;
            case PlayerState.StickToWall:
                fsm.ChangeState(PlayerState.StickToWall);
                break;
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
        animator.SetBool(isAerialJumping, false);
        StopCoroutine(MarioJump());
    }

    void AerialJump()
    {
        StartCoroutine(MarioJump());
    }

    IEnumerator MarioJump()
    {
        float originTime = jumpTime;
        rigidbody.gravityScale = 0;

        while (PlayerStatus.CurrentState == PlayerState.AerialJump && originTime > 0 && InputManager.Instance.isPress)
        {
            originTime -= Time.deltaTime;

            if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
            {
                rigidbody.velocity = new Vector2(1, 1.75f) * jumpPower;
            }
            else if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
            {
                rigidbody.velocity = new Vector2(-1, 1.75f) * jumpPower;
            }

            yield return null;
        }

        rigidbody.gravityScale = fallGravity;
    }

    public void Transition()
    {
        if (PlayerStatus.Bashable)
        {
            PlayerStatus.CurrentState = PlayerState.BashJump;
            fsm.ChangeState(PlayerStatus.CurrentState);
        }
    }
}
