using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraPathSensor : MonoBehaviour
{
    [SerializeField] private CinemachineSmoothPath cinemachineSmoothPath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CameraCollider"))
        {
            CinemachineSmoothPath newPath = collision.GetComponent<CinemachineSmoothPath>();
            cinemachineSmoothPath.m_Waypoints[cinemachineSmoothPath.m_Waypoints.Length - 1].position = new Vector3(0, 30, -5);
  
        }
    }
}
