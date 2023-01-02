using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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

        if (Player.Instance.currentDirection == PlayerDirection.Left)
        {
            directionOfView.RightView();
        }
        else if (Player.Instance.currentDirection == PlayerDirection.Right)
        {
            directionOfView.LeftView();
        }

        AerialJump();
    }

    public override void Execute(PlayerFSM fsm)
    {
        switch (Player.Instance.currnetState)
        {
            case PlayerState.StickToWall:
                fsm.ChangeState(PlayerState.StickToWall);
                break;
            case PlayerState.OnGround:
                fsm.ChangeState(PlayerState.OnGround);
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
        Debug.Log("공중 점프 애니메이션 종료");
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

        while (Player.Instance.currnetState == PlayerState.AerialJump && originTime > 0 && Input.GetMouseButton(0))
        {
            originTime -= Time.deltaTime;

            if (Player.Instance.currentDirection == PlayerDirection.Right)
            {
                Vector2 direction = new Vector2(1f, 1.75f);
                physic.SetVelocity(direction * jumpPower);
            }
            else if (Player.Instance.currentDirection == PlayerDirection.Left)
            {
                Vector2 direction = new Vector2(-1f, 1.75f);
                physic.SetVelocity(direction * jumpPower);
            }

            yield return null;
        }
    }

    public void Transition()
    {
        //if (Player.Instance.canJumping)
        //{
        //    Player.Instance.currnetState = PlayerState.BashJump;
        //    fsm.ChangeState(Player.Instance.currnetState);
        //}  
    }
}
