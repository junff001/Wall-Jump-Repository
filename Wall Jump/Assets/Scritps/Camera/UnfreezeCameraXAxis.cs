using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfreezeCameraXAxis : MonoBehaviour
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
            UnfreezingTheCameraXAxis();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FreezingTheCameraXAxis();
        }
    }

    private void FreezingTheCameraXAxis()
    {
        Debug.Log("고정");

        proCamera.transform.position = new Vector3(0f, proCamera.transform.position.y, proCamera.transform.position.z);
        proCamera.OffsetX = 0;

        proCamera.FollowHorizontal = false;
    }

    private void UnfreezingTheCameraXAxis()
    {
        Debug.Log("고정해제");

        proCamera.FollowHorizontal = true;
        if (Player.Instance.transform.position.x > 0)
        {
            proCamera.OffsetX = -0.55f;
        }
        else if (Player.Instance.transform.position.x < 0)
        {
            proCamera.OffsetX = 0.55f;
        }
        

        // 같은 역할을 하는 컬라이더에 추가로 걸리지 않도록 방지
        //freezeCameraXAxisZone.enabled = true;
        //unfreezeCameraXAxisZoneLeft.enabled = false;
        //unfreezeCameraXAxisZoneRight.enabled = false;
    }
}
