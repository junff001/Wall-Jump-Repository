using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBashableSensor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bashable"))
        {
            Debug.Log("배쉬 가능");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bashable"))
        {
            Debug.Log("배쉬 불가능");
        }
    }
}
