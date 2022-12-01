using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBoundSensor : MonoBehaviour
{
    [SerializeField] private PlayerDeath playerDeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeadBound"))
        {
            playerDeath.Dead();
        }
    }
}
