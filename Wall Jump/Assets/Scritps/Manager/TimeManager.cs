using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoSingleton<TimeManager>
{
    public float slowDownFactor;

    public void SlowMotion()
    {
        //Time.timeScale = 0;
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void TrunBackTime()
    {
        Time.timeScale = 1f;
    }
}
