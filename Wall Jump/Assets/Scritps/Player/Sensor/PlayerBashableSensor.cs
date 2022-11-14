using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBashableSensor : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bashable"))
        {
            PlayerStatus.CanBashAim = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bashable"))
        {
            PlayerStatus.CanBashAim = false;
        }
    }
}
