using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallSensor : MonoBehaviour
{
    [SerializeField] private UnityEvent stickToWallEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            PlayerStatus.CurrentState = PlayerState.StickToWall;
            PlayerStatus.JumpingCount = 0;
            stickToWallEvent.Invoke();
        }
    }
}
