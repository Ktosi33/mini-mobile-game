using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    private static TimerManager instance;
    public static TimerManager Instance
    {
        get
        {
            return instance;
        }
    }

    // TODO: Consider changing lists to something different?
    private List<Timer> activeTimers;
    private List<Timer> timersToDisable;
    private float timeElapsedLastFrame;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        
        activeTimers = new List<Timer>();
        timersToDisable = new List<Timer>();
    }
    void Update()
    {
        timeElapsedLastFrame = Time.deltaTime;
        updateTimers();
    }

    private void updateTimers()
    {
        foreach (Timer timer in activeTimers)
        {
            timer.Update(timeElapsedLastFrame);
        }
        foreach (Timer timer in timersToDisable)
        {
            DisableTimer(timer);
        }
        timersToDisable.Clear();
    }

    public void ActivateTimer(Timer t)
    {
        if (!activeTimers.Contains(t))
        {
            activeTimers.Add(t);
        }
        //Debug.Log("Aktywnych timerow: " + activeTimers.Count);
    }

    public void DisableTimer(Timer t)
    {
        if (!activeTimers.Remove(t))
        {
            Debug.Log("Error removing timer");
        }
        //Debug.Log("Aktywnych timerow: " + activeTimers.Count);
    }


    // TODO: Consider changing lists to something different?   
    public void MarkTimerToBeDisabled(Timer t)
    {
        timersToDisable.Add(t);
    }
}
