using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBuyer : MonoBehaviour , IBuyer
{
    private float money = 500;
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
