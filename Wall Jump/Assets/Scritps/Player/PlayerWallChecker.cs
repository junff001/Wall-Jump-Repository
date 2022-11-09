using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent wallTouchedEvent;
    [SerializeField] private Animator animator;

    private readonly int isStickToWall = Animator.StringToHash("isStickToWall");

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            PlayerStatus.IsStickToWall = true;
            PlayerStatus.IsJumping = false;          
            PlayerStatus.JumpingCount = 0;

            animator.SetBool(isStickToWall, PlayerStatus.IsStickToWall);
            wallTouchedEvent.Invoke();

            Debug.Log(string.Format("{0} : IsJumping", PlayerStatus.IsJumping));
            Debug.Log(string.Format("{0} : IsOnGround", PlayerStatus.IsOnGround));
            Debug.Log(string.Format("{0} : IsStickToWall", PlayerStatus.IsStickToWall));
            Debug.Log(string.Format("{0} : JumpingCount", PlayerStatus.JumpingCount));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            PlayerStatus.IsStickToWall = false;
        }
    }
}
