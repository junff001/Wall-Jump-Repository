using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallChecker : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;

    void Update()
    {
        if (PlayerStatus.CurrentState == PlayerState.Jump)
        {
            if (rigidbody.velocity.y < 0)
            {
                PlayerStatus.CurrentState = PlayerState.Fall;
            }
        }
    }
}
