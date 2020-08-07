using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyItemList : MonoBehaviour, IItemDatabase
{
    public Sprite[] sprites;
    public List<ShopItem> GetItems()
    {
        List<ShopItem> items = new List<ShopItem>();
        for(int i = 0; i < 3; i++)
        {
            string itemString = "item" + i + " OnBought() raised";
            items.Add(new ShopItem(sprites[i] , $"item{i}", $"this is item number {i}", i * 30,
                                   () => Debug.Log(itemString)));
        }
        for(int i = 3; i < 5; i++)
        {
            string itemString = "item" + i + " OnBought() raised";
            items.Add(new ShopItem(sprites[i] , $"item{i}", $"this is item number {i}", i * 5, 2 * i,
                      () => Debug.Log(itemString)));
        }
        return items;
    }
}
