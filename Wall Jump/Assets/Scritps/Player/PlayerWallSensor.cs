using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallSensor : MonoBehaviour
{
    [SerializeField] private UnityEvent wallTouchedEvent;
    [SerializeField] private Animator animator;

    private readonly int isStickToWall = Animator.StringToHash("isStickToWall");

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            PlayerStatus.CurrentState = PlayerState.StickToWall;
        }
    }
}
