using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// TODO : ���ǹ� �ܰ迡 ���� �̺�Ʈ ó��
public class CameraZoneSensor : MonoBehaviour
{
    [Header("[ Camera Zone Trigger Events ]")]
    [SerializeField] private UnityEvent OnCameraFixed;
    [SerializeField] private UnityEvent OnCameraUnfixed;
    [SerializeField] private UnityEvent OnChangeState;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "CameraFixedZone":
            {
                // ī�޶� �߾����� ����
                OnCameraFixed.Invoke();
                break;
            }
            case "CameraUnfixedZone":
            {
                // ī�޶� ���� ���� (�÷��̾� �ȷο�)
                OnCameraUnfixed.Invoke();
                break;
            }  
            case "PlayerDeadZone":
            {
                // ���� ���·� ��ü
                OnChangeState.Invoke();
                break;
            } 
        }
    }
}
