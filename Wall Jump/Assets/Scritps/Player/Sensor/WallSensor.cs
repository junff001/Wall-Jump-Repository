using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSensor : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag) 
        {
            case "Wall":
            {
                PlayerStatus.IsTouchedSideWall = true;
                PlayerStatus.CurrentState = PlayerState.StickToWall;
                player.SetParent(collision.transform);
                break;
            } 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
            {
                Debug.Log("³ª°¨");
                PlayerStatus.IsTouchedSideWall = false;
                player.SetParent(null);
                break;
            }
        }
    }
}
