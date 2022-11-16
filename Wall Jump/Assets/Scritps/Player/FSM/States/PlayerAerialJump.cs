using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAerialJump : State, IPressTheScreenToTransition
{
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpTime;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerFilp filp;

    private PlayerFSM fsm;
    private readonly int isAerialJump = Animator.StringToHash("isAerialJump");

    public override void Enter(PlayerFSM fsm)
    {
        this.fsm = fsm;
        animator.SetBool(isAerialJump, true);
        rigidbody.velocity = Vector2.zero;
        AerialJump();
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
        animator.SetBool(isAerialJump, false);
        PlayerStatus.PreviousState = PlayerState.BashJump;
    }

    void AerialJump()
    {
        StartCoroutine(MarioJump());
    }

    IEnumerator MarioJump()
    {
        float originTime = jumpTime;

        while (originTime > 0 || InputManager.Instance.isPress && PlayerStatus.CurrentState == PlayerState.AerialJump)
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
        PlayerStatus.CurrentState = PlayerState.BashJump;
        fsm.ChangeState(PlayerStatus.CurrentState);
    }
}
