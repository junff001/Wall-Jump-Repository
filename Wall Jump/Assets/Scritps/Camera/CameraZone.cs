using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraZone : MonoBehaviour
{
    [Header("[ Events ]")]
    [SerializeField] private UnityEvent freezeCameraXAxis;
    [SerializeField] private UnityEvent unfreezeCameraXAxis;
    [SerializeField] private UnityEvent handlingPlayerDeaths;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "FreezeCameraXAxisZones":
            {
                freezeCameraXAxis.Invoke();
                break;
            } 
            case "UnfreezeCameraXAxisZones":
            {
                unfreezeCameraXAxis.Invoke();
                break;
            }
            case "PlayerDeathHandlingZones":
            {
                handlingPlayerDeaths.Invoke();
                break;
            }
        }
    }
}
