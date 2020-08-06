using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysUnlocked : IShopUnlockPredicate
{
    public bool Check()
    {
        return true;
    }
}
