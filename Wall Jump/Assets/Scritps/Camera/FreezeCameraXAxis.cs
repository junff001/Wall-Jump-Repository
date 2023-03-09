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
        Debug.Log("고정");

        // ProCamera 고정해제하는 설정
        proCamera.FollowHorizontal = false;
        proCamera.transform.position = new Vector3(0f, proCamera.transform.position.y, proCamera.transform.position.z);

        // 같은 역할을 하는 컬라이더에 추가로 걸리지 않도록 방지
        freezeCameraXAxisZone.enabled = false;
        unfreezeCameraXAxisZoneLeft.enabled = true;
        unfreezeCameraXAxisZoneRight.enabled = true;
    }
}
