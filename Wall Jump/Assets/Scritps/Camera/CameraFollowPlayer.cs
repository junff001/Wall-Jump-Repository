using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Update()
    {
        if (player.position.y > transform.position.y)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }

        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
