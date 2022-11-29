using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPath : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtual;
    private CinemachineTrackedDolly cinemachineTracked;

    void Start()
    {
        cinemachineTracked = cinemachineVirtual.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.gameObject.CompareTag("CameraCollider"))
        {
            Debug.Log("asdfdas");
            PathSetting(collision.GetComponent<CinemachineSmoothPath>());
        }
    }

    void PathSetting(CinemachineSmoothPath path)
    {
        cinemachineTracked.m_Path = path;
    }
}
