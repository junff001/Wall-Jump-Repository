using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FlipWall"))
        {
            player.SetParent(collision.transform);
            PlayerStatus.CurrentState = PlayerState.StickToWall;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FlipWall"))
        {
            player.SetParent(null);
        }
    }
}
