using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBashJump : State
{
    [Header("[ Arrow ]")]
    [SerializeField] private GameObject arrowPivot;
    [SerializeField] private GameObject arrow;

    [Header("[ Bash ]")]
    [SerializeField] private float bashPower;
    [SerializeField] private float bashTime;

    [Header("[ Decelerate ]")]
    [SerializeField] private float decelerateTime;
    [SerializeField] private float decelerateSpeed;

    [Header("[ Component ]")]
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform player;

    private readonly int isBashJumping = Animator.StringToHash("isBashJumping");
   
    public override void Enter(PlayerFSM fsm)
    {
        StartCoroutine(BashJump());
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
        animator.SetBool(isBashJumping, false);
        StopCoroutine(BashJump());
    }

    IEnumerator BashJump()
    {
        TimeManager.Instance.SlowMotion();

        // Input.GetMouseButton(0)
        while (Input.GetMouseButton(0) && PlayerStatus.Bashable)
        {
            if (InputManager.Instance.isSwipe)
            {
                arrowPivot.SetActive(true);
            }

            yield return null;
        }

        arrowPivot.SetActive(false);
        TimeManager.Instance.TrunBackTime();

        // Input.GetMouseButtonUp(0)
        if (Input.GetMouseButtonUp(0) && InputManager.Instance.isSwipe)
        {
            animator.SetBool(isBashJumping, true);
            rigidbody.velocity = Vector2.zero;
            float defaultGravity = rigidbody.gravityScale;
            rigidbody.gravityScale = 0;

            float bashTimer = bashTime;
            while (bashTimer > 0)
            {
                bashTimer -= Time.deltaTime;
                rigidbody.velocity = InputManager.Instance.swipeDistance.normalized * bashPower;
                yield return null;
            }

            if (rigidbody.velocity.x > 0)
            {
                Debug.Log("¿À¸¥ÂÊ");
                rigidbody.transform.localScale = new Vector3(1, rigidbody.transform.localScale.y, rigidbody.transform.localScale.z);
                PlayerStatus.CurrentDirection = PlayerDirection.Right;

            }
            else if (rigidbody.velocity.x < 0)
            {
                Debug.Log("¿ÞÂÊ");
                rigidbody.transform.localScale = new Vector3(-1, rigidbody.transform.localScale.y, rigidbody.transform.localScale.z);
                PlayerStatus.CurrentDirection = PlayerDirection.Left;
            }

            rigidbody.gravityScale = defaultGravity;
            Vector2 startVelocity = rigidbody.velocity;
            Vector2 decelerate = InputManager.Instance.swipeDistance.normalized * decelerateSpeed;
            float currentTime = 0;

            while (currentTime < decelerateTime && PlayerStatus.CurrentState == PlayerState.BashJump)
            {
                currentTime += Time.deltaTime;

                if (currentTime >= decelerateTime)
                {
                    currentTime = decelerateTime;
                }

                rigidbody.velocity = Vector2.Lerp(startVelocity, decelerate, currentTime / decelerateTime);
                yield return null;
            }
        }
    }
}
