using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// TODO : ���ǹ� �ܰ迡 ���� �̺�Ʈ ó��
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
                // ī�޶� �߾����� ����
                m_CameraFixedEvent.Invoke();
                break;
            }
            case "CameraUnfixedZone":
            {
                // ī�޶� ���� ���� (�÷��̾� �ȷο�)
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
