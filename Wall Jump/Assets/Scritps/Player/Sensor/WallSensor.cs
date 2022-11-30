using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSensor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameManager.Instance.CurrentStickToWall = collision.transform;
            PlayerStatus.CurrentState = PlayerState.StickToWall;
        }
    }
}
