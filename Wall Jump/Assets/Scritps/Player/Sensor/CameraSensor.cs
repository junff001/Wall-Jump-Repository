using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSensor : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private CinemachineVirtualCamera virtualCam;
    private CinemachineFramingTransposer cinemachineFramingTransposer;

    void Start()
    {
        cinemachineFramingTransposer = virtualCam.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerStatus.CurrentStickToWall != null)
        {
            Debug.Log(collision.transform.position);
            if (collision.transform.position.y > PlayerStatus.CurrentStickToWall.position.y)
            {
                CameraFraming(collision.transform);
            }
        }
    }

    void CameraFraming(Transform target)
    {
        float distance = target.position.x - player.position.x;
        cinemachineFramingTransposer.m_ScreenX += distance;
    }
}