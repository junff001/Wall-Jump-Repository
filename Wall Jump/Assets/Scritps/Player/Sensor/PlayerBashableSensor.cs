using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBashableSensor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bashable"))
        {
            Debug.Log("�转 ����");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bashable"))
        {
            Debug.Log("�转 �Ұ���");
        }
    }
}
