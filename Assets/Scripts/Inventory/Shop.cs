using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shop : MonoBehaviour 
{
    private List<Item> shopList;
    private List<Dictionary<string, string>> itemTable;
    private int gold;
    private bool isBuy = false;
    private bool isSell = false;
    private Vector2 buyScrollPosition = Vector2.zero;
    private Vector2 sellScrollPosition = Vector2.zero;

	void Start () 
    {
        //GameInformation.Gold = 10000;
        itemTable = GameInformation.itemTable;
        shopList = new List<Item>();
        //Debug.Log(itemTable.Count);
        //Debug.Log("before sholist");
        for (int i = 0; i < itemTable.Count; i++)
        {
            string buyPriceString;
            itemTable[i].TryGetValue("BuyPrice", out buyPriceString);
            int buyPrice = int.Parse(buyPriceString);
            //Debug.Log("validate itme");
            if (buyPrice != 0)
            {
                //Debug.Log("buyable item");
                Item item = new Item();
                string id;
                string name;
                string description;
                string sellPriceString;
                string type;
                itemTable[i].TryGetValue("ID", out id);
                itemTable[i].TryGetValue("Name", out name);
                itemTable[i].TryGetValue("Description", out description);
                itemTable[i].TryGetValue("SellPrice", out sellPriceString);
                itemTable[i].TryGetValue("Type", out type);
                item.ID = id;
                item.Name = name;
                item.Description = description;
                item.BuyPrice = buyPrice;
                item.SellPrice = int.Parse(sellPriceString);
                item.Amount = 1;
                switch(type)
                {
                    case "Health":
                        item.ItemTypeValue = Item.ItemType.HEALTH;
                        item.AssignHealValue();
                        break;
                    case "Mana":
                        item.ItemTypeValue = Item.ItemType.MANA;
                        item.AssignHealValue();
                        break;
                    case "Miscellaneous":
                        item.ItemTypeValue = Item.ItemType.MISCELLANEOUS;
                        break;
                    case "Special":
                        item.ItemTypeValue = Item.ItemType.SPECIAL;
                        item.AssignHealValue();
                        break;
                    case "Status":
                        item.ItemTypeValue = Item.ItemType.STATUS;
                        break;
                    case "Gift":
                        item.ItemTypeValue = Item.ItemType.GIFT;
                        break;
                }
                shopList.Add(item);
            }
        }
        //Debug.Log("after shoplist");
        //for (int i = 0; i < shopList.Count; i++)
        //{
            //Debug.Log("test");
            //Debug.Log("item name : " + shopList[i].Name + " Buy Price : " + shopList[i].BuyPrice);
        //}
	}
	
	void Update () 
    {
        gold = GameInformation.Gold;
        //Debug.Log("amount potion : " + shopList[0].Amount); 
	}

    void OnGUI()
    {
        GUI.skin.button.wordWrap = true;
        ShowGold();
        ShowShopMenu();
        ShowShopList();
        ShowSellList();
        ShowReturnButton();
        ShowDialogBox();
    }

    private void ShowSellList()
    {
        if(isBuy == false && isSell == true)
        {
            int usableCount = GameInformation.usableInventory.Count;
            int miscCount = GameInformation.miscInventory.Count;
            int giftCount = GameInformation.giftInventory.Count;
            int height = (usableCount + miscCount + giftCount) * 80 + 30;
            GUI.BeginGroup(new Rect(0.1f * Screen.width, 0.05f * Screen.height, 0.6f * Screen.width, 0.6f * Screen.height));
            GUI.Box(new Rect(0, 0, 0.6f * Screen.width, 0.6f * Screen.height), "");
            sellScrollPosition = GUI.BeginScrollView(new Rect(20, 20, 0.6f * Screen.width - 40, 0.6f * Screen.height - 40), sellScrollPosition, new Rect(0, 0, 550, height));
            for (int i = 0; i < GameInformation.usableInventory.Count; i++)
            {
                GUI.Label(new Rect(20, i * 80 + 25, 200, 20), GameInformation.usableInventory[i].Name);
                GUI.Label(new Rect(240, i * 80 + 25, 50, 20), GameInformation.usableInventory[i].SellPrice + " G");
                GUI.Label(new Rect(310, i * 80 + 25, 100, 20), "Owned : "+GameInformation.usableInventory[i].Amount );
                GUI.Label(new Rect(20, i * 80 + 65, 500, 20), GameInformation.usableInventory[i].Description);
                if (GUI.Button(new Rect(430, i * 80 + 20, 100, 30), "Sell"))
                {
                    GameInformation.usableInventory[i].Amount -= 1;
                    GameInformation.Gold += GameInformation.usableInventory[i].SellPrice;
                    if (GameInformation.usableInventory[i].Amount == 0)
                    {
                        GameInformation.usableInventory.RemoveAt(i);
                    }
                }
            }
            int usableHeight = usableCount * 80 + 25;
            for (int i = 0; i < GameInformation.miscInventory.Count; i++)
            {
                GUI.Label(new Rect(20, i * 80 + usableHeight, 200, 20), GameInformation.miscInventory[i].Name);
                GUI.Label(new Rect(240, i * 80 + usableHeight, 50, 20), GameInformation.miscInventory[i].SellPrice + " G");
                GUI.Label(new Rect(310, i * 80 + usableHeight, 100, 20), "Owned : " + GameInformation.miscInventory[i].Amount);
                GUI.Label(new Rect(20, i * 80 + usableHeight + 40, 500, 20), GameInformation.miscInventory[i].Description);
                if (GUI.Button(new Rect(430, i * 80 + usableHeight - 5, 100, 30), "Sell"))
                {
                    GameInformation.miscInventory[i].Amount -= 1;
                    GameInformation.Gold += GameInformation.miscInventory[i].SellPrice;
                    if (GameInformation.miscInventory[i].Amount == 0)
                    {
                        GameInformation.miscInventory.RemoveAt(i);
                    }
                }
            }
            int miscHeight = miscCount * 80 + usableHeight;
            for (int i = 0; i < GameInformation.giftInventory.Count; i++)
            {
                GUI.Label(new Rect(20, i * 80 + miscHeight, 200, 20), GameInformation.giftInventory[i].Name);
                GUI.Label(new Rect(240, i * 80 + miscHeight, 50, 20), GameInformation.giftInventory[i].SellPrice + " G");
                GUI.Label(new Rect(310, i * 80 + miscHeight, 100, 20), "Owned : " + GameInformation.giftInventory[i].Amount);
                GUI.Label(new Rect(20, i * 80 + miscHeight + 40, 500, 20), GameInformation.giftInventory[i].Description);
                if (GUI.Button(new Rect(430, i * 80 + miscHeight - 5, 100, 30), "Sell"))
                {
                    GameInformation.giftInventory[i].Amount -= 1;
                    GameInformation.Gold += GameInformation.giftInventory[i].SellPrice;
                    if (GameInformation.giftInventory[i].Amount == 0)
                    {
                        GameInformation.giftInventory.RemoveAt(i);
                    }
                }
            }
            GUI.EndScrollView();
            GUI.EndGroup();
        }
    }

    private void ShowShopList()
    {
        if (isBuy == true && isSell == false)
        {
            int usableCount = GameInformation.usableInventory.Count;
            int miscCount = GameInformation.miscInventory.Count;
            int giftCount = GameInformation.giftInventory.Count;
            int height = shopList.Count * 80 + 30;
            bool hasItem = false;
            Item newItem;
            int index = 0;
            GUI.BeginGroup(new Rect(0.1f * Screen.width, 0.05f * Screen.height, 0.6f * Screen.width, 0.6f * Screen.height));
            GUI.Box(new Rect(0, 0, 0.6f * Screen.width, 0.6f * Screen.height), "");
            buyScrollPosition = GUI.BeginScrollView(new Rect(20, 20, 0.6f * Screen.width - 40, 0.6f * Screen.height - 40), buyScrollPosition, new Rect(0, 0, 430, height));
            for (int i = 0; i < shopList.Count; i++)
            {
                if (shopList[i].Amount == 0)
                {
                    shopList[i].Amount = 1;
                }
                GUI.Label(new Rect(20, i * 80 + 25, 200, 20), shopList[i].Name);
                GUI.Label(new Rect(240, i * 80 + 25, 50, 20), shopList[i].BuyPrice+" G");
                GUI.Label(new Rect(20, i * 80 + 65, 500, 20), shopList[i].Description);
                if (GameInformation.Gold >= shopList[i].BuyPrice)
                {
                    if (GUI.Button(new Rect(310, i * 80 + 20, 100, 30), "Buy"))
                    {
                        //Debug.Log("Buy " + shopList[i].Name);
                        if(shopList[i].ItemTypeValue == Item.ItemType.GIFT)
                        {
                            //Debug.Log("gift");
                            if (giftCount == 0)
                            {
                                GameInformation.giftInventory.Add(shopList[i]);
                            }
                            else 
                            {
                                hasItem = false;
                                newItem = new Item();
                                for (int j = 0; j < GameInformation.giftInventory.Count; j++)
                                {
                                    if (GameInformation.giftInventory[j].ID == shopList[i].ID)
                                    {
                                        hasItem = true;
                                        newItem = shopList[i];
                                        index = j;
                                        break;
                                    }
                                }
                                if (hasItem == true)
                                {
                                    GameInformation.giftInventory[index].Amount += 1;
                                }
                                else
                                {
                                    GameInformation.giftInventory.Add(shopList[i]);
                                }
                            }
                        }
                        else if (shopList[i].ItemTypeValue == Item.ItemType.MISCELLANEOUS)
                        {
                            //Debug.Log("misc");
                            if (miscCount == 0)
                            {
                                GameInformation.miscInventory.Add(shopList[i]);
                            }
                            else
                            {
                                hasItem = false;
                                newItem = new Item();
                                for (int j = 0; j < GameInformation.miscInventory.Count; j++)
                                {
                                    if (GameInformation.miscInventory[j].ID == shopList[i].ID)
                                    {
                                        hasItem = true;
                                        newItem = shopList[i];
                                        index = j;
                                        break;
                                    }
                                }
                                if (hasItem == true)
                                {
                                    GameInformation.miscInventory[index].Amount += 1;
                                }
                                else
                                {
                                    GameInformation.miscInventory.Add(shopList[i]);
                                }
                            }
                        }
                        else 
                        {
                            //Debug.Log("usable");
                            //Debug.Log("usable ID : " + shopList[i].ID);
                            if (usableCount == 0)
                            {
                                //Debug.Log("dont have it before");
                                //Debug.Log("Amount : " + shopList[i].Amount);
                                GameInformation.usableInventory.Add(shopList[i]);
                            }
                            else 
                            {
                                hasItem = false;    
                                newItem = new Item();
                                for (int j = 0; j < GameInformation.usableInventory.Count; j++)
                                {
                                    if (GameInformation.usableInventory[j].ID == shopList[i].ID)
                                    {
                                        hasItem = true;
                                        newItem = shopList[i];
                                        index = j;
                                        break;
                                    } 
                                }
                                if (hasItem == true)
                                {
                                    //Debug.Log("already have");
                                    //Debug.Log("Amount : " + GameInformation.usableInventory[index].Amount);
                                    //Debug.Log("inven ID : " + newItem.ID);
                                    GameInformation.usableInventory[index].Amount += 1;
                                    //Debug.Log("Amount : " + GameInformation.usableInventory[index].Amount);
                                }
                                else
                                {
                                    //Debug.Log("dont have it before");
                                    //Debug.Log("Amount : " + shopList[i].Amount);
                                    GameInformation.usableInventory.Add(shopList[i]);
                                }
                            }
                        }
                        GameInformation.Gold -= shopList[i].BuyPrice;
                    }
                }
            }
            GUI.EndScrollView();
            GUI.EndGroup();
        }
    }

    private void ShowGold()
    {
        GUI.BeginGroup(new Rect(0.8f * Screen.width, 0.05f * Screen.height, 200, 40));
        GUI.Box(new Rect(0, 0, 200, 40), "");
        GUI.Label(new Rect(10, 10, 180, 20), gold + " G");
        GUI.EndGroup();
    }

    private void ShowShopMenu()
    {
        GUI.BeginGroup(new Rect(0.3f*Screen.height, 0.4f*Screen.height, 200, 140));
        if(isBuy == false && isSell == false)
        {
            if(GUI.Button(new Rect(0,0,200,40),"Buy"))
            {
                isBuy = true;
            }
            if(GUI.Button(new Rect(0,50,200,40),"Sell"))
            {
                isSell = true;
            }
            if(GUI.Button(new Rect(0,100,200,40),"Return"))
            {
                Application.LoadLevel("Town");
            }
        }
        GUI.EndGroup();
    }

    private void ShowDialogBox()
    {
        GUI.BeginGroup(new Rect(0.1f * Screen.width, 0.7f * Screen.height, 0.8f * Screen.width, 0.3f * Screen.height));
        GUI.Box(new Rect(0, 0, 0.8f * Screen.width, 0.2f * Screen.height), "");
        if (isBuy == false && isSell == false)
        {
            GUI.Label(new Rect(20, 20, 200, 20), "Welcome!");
            GUI.Label(new Rect(20, 50, 200, 20), "What do you want to do?");
        }
        else if (isBuy == true && isSell == false)
        {
            GUI.Label(new Rect(20, 20, 200, 20), "What do you want to buy?");
        }
        else if (isBuy == false && isSell == true)
        {
            GUI.Label(new Rect(20, 20, 200, 20), "What do you want to sell?");
        }
        GUI.EndGroup();
    }

    private void ShowReturnButton()
    {
        if (isBuy == true)
        {
            if (GUI.Button(new Rect(0.8f * Screen.width, 0.15f * Screen.height, 200, 30), "Return"))
            {
                isBuy = false;
            }
        }
        if (isSell == true)
        {
            if (GUI.Button(new Rect(0.8f * Screen.width, 0.15f * Screen.height, 200, 30), "Return"))
            {
                isSell = false;
            }
        }
    }
}
