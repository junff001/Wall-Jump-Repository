using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAerialJump : State, IPressTheScreenToTransition
{
    [Header("[ Components ]")]
    [SerializeField] private PlayerPhysic physic;
    [SerializeField] private Animator animator;

    [Header("[ Jump ]")]
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpTime;

    [Header("[ Sprite ]")]
    [SerializeField] private PlayerDirectionOfView directionOfView;

    private PlayerFSM fsm;
    private readonly int isAerialJumping = Animator.StringToHash("isAerialJumping");

    public override void Enter(PlayerFSM fsm)
    {
        this.fsm = fsm;

        animator.SetBool(isAerialJumping, true);
        physic.VelocityZero();

        if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
        {
            directionOfView.RightView();
        }
        else if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
        {
            directionOfView.LeftView();
        }

       // Debug.Log("공중 점프");
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
            case PlayerState.Death:
                fsm.ChangeState(PlayerState.Death);
                break;
            case PlayerState.PostureCorrection:
                fsm.ChangeState(PlayerState.PostureCorrection);
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
        
        physic.GravityScaleZero();

        while (PlayerStatus.CurrentState == PlayerState.AerialJump && originTime > 0 && Input.GetMouseButton(0))
        {
            originTime -= Time.deltaTime;

            if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
            {
                Vector2 direction = new Vector2(1f, 1.75f);
                physic.SetVelocity(direction * jumpPower);
            }
            else if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
            {
                Vector2 direction = new Vector2(-1f, 1.75f);
                physic.SetVelocity(direction * jumpPower);
            }

            yield return null;
        }
    }

    public void Transition()
    {
        if (PlayerStatus.Bashable && !PlayerStatus.IsPostureCorrection)
        {
            PlayerStatus.CurrentState = PlayerState.BashJump;
            fsm.ChangeState(PlayerStatus.CurrentState);
        }
    }
}
