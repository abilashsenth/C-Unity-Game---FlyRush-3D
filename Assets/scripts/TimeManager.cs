using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;
    public bool timeStopped = false;

   

    void Update()
    {
        if (!timeStopped)
        {
            Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }else if (timeStopped)
        {
            Time.timeScale = 0f;
        }
    }

    public void doSlowMotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .2f;
    }

    public void doSlowMotionCollision()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .5f;

    }
    public void setTimeNormal()
    {
        Time.timeScale = 1;
    }

    public void stopTime()
    {
        timeStopped = true;
    }
}
