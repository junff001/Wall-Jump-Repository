using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    private int jumpingCount = 0;

    float a;
    //private void Start()
    //{
    //    a = Camera.main.orthographicSize;
    //    Camera.main.orthographicSize = Camera.main.orthographicSize * 0.5625f / (Screen.width / (float)Screen.height);
    //}

    //private void Update()
    //{
    //    Camera.main.orthographicSize =  a * 0.5625f / (Screen.width / (float)Screen.height);
    //}

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
