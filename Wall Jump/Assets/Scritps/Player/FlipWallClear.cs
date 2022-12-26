using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWallClear : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private BoxCollider2D groundCol;
    [SerializeField] private BoxCollider2D wallCol;
    [SerializeField] private CircleCollider2D deadBoundCol;

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("FlipWall"))
        //{
        //    Debug.Log("빠져나감");
        //    groundCol.enabled = true;
        //    wallCol.enabled = true;
        //    deadBoundCol.enabled = true;
        //    collision.GetComponent<FlipWall>().player = null;
        //}
        //else if (collision.gameObject.CompareTag("FlipSpikeWall"))
        //{
        //    Debug.Log("빠져나감");
        //    groundCol.enabled = true;
        //    wallCol.enabled = true;
        //    deadBoundCol.enabled = true;
        //    collision.GetComponent<FlilpSpikeWall>().player = null;
        //}
    }
}
