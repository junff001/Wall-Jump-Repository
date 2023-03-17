using Com.LuisPedroFonseca.ProCamera2D;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCameraXAxis : MonoBehaviour
{
    [Header("[ Camera-Related ]")]
    [SerializeField] private ProCamera2D proCamera;
    [SerializeField] private ProCamera2DCameraWindow proCameraWindow;
    [Space(10)]
    [SerializeField] private float cameraUnfreezingOffsetX;

    [Header("[ Collider-Related ]")]
    [SerializeField] private BoxCollider2D freezeCameraXAxisZoneCollider; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FreezingTheCameraXAxis();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnfreezingTheCameraXAxis();
        }
    }

    private void FreezingTheCameraXAxis()
    {
        this.transform.SetParent(proCamera.transform);

        float baselineX = freezeCameraXAxisZoneCollider.bounds.center.x;
        float currentPlayerPositionX = Player.Instance.transform.position.x;

        //if (baselineX < currentPlayerPositionX) proCamera.OffsetX = 
        //else if (baselineX > currentPlayerPositionX) proCamera.OffsetX = cameraUnfreezingOffsetX;

        proCamera.FollowHorizontal = false;
    }

    private void UnfreezingTheCameraXAxis()
    {
        this.transform.SetParent(null);

        float baselineX = freezeCameraXAxisZoneCollider.bounds.center.x;
        float currentPlayerPositionX = Player.Instance.transform.position.x;

        if (baselineX < currentPlayerPositionX) proCamera.OffsetX = -cameraUnfreezingOffsetX;
        else if (baselineX > currentPlayerPositionX) proCamera.OffsetX = cameraUnfreezingOffsetX;

        proCamera.FollowHorizontal = true;
    }
}
