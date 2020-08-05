using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _cooldown 
{
    public bool isWaitingF;
    public _cooldown() { isWaitingF = false; }

   
    public void wait(float seconds)
    {
        this.isWaitingF = true;
        float counter = seconds;
     
      
        while (counter>0)
        {
            counter -= Time.deltaTime;
        }
        this.isWaitingF = false;


    }

    public bool isWaiting()
    {
        
        return isWaitingF;
    }
}
