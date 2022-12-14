using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWallClear : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FlipWall"))
        {
            Debug.Log("빠져나감");
            collision.GetComponent<FlipWall>().player = null;
        }
    }
}
