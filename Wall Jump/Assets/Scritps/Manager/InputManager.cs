using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    public int jumpingCount { get; set; } = 0;

    public void JumpingCountUp()
    {
        jumpingCount++;
        Debug.Log(jumpingCount);

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

        Debug.Log(PlayerStatus.CurrentState);
    }
}
