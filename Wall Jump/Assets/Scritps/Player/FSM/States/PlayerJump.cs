using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : State
{
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpTime;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;

    private readonly int isJumping = Animator.StringToHash("isJumping");

    public override void Enter(PlayerFSM fsm)
    {
        
        Jump();
        animator.SetBool(isJumping, true);
    }

    public override void Execute(PlayerFSM fsm)
    {
        for (int i = 0; i < transitionConditions.Count; i++)
        {
            transitionConditions[i].Condition(fsm);
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
        animator.SetBool(isJumping, false);
    }

    public void Jump()
    {
        StartCoroutine(MarioJump());
    }

    IEnumerator MarioJump()
    {
        float timer = jumpTime;

        while (InputManager.Instance.isPress && timer > 0)
        {
            timer -= Time.deltaTime;

            if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
            {
                rigidbody.velocity = new Vector2(-1, 1.5f) * jumpPower;
            }
            else if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
            {
                rigidbody.velocity = new Vector2(1, 1.5f) * jumpPower;
            }

            yield return null;
        }
    }
}
