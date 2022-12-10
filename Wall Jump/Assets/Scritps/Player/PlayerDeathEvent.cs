using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerDeathEvent : MonoBehaviour
{
    [SerializeField] private PlayerPhysic physic;
    [SerializeField] private Transform player;
    [SerializeField] private Transform camera;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private CinemachineFramingTransposer framingTransposer;

    private Vector2 startCameraPos;

    void Start()
    {
        framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        startCameraPos = camera.position;
    }

    public void Dead()
    {
        player.position = respawnPoint.position;
        camera.position = startCameraPos;
        framingTransposer.m_TrackedObjectOffset.y = -6;
    }
}
