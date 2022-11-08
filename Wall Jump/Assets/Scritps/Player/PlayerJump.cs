using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpPower;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite jumpSprite;
    [SerializeField] private Rigidbody2D rigidbody;

    public void Jump()
    {
        Debug.Log("มกวม");
        if (PlayerStatus.CanJumping && PlayerStatus.JumpingCount <= 0)
        {
            if (PlayerStatus.Direction == PlayerDirection.Left)
            {
                rigidbody.AddForce(new Vector2(-1, 1.5f) * jumpPower, ForceMode2D.Impulse);
            }
            else if (PlayerStatus.Direction == PlayerDirection.Right)
            {
                rigidbody.AddForce(new Vector2(1, 1.5f) * jumpPower, ForceMode2D.Impulse);
            }

            PlayerStatus.JumpingCount++;
        }
    }
}
