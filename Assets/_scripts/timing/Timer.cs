using System;
using UnityEngine;

public class Timer
{
    private TimerManager TimerManager;
    private float counter;
    private float initialCounter;
    private float timeScale = 1f;

    private bool isRepeatable;
    public bool IsRunning = false;

    public Timer(float time, bool _isRepeatable)
    {
        TimerManager = TimerManager.Instance;

        if (time > 0)
        {
            initialCounter = time;
        }
        else
        {
            Debug.Log("wrong inital time ctor: " + time);
            initialCounter = 0;
        }

        counter = initialCounter;
        isRepeatable = _isRepeatable;

        if (isRepeatable)
        {
            OnElapsed += this.Reset;
        }
        else
        {
            OnElapsed += this.Stop;
        }
    }
    public void Run()
    {
        if (counter > 0)
        {
            TimerManager.ActivateTimer(this);
        }
        else
        {
            Debug.Log("Trying to activate timer with <= 0 time");
        }
        IsRunning = true;
    }
    public void Stop()
    {
        TimerManager.MarkTimerToBeDisabled(this);
        IsRunning = false;
    }
    public void Reset()
    {
        counter = initialCounter;
        Run();
    }

    public void Update(float timeElapsed)
    {
        if (timeElapsed >= 0)
        {
            counter -= timeElapsed * timeScale;
        }
        else
        {
            Debug.Log("Invalid timer update: " + timeElapsed);
        }

        if (counter <= 0)
        {
            OnElapsed();
        }
    }

    public void SetTimeScale(float _timeScale)
    {
        if (_timeScale >= 0)
        {
            timeScale = _timeScale;
        }
    }

    public float GetTime()
    {
        return counter;
    }

    public void SetResetTime(float time)
    {
        if(time > 0) {
            initialCounter = time;
        }
        else {
            Debug.Log("Wrong initial time:" + initialCounter);
        } 
    }
    public event Action OnElapsed;
}

