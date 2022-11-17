using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    public bool isPress { get; set; } = false;
    public bool isRelease { get; set; } = false;


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

    public void ScreenPress()
    {
        isPress = true;
        isRelease = false;     
    }

    public void ScreenRelease()
    {
        isRelease = true;
        isPress = false;
    }
}
