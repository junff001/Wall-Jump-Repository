using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAerialJumpChecker : MonoBehaviour
{
    void Update()
    {
        if (PlayerStatus.CurrentState == PlayerState.Jump && InputManager.Instance.isPress)
        {
            PlayerStatus.CurrentState = PlayerState.AerialJump;
        }
    }
}
