using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWallClear : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private BoxCollider2D groundCol;
    [SerializeField] private BoxCollider2D wallCol;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FlipWall"))
        {
            groundCol.enabled = true;
            wallCol.enabled = true;
            player.GetComponent<Rigidbody2D>().isKinematic = false;
            collision.GetComponent<FlipWall>().player = null;
        }
    }
}
