using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    [SerializeField] private PlayerStickToWall playerStickToWall;
    [SerializeField] private float moveHeight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerStatus.CurrentState = PlayerState.OnGround;
        }
       
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (PlayerStatus.CurrentState == PlayerState.BasicJump || PlayerStatus.CurrentState == PlayerState.AerialJump)
            {
                StartCoroutine(playerStickToWall.MoveToTheWall(collision));
            }
            
        }
    }
}
