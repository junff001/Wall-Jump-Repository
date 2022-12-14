using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSensor : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            PlayerStatus.CurrentState = PlayerState.StickToWall;
        }
        else if (collision.gameObject.CompareTag("FlipWall"))
        {
            PlayerStatus.CurrentState = PlayerState.StickToWall;
           // player.GetComponent<Rigidbody2D>().isKinematic = true;

            if (collision.GetComponent<FlipWall>().isFliping)
            {
                StartCoroutine(Delay(collision));
            }
            else
            {
                collision.GetComponent<FlipWall>().player = player;
            }
        }
    }

    IEnumerator Delay(Collider2D collider)
    {
        yield return new WaitForSeconds(collider.GetComponent<FlipWall>().flipTime);
        collider.GetComponent<FlipWall>().player = player;
    }
}
