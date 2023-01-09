using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOutBounderay : MonoBehaviour
{
    [Header("[ Component Variables ]")]
    [SerializeField] private ProCamera2D proCamera;
    [SerializeField] private ProCamera2DTriggerBoundaries triggerBoundCenter;
    [SerializeField] private ProCamera2DTriggerBoundaries triggerBoundLeft;
    [SerializeField] private ProCamera2DTriggerBoundaries triggerBoundRight;

    private void Start()
    {
        triggerBoundCenter.enabled = false;

        triggerBoundLeft.OnEnteredTrigger += FollowXActiveTrueLeft;
        triggerBoundRight.OnEnteredTrigger += FollowXActiveTrueRight;
        triggerBoundCenter.OnEnteredTrigger += FollowXActiveFalse;
    }

    private void FollowXActiveTrueLeft()
    {
        triggerBoundCenter.enabled = true;
        proCamera.FollowHorizontal = true;
        triggerBoundLeft.enabled = false;
    }

    private void FollowXActiveTrueRight()
    {
        triggerBoundCenter.enabled = true;
        proCamera.FollowHorizontal = true;
        triggerBoundRight.enabled = false;
    }

    // 센터 컬라이더
    private void FollowXActiveFalse()
    {
        triggerBoundCenter.enabled = false;
        proCamera.FollowHorizontal = false;
        triggerBoundLeft.enabled = true;
        triggerBoundRight.enabled = true;
    }
}
