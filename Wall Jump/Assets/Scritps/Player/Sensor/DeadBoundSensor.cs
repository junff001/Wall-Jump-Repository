using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBoundSensor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadBound"))
        {
            Debug.Log("Á×À½¿¡ ´êÀ½");
            PlayerStatus.CurrentState = PlayerState.Death;
        }
    }
}
