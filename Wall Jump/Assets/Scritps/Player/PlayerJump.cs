using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private float jumpPower;

    /// <summary>
    /// 땅과 벽에서 점프하는 함수
    /// LocalScale.x 의 방향에 따라 점프 방향이 달라짐
    /// </summary>
    public void Jump()
    {
        if (PlayerStatus.CanJumping)
        {
            if (transform.localScale.x == 1)
            {
                rigid.AddForce(new Vector2(1, 1.5f) * jumpPower, ForceMode2D.Impulse);
            }
            else if (transform.localScale.x == -1)
            {
                rigid.AddForce(new Vector2(-1, 1.5f) * jumpPower, ForceMode2D.Impulse);
            }
        } 
    }
}
