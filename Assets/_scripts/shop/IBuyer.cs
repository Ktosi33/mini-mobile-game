using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuyer
{
    void PayOut(float value);
    float CheckBalance();
}
