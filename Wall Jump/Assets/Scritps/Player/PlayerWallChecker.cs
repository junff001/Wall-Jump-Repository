using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent wallTouchedEvent;
    [SerializeField] private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
