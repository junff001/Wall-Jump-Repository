using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFreeFollow : MonoBehaviour
{
    [Header("[ Component Variables ]")]
    [SerializeField] private ProCamera2D proCamera;
    [SerializeField] private CameraZone fixation;
    [SerializeField] private Transform player;
    private float offset;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnFreeFollow();
        }
    }

    private void OnFreeFollow()
    {
        fixation.transform.parent = null;
        offset = player.position.x * -1f;
        //proCamera.CameraTargets[0].TargetOffset.x = offset;
        proCamera.FollowHorizontal = true;
    }
}
