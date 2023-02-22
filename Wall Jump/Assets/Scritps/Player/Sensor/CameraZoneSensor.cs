using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// TODO : 조건문 단계에 따라 이벤트 처리
public class CameraZoneSensor : MonoBehaviour
{
    [Header("[ Camera Zone Trigger Events ]")]
    [SerializeField] private UnityEvent cameraFixedEvent;
    [SerializeField] private UnityEvent cameraUnfixedEvent;
    [SerializeField] private UnityEvent changeStateEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "CameraFixedZone":
            {
                // 카메라 중앙으로 고정
                cameraFixedEvent.Invoke();
                break;
            }
            case "CameraUnfixedZone":
            {
                // 카메라 고정 해제 (플레이어 팔로우)
                cameraUnfixedEvent.Invoke();
                break;
            }  
            case "PlayerDeadZone":
            {
                // 죽음 상태로 교체
                changeStateEvent.Invoke();
                break;
            } 
        }
    }
}
