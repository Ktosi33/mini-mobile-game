using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBuyer : IBuyer
{
    private float money;
    public float CheckBalance()
    {
        return money;
    }
    
    public void PayOut(float value)
    {
        if(money - value >= 0) {
            money -= value;
        }
    }
}
