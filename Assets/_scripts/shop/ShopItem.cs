using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public ShopItem(Sprite _Icon, string _ItemName, string _Tooltip, float _Cost)
    {
        Icon = _Icon;
        ItemName = _ItemName;
        Cost = _Cost;
        IsLimited = false;
        unlockPredicate = new AlwaysUnlocked();
    }

    public ShopItem(Sprite _Icon, string _ItemName, string _Tooltip, float _Cost,
                    IShopUnlockPredicate _unlockPredicate)
    {
        Icon = _Icon;
        ItemName = _ItemName;
        Cost = _Cost;
        IsLimited = false;
        unlockPredicate = _unlockPredicate;
    }

    public ShopItem(Sprite _Icon, string _ItemName, string _Tooltip, float _Cost, int _Stock) :
               this( _Icon, _ItemName, _Tooltip, _Cost)
    {
        IsLimited = true;
        Stock = _Stock;
    }

    public ShopItem(Sprite _Icon, string _ItemName, string _Tooltip, float _Cost,
                    int _Stock, IShopUnlockPredicate _unlockPredicate) :
               this( _Icon, _ItemName, _Tooltip, _Cost, _unlockPredicate)
    {
        IsLimited = true;
        Stock = _Stock;
    }
    public Sprite Icon;
    public string ItemName;
    public string Tooltip;
    public float Cost;
    public bool IsUnlocked;
    private IShopUnlockPredicate unlockPredicate;
    public void CheckForUnlock()
    {
        IsUnlocked = unlockPredicate.Check();
    }

    public bool IsLimited;
    private int stock;
    public int Stock {
        get {
            if(IsLimited) {
                return stock;
            }
            else {
                return 1;
            }
        }
        set {
            if(value < 0) {
                Debug.Log("trying to set negative item stock: " + ItemName);
                stock = 0;
            }
            else {
                stock = value;
            }
        }
    }

    internal bool Buy() {
        if(!IsUnlocked || IsLimited && Stock < 1) {
            return false;
        }
        else
        {
            Stock -= 1;
            OnBought();
            return true;
        }
    }

    public event Action OnBought;
    
}
