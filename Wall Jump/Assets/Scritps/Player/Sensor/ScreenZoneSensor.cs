using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// TODO : 조건문 단계에 따라 이벤트 처리
public class ScreenZoneSensor : MonoBehaviour
{
    [Header("")]

    private UnityEvent m_CameraFixedEvent;
    private UnityEvent m_CameraUnfixedEvent;
    private UnityEvent m_PlayerDeadEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "CameraFixedZone":
            {
                // 카메라 중앙으로 고정
                m_CameraFixedEvent.Invoke();
                break;
            }
            case "CameraUnfixedZone":
            {
                // 카메라 고정 해제 (플레이어 팔로우)
                m_CameraUnfixedEvent.Invoke();
                break;
            }  
            case "PlayerDeadZone":
            {
                Player.Instance.currnetState = PlayerState.Death;
                break;
            } 
        }
    }
}
