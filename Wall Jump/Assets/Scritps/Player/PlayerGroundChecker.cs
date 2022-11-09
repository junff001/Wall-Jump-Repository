using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGroundChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent groundTouchedEvent;
    [SerializeField] private Animator animator;

    private readonly int isOnGround = Animator.StringToHash("isOnGround");

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerStatus.IsOnGround = true;
            PlayerStatus.IsJumping = false;
            PlayerStatus.JumpingCount = 0;

            animator.SetBool(isOnGround, PlayerStatus.IsOnGround);
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerStatus.IsOnGround = false;
        }
    }
}
