using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private bool logging = false;
    private IItemDatabase itemDatabase = new DummyItemList();
    private List<ShopItem> items;

    private void Start()
    {
        LoadItems();
    }

    private void LoadItems()
    {
        items = itemDatabase.GetItems();
        foreach (ShopItem item in items)
        {
            Debug.Log("Loaded item: " + item.ItemName);
        }
    }

    public bool TryBuy(ShopItem item, IBuyer buyer)
    {
        if (!items.Contains(item))
        {
            if (logging) Debug.Log("no such item in shop: " + item.ItemName);
            return false;
        }
        if (item.Cost > buyer.CheckBalance())
        {
            if (logging) Debug.Log("buyer cant afford this item: " + buyer.ToString() + " -> " + item.ItemName);
            return false;
        }
        return true;
    }

    public bool BuyItem(ShopItem item, IBuyer buyer)
    {
        if (TryBuy(item, buyer))
        {
            if (item.Buy())
            {
                buyer.PayOut(item.Cost);
                items.Remove(item);
                return true;
            }
            else if (logging){
                Debug.Log("item out of stock or locked: " + item.ItemName + " stock: " +
                           item.Stock + " lock: " + item.IsUnlocked);
            }
        }
        return false;

    }

    public void CheckForUnlocks()
    {
        foreach (ShopItem item in items)
        {
            item.CheckForUnlock();
        }
    }

}
