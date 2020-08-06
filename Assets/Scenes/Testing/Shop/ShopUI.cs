using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public DummyBuyer buyer;
    Shop shop;
    List<ShopItem> items;
    ShopItem currentItem;
    public Text itemTooltipText;
    public Text moneyText;

    public Button buyButton;

    Button[] buttons;

    private void updateMoney() {
         moneyText.text = $"GOLD: {buyer.CheckBalance().ToString()}";
    }
    private void Start()
    {
        updateMoney();
        buyButton.onClick.AddListener(() => {shop.BuyItem(currentItem, buyer);
                                             updateMoney();});
        shop = GetComponent<Shop>();
        shop.OnItemsChanged += RefreshItems;

        buttons = FindObjectsOfType<Button>().Where(btn => btn.name != "buybutton").ToArray();
        foreach (Button b in buttons)
        {
            Debug.Log(b.name);
        }
    }


    public void RefreshItems()
    {
        items = shop.GetAllItems();
        foreach (ShopItem item in items)
        {
            //Debug.Log($"Item {item.ItemName} loaded into ShopUI");
        }
        UpdateUI();
    }

    public void UpdateUI() {
        int itemIndex = 0;
        foreach (Button btn in buttons)
        {
            ShopItem currentItem = items[itemIndex++];
            //Debug.Log("Bound item: " + currentItem.ItemName + " to button: " + btn.name);
            btn.GetComponent<Image>().sprite = currentItem.Icon;
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => ChangeCurrentItem(currentItem));
            Text counter = btn.GetComponentsInChildren<Text>().Where(txt => txt.name != "Text").ToArray()[0];
            counter.text = currentItem.IsLimited ? currentItem.Stock.ToString() : "inf";
        }
    }

    public void ChangeCurrentItem(ShopItem item) {
        Debug.Log($"item {item.ItemName} is the current item");
        currentItem = item;
        ShowTooltip(item);
    }

    public void ShowTooltip(ShopItem item) {
        itemTooltipText.text = item.Tooltip;
    }
}
