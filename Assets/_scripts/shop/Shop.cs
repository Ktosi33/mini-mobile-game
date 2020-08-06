using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private bool logging = false;
    public IItemDatabase itemDatabase;
    private List<ShopItem> items;

    private void Start()
    {
        itemDatabase = GetComponent<DummyItemList>();
        LoadItems();
        CheckForUnlocks();
        OnItemsChanged();
    }

    private void LoadItems()
    {
        items = itemDatabase.GetItems();
        foreach (ShopItem item in items)
        {
            if(logging)
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
                OnItemsChanged();
                Debug.Log($"item {item.ItemName} bought");
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

    public List<ShopItem> GetAllItems() {
        return items;
    }

    public List<ShopItem> GetAvailableItems() {
        return items.Where(x => x.Stock != 0).ToList<ShopItem>();
    }

    public event Action OnItemsChanged;
}
