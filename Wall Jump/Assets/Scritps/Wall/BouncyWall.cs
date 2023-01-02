using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyWall : MonoBehaviour
{
    [Header("[ Bounces Variables ]")]
    [SerializeField] private float bouncesOffDegree;
    private readonly int isJumping = Animator.StringToHash("isJumping");
    private readonly int isAerialJumping = Animator.StringToHash("isAerialJumping");

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.directionOfView.ReverseView();
            Player.Instance.animator.SetBool(isAerialJumping, false);
            Player.Instance.animator.SetBool(isJumping, true);
            Player.Instance.physic.VelocityZero();
            PlayerBouncesOff();
        }
    }

    // FSM 상태 변환 
    // 튕겨나감는 힘 코루틴 while로 적용해야 함

    private void PlayerBouncesOff()
    {
        if (Player.Instance.currentDirection == PlayerDirection.Right)
        {
            Vector2 direction = new Vector2(1, 1.75f);
            Player.Instance.physic.SetVelocity(direction * bouncesOffDegree);
        }
        else if (Player.Instance.currentDirection == PlayerDirection.Left)
        {
            Vector2 direction = new Vector2(-1, 1.75f);
            Player.Instance.physic.SetVelocity(direction * bouncesOffDegree);
        }
    }
}
