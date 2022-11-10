using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGroundSensor : MonoBehaviour
{
    [SerializeField] private UnityEvent groundTouchedEvent;
    [SerializeField] private Animator animator;

    private readonly int isOnGround = Animator.StringToHash("isOnGround");

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerStatus.CurrentState = PlayerState.Idle;
        } 
    }
}
