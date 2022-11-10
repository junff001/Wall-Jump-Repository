using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    private int jumpingCount = 0;

    public void JumpingCountUp()
    {
        jumpingCount++;

        switch (jumpingCount)
        {
            case 1:
                PlayerStatus.CurrentState = PlayerState.Jump;
                break;
            case 2:
                PlayerStatus.CurrentState = PlayerState.AerialJump;
                break;
            case 3:
                PlayerStatus.CurrentState = PlayerState.BashJump;
                break;
        }
    }

    public void JumpingCountReset()
    {
        jumpingCount = 0;
    }
}
