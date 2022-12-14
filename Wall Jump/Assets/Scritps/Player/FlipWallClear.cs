using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWallClear : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FlipWall"))
        {
            player.GetComponent<Rigidbody2D>().isKinematic = false;
            collision.GetComponent<FlipWall>().player = null;
        }
    }
}
