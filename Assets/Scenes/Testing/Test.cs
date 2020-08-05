using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{



    // testowy kod :)
    public float CzasZwyklegoTimera = 5f;
    public float CzasRepeatTimera = 3f;
    Timer a;
    public Text text;
    public List<Timer> timers;
    TimerManager tm;

    private void Start()
    {
        tm = GetComponent<TimerManager>();
        timers = new List<Timer>();
    }

    private void Update()
    {
        bool a1 = Input.GetKeyDown(KeyCode.A);
        bool a2 = Input.GetKeyDown(KeyCode.S);
        if (a1)
        {
            timers.Add(tm.CreateTimer(CzasZwyklegoTimera, false));
            timers.Last().Run();
            a = timers.Last();
            timers.Last().OnElapsed += foo;
        }
        if (a2)
        {
            timers.Add(tm.CreateTimer(CzasRepeatTimera, true));
            timers.Last().Run();
            a = timers.Last();
            timers.Last().OnElapsed += foo;
        }

        text.text = "";
        foreach (Timer t in timers)
        {
            text.text += t.GetTime().ToString() + "\n";
        }
       // Debug.Log(timers.Count);
    }

    void foo() {
        Debug.Log("Timer finished");
    }
    
}
