using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWallClear : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FlipWall"))
        {
            Debug.Log("��������");
            collision.GetComponent<FlipWall>().player = null;
        }
    }
}
