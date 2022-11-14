using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpChecker : MonoBehaviour
{
    void Update()
    {
        if (PlayerStatus.CurrentState == PlayerState.Idle && InputManager.Instance.isPress)
        {
            PlayerStatus.CurrentState = PlayerState.Jump;
        }
    }
}
