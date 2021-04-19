using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item  
{
    private string id;
    private string name;
    private string description;
    private int healValue;
    private int buyPrice;
    private int sellPrice;
    private int amount;
    private List<Dictionary<string, string>> itemTable = new List<Dictionary<string, string>>();

    public Item() { }

    public Item(string inputID)
    {
        itemTable = GameInformation.itemTable;
        for (int i = 0; i < itemTable.Count; i++)
        {
            string tempID;
            string type;
            string sellPriceString;
            string buyPriceString;
            itemTable[i].TryGetValue("ID", out tempID);
            if (tempID == inputID)
            {
                itemTable[i].TryGetValue("Name", out name);
                itemTable[i].TryGetValue("Description", out description);

                itemTable[i].TryGetValue("SellPrice", out sellPriceString);
                itemTable[i].TryGetValue("Type", out type);
                itemTable[i].TryGetValue("BuyPrice", out buyPriceString);

                id = inputID;
                sellPrice = int.Parse(sellPriceString);
                buyPrice = int.Parse(buyPriceString);
                amount = 1;

                switch (type)
                {
                    case "Health":
                        itemType = Item.ItemType.HEALTH;
                        AssignHealValue();
                        break;
                    case "Mana":
                        itemType = Item.ItemType.MANA;
                        AssignHealValue();
                        break;
                    case "Miscellaneous":
                        itemType = Item.ItemType.MISCELLANEOUS;
                        break;
                    case "Special":
                        itemType = Item.ItemType.SPECIAL;
                        AssignHealValue();
                        break;
                    case "Status":
                        itemType = Item.ItemType.STATUS;
                        break;
                    case "Gift":
                        itemType = Item.ItemType.GIFT;
                        break;
                }
            }
        }
    }

    public enum ItemType
    {
        HEALTH,
        MANA,
        SPECIAL,
        STATUS,
        MISCELLANEOUS,
        GIFT
    }
    private ItemType itemType;

    public string ID
    {
        set { id = value; }
        get { return id; }
    }

    public string Name
    {
        set { name = value; }
        get { return name; }
    }

    public string Description
    {
        set { description = value; }
        get { return description; }
    }

    public int HealValue
    {
        set { healValue = value; }
        get { return healValue; }
    }

    public int BuyPrice
    {
        set { buyPrice = value; }
        get { return buyPrice; }
    }

    public int SellPrice
    {
        set { sellPrice = value; }
        get { return sellPrice; }
    }

    public ItemType ItemTypeValue
    {
        set { itemType = value; }
        get { return itemType; }
    }

    public int Heal(int value)
    {
        int heal = value * healValue / 100;
        return heal ;
    }

    public int Amount
    {
        set { amount = value; }
        get { return amount; }
    }

    public void AssignHealValue()
    {
        if (id == "IT01" || id == "IT04")
        {
            healValue = 30;
        }
        else if (id == "IT11")
        {
            healValue = 50;
        }
        else if (id == "IT02" || id == "IT05")
        {
            healValue = 60;
        }
        else if (id == "IT03" || id == "IT06" || id == "IT10" || id == "IT12")
        {
            healValue = 100;
        }
    }
}
