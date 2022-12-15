using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSensor : MonoBehaviour
{
    [SerializeField] private BoxCollider2D groundCol;
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
            transform.GetComponent<BoxCollider2D>().enabled = false;
            groundCol.enabled = false;

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
