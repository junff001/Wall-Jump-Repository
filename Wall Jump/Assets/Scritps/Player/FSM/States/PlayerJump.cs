using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerJump : State, IPressTheScreenToTransition
{
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpTime;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;

    private PlayerFSM fsm;
    private readonly int isJumping = Animator.StringToHash("isJumping");

    public override void Enter(PlayerFSM fsm)
    {
        this.fsm = fsm;
        animator.SetBool(isJumping, true);
        Jump();
    }

    public override void Execute(PlayerFSM fsm)
    {
        for (int i = 0; i < conditions.Count; i++)
        {
            conditions[i].Condition(fsm);
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
        animator.SetBool(isJumping, false);
        PlayerStatus.PreviousState = PlayerState.Jump;
    }

    void Jump()
    {
        StartCoroutine(MarioJump());
    }

    IEnumerator MarioJump()
    {
        float originTime = jumpTime;

        while (originTime > 0 || InputManager.Instance.isPress && PlayerStatus.CurrentState == PlayerState.Jump)
        {
            originTime -= Time.deltaTime;

            if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
            {
                rigidbody.velocity = new Vector2(1, 1.5f) * jumpPower;
            }
            else if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
            {
                rigidbody.velocity = new Vector2(-1, 1.5f) * jumpPower;
            }

            yield return null;
        }
    }

    public void PressTheScreenToTransition()
    {
        PlayerStatus.CurrentState = PlayerState.AerialJump;
        fsm.ChangeState(PlayerStatus.CurrentState);
    }
}
