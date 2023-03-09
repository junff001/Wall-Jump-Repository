using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeCameraXAxis : MonoBehaviour
{
    [Header("[ Camera-Related ]")]
    [SerializeField] private ProCamera2D proCamera;

    [Header("[ Collider-Related ]")]
    [SerializeField] private BoxCollider2D freezeCameraXAxisZone;
    [SerializeField] private BoxCollider2D unfreezeCameraXAxisZoneLeft;
    [SerializeField] private BoxCollider2D unfreezeCameraXAxisZoneRight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FreezingTheCameraXAxis();
        }
    }

    private void FreezingTheCameraXAxis()
    {
        Debug.Log("����");

        // ProCamera ���������ϴ� ����
        proCamera.FollowHorizontal = false;
        proCamera.transform.position = new Vector3(0f, proCamera.transform.position.y, proCamera.transform.position.z);

        // ���� ������ �ϴ� �ö��̴��� �߰��� �ɸ��� �ʵ��� ����
        freezeCameraXAxisZone.enabled = false;
        unfreezeCameraXAxisZoneLeft.enabled = true;
        unfreezeCameraXAxisZoneRight.enabled = true;
    }
}
