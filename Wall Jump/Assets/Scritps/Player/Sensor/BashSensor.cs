using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BashSensor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bashable"))
        {
            //PlayerStatus.Bashable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bashable"))
        {
            //PlayerStatus.Bashable = false;
        }
    }
}
