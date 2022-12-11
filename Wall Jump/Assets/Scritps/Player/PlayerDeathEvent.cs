using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerDeathEvent : MonoBehaviour
{
    public void PostDeathEvent()
    {
        GameManager.Instance.PlayerRespawn();
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1f);
        InputManager.Instance.isStart = true;
    }
}
