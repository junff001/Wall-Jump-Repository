using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraFraming : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private CinemachineFramingTransposer framingTransposer;
    private CinemachineSmoothPath smoothPath;
    private Array array;

    void Start()
    {
        framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    public void Framing(float distance)
    {
        //smoothPath.m_Waypoints.ToList().Add()
        framingTransposer.m_ScreenX += distance * 0.1f;
    }
}
