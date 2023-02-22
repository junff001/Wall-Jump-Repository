using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// TODO : ���ǹ� �ܰ迡 ���� �̺�Ʈ ó��
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
                // ī�޶� �߾����� ����
                cameraFixedEvent.Invoke();
                break;
            }
            case "CameraUnfixedZone":
            {
                // ī�޶� ���� ���� (�÷��̾� �ȷο�)
                cameraUnfixedEvent.Invoke();
                break;
            }  
            case "PlayerDeadZone":
            {
                // ���� ���·� ��ü
                changeStateEvent.Invoke();
                break;
            } 
        }
    }
}
