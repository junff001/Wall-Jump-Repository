using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSensor : MonoBehaviour
{
    [SerializeField] private BoxCollider2D groundCol;
    [SerializeField] private CircleCollider2D deadBoundCol;
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
            deadBoundCol.enabled = false;

            if (collision.GetComponent<FlipWall>().isFliping)
            {
                StartCoroutine(FlipWallDelay(collision));
            }
            else
            {
                collision.GetComponent<FlipWall>().player = player;
            }
        }
        else if (collision.gameObject.CompareTag("FlipSpikeWall"))
        {
            PlayerStatus.CurrentState = PlayerState.StickToWall;
            transform.GetComponent<BoxCollider2D>().enabled = false;
            groundCol.enabled = false;

            if (collision.GetComponent<FlilpSpikeWall>().isFliping)
            {
                StartCoroutine(FlipSpikeWallDelay(collision));
            }
            else
            {
                collision.GetComponent<FlilpSpikeWall>().player = player;
            }
        }
    }

    IEnumerator FlipSpikeWallDelay(Collider2D collider)
    {
        yield return new WaitForSeconds(collider.GetComponent<FlilpSpikeWall>().flipTime);
        collider.GetComponent<FlilpSpikeWall>().player = player;
    }

    IEnumerator FlipWallDelay(Collider2D collider)
    {
        yield return new WaitForSeconds(collider.GetComponent<FlipWall>().flipTime);
        collider.GetComponent<FlipWall>().player = player;
    }
}
