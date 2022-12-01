using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        ClampY();
    }

    void ClampY()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, transform.position.y, Mathf.Infinity), transform.position.z);
    }
}
