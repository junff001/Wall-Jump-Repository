using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoSingleton<TimeManager>
{
    public float slowDownFactor;
    public float slowMotionTime;

    public void SlowMotion()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public IEnumerator SlowTimer()
    {
        float timer = slowMotionTime;

        while (timer > 0 || !InputManager.Instance.isRelease)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
    }

    public void TrunBackTime()
    {
        Time.timeScale = 1f;
    }
}
