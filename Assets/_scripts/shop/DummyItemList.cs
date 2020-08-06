using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyItemList : IItemDatabase
{
    public List<ShopItem> GetItems()
    {
        List<ShopItem> items = new List<ShopItem>();
        for(int i = 0; i < 5; i++)
        {
            items.Add(new ShopItem(null, $"item{i}", $"this is item number {i}", i * 5));
        }
        return items;
    }
}
