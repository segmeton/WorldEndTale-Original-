using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Armory : MonoBehaviour
{
    private List<BaseWeapon> weaponList = new List<BaseWeapon>();
    private List<BaseArmor> armorList = new List<BaseArmor>();
    private List<BaseBoots> bootsList = new List<BaseBoots>();
    private List<BaseAccessory> accessoryList = new List<BaseAccessory>();
    private List<Dictionary<string, string>> accessoryTable;
    private List<Dictionary<string, string>> armorTable;
    private List<Dictionary<string, string>> bootsTable;
    private List<Dictionary<string, string>> weaponTable;
    private int gold;
    private bool isBuy = false;
    private bool isSell = false;
    private Vector2 buyScrollPosition = Vector2.zero;
    private Vector2 sellScrollPosition = Vector2.zero;

    void Start()
    {
        //GameInformation.Gold = 1000000;
        weaponTable = GameInformation.weaponTable;
        armorTable = GameInformation.armorTable;
        bootsTable = GameInformation.bootsTable;
        accessoryTable = GameInformation.accessoryTable;
        //Debug.Log(itemTable.Count);
        //Debug.Log("before sholist");
        for (int i = 0; i < weaponTable.Count; i++)
        {
            string buyPriceString;
            weaponTable[i].TryGetValue("BuyPrice", out buyPriceString);
            int buyPrice = int.Parse(buyPriceString);
            //Debug.Log("validate itme");
            if (buyPrice != 0)
            {
                //Debug.Log("buyable item");
                string id;
                weaponTable[i].TryGetValue("ID", out id);
                BaseWeapon weapon = new BaseWeapon(id);
                weaponList.Add(weapon);
            }
        }
        for (int i = 0; i < armorTable.Count; i++)
        {
            string buyPriceString;
            armorTable[i].TryGetValue("BuyPrice", out buyPriceString);
            int buyPrice = int.Parse(buyPriceString);
            if (buyPrice != 0)
            {
                string id;
                armorTable[i].TryGetValue("ID", out id);
                BaseArmor armor = new BaseArmor(id);
                armorList.Add(armor);
            }
        }
        for (int i = 0; i < bootsTable.Count; i++)
        {
            string buyPriceString;
            bootsTable[i].TryGetValue("BuyPrice", out buyPriceString);
            int buyPrice = int.Parse(buyPriceString);
            if (buyPrice != 0)
            {
                string id;
                bootsTable[i].TryGetValue("ID", out id);
                BaseBoots boots = new BaseBoots(id);
                bootsList.Add(boots);
            }
        }
        for (int i = 0; i < accessoryTable.Count; i++)
        {
            string buyPriceString;
            accessoryTable[i].TryGetValue("BuyPrice", out buyPriceString);
            int buyPrice = int.Parse(buyPriceString);
            if (buyPrice != 0)
            {
                string id;
                accessoryTable[i].TryGetValue("ID", out id);
                BaseAccessory accssory = new BaseAccessory(id);
                accessoryList.Add(accssory);
            }
        }
        //Debug.Log("after shoplist");
        //for (int i = 0; i < shopList.Count; i++)
        //{
        //Debug.Log("test");
        //Debug.Log("item name : " + shopList[i].Name + " Buy Price : " + shopList[i].BuyPrice);
        //}
        //for (int i = 0; i < weaponList.Count; i++)
        //{
        //    Debug.Log(weaponList[i].Index);
        //}
    }

    void Update()
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
        if (isBuy == false && isSell == true)
        {
            int weaponCount = GameInformation.weaponInventory.Count;
            int accessoryCount = GameInformation.accessoriesInventory.Count;
            int bootsCount = GameInformation.bootsInventory.Count;
            int armorCount = GameInformation.armorInventory.Count;
            int totalHeight = (weaponCount + armorCount + accessoryCount + bootsCount) * 80 + 30;
            GUI.BeginGroup(new Rect(0.1f * Screen.width, 0.05f * Screen.height, 0.6f * Screen.width, 0.6f * Screen.height));
            GUI.Box(new Rect(0, 0, 0.6f * Screen.width, 0.6f * Screen.height), "");
            sellScrollPosition = GUI.BeginScrollView(new Rect(20, 20, 0.6f * Screen.width - 40, 0.6f * Screen.height - 40), buyScrollPosition, new Rect(0, 0, 430, totalHeight));
            for (int i = 0; i < GameInformation.weaponInventory.Count; i++)
            {
                GUI.Label(new Rect(20, i * 80 + 25, 150, 20), GameInformation.weaponInventory[i].Name);
                GUI.Label(new Rect(170, i * 80 + 25, 70, 20), "WEAPON");
                GUI.Label(new Rect(240, i * 80 + 25, 50, 20), GameInformation.weaponInventory[i].SellPrice + " G");
                GUI.Label(new Rect(20, i * 80 + 50, 50, 20), "Str : " + GameInformation.weaponInventory[i].Str);
                GUI.Label(new Rect(80, i * 80 + 50, 50, 20), "Mag : " + GameInformation.weaponInventory[i].Mag);
                GUI.Label(new Rect(140, i * 80 + 50, 50, 20), "End : " + GameInformation.weaponInventory[i].End);
                GUI.Label(new Rect(200, i * 80 + 50, 50, 20), "Agi : " + GameInformation.weaponInventory[i].Agi);
                GUI.Label(new Rect(260, i * 80 + 50, 50, 20), "Acc : " + GameInformation.weaponInventory[i].Acc);
                GUI.Label(new Rect(20, i * 80 + 75, 500, 20), GameInformation.weaponInventory[i].Description);
                if (GameInformation.weaponInventory[i].Used == false)
                {
                    if (GUI.Button(new Rect(310, i * 80 + 20, 100, 30), "Sell"))
                    {
                        GameInformation.Gold += GameInformation.weaponInventory[i].SellPrice;
                        GameInformation.weaponInventory.RemoveAt(i);
                    }
                }
            }
            int weaponHeight = weaponCount * 80 + 25;
            for (int i = 0; i < GameInformation.armorInventory.Count; i++)
            {
                GUI.Label(new Rect(20, i * 80 + weaponHeight, 150, 20), GameInformation.armorInventory[i].Name);
                GUI.Label(new Rect(170, i * 80 + weaponHeight, 70, 20), "ARMOR");
                GUI.Label(new Rect(240, i * 80 + weaponHeight, 50, 20), GameInformation.armorInventory[i].SellPrice + " G");
                GUI.Label(new Rect(20, i * 80 + 25 + weaponHeight, 50, 20), "Str : " + GameInformation.armorInventory[i].Str);
                GUI.Label(new Rect(80, i * 80 + 25 + weaponHeight, 50, 20), "Mag : " + GameInformation.armorInventory[i].Mag);
                GUI.Label(new Rect(140, i * 80 + 25 + weaponHeight, 50, 20), "End : " + GameInformation.armorInventory[i].End);
                GUI.Label(new Rect(200, i * 80 + 25 + weaponHeight, 50, 20), "Agi : " + GameInformation.armorInventory[i].Agi);
                GUI.Label(new Rect(260, i * 80 + 25 + weaponHeight, 50, 20), "Acc : " + GameInformation.armorInventory[i].Acc);
                GUI.Label(new Rect(20, i * 80 + 50 + weaponHeight, 500, 20), GameInformation.armorInventory[i].Description);
                if (GameInformation.armorInventory[i].Used == false)
                {
                    if (GUI.Button(new Rect(310, i * 80 - 5 + weaponHeight, 100, 30), "Sell"))
                    {
                        GameInformation.Gold += GameInformation.armorInventory[i].SellPrice;
                        GameInformation.armorInventory.RemoveAt(i);
                    }
                }
            }
            int armorHeight = armorCount * 80;
            int beforeBootsHeight = weaponHeight + armorHeight;
            for (int i = 0; i < GameInformation.bootsInventory.Count; i++)
            {
                GUI.Label(new Rect(20, i * 80 + beforeBootsHeight, 150, 20), GameInformation.bootsInventory[i].Name);
                GUI.Label(new Rect(170, i * 80 + beforeBootsHeight, 70, 20), "BOOTS");
                GUI.Label(new Rect(240, i * 80 + beforeBootsHeight, 50, 20), GameInformation.bootsInventory[i].SellPrice + " G");
                GUI.Label(new Rect(20, i * 80 + 25 + beforeBootsHeight, 50, 20), "Str : " + GameInformation.bootsInventory[i].Str);
                GUI.Label(new Rect(80, i * 80 + 25 + beforeBootsHeight, 50, 20), "Mag : " + GameInformation.bootsInventory[i].Mag);
                GUI.Label(new Rect(140, i * 80 + 25 + beforeBootsHeight, 50, 20), "End : " + GameInformation.bootsInventory[i].End);
                GUI.Label(new Rect(200, i * 80 + 25 + beforeBootsHeight, 50, 20), "Agi : " + GameInformation.bootsInventory[i].Agi);
                GUI.Label(new Rect(260, i * 80 + 25 + beforeBootsHeight, 50, 20), "Acc : " + GameInformation.bootsInventory[i].Acc);
                GUI.Label(new Rect(20, i * 80 + 50 + beforeBootsHeight, 500, 20), GameInformation.bootsInventory[i].Description);
                if (GameInformation.bootsInventory[i].Used == false)
                {
                    if (GUI.Button(new Rect(310, i * 80 - 5 + beforeBootsHeight, 100, 30), "Sell"))
                    {
                        GameInformation.Gold += GameInformation.bootsInventory[i].SellPrice;
                        GameInformation.bootsInventory.RemoveAt(i);
                    }
                }
            }
            int bootsHeight = bootsCount * 80;
            int beforeAccessoryHeight = beforeBootsHeight + bootsHeight;
            for (int i = 0; i < GameInformation.accessoriesInventory.Count; i++)
            {
                GUI.Label(new Rect(20, i * 80 + beforeAccessoryHeight, 150, 20), GameInformation.accessoriesInventory[i].Name);
                GUI.Label(new Rect(170, i * 80 + beforeAccessoryHeight, 70, 20), "ACCESSORIES");
                GUI.Label(new Rect(240, i * 80 + beforeAccessoryHeight, 50, 20), GameInformation.accessoriesInventory[i].SellPrice + " G");
                GUI.Label(new Rect(20, i * 80 + 25 + beforeAccessoryHeight, 50, 20), "Str : " + GameInformation.accessoriesInventory[i].Str);
                GUI.Label(new Rect(80, i * 80 + 25 + beforeAccessoryHeight, 50, 20), "Mag : " + GameInformation.accessoriesInventory[i].Mag);
                GUI.Label(new Rect(140, i * 80 + 25 + beforeAccessoryHeight, 50, 20), "End : " + GameInformation.accessoriesInventory[i].End);
                GUI.Label(new Rect(200, i * 80 + 25 + beforeAccessoryHeight, 50, 20), "Agi : " + GameInformation.accessoriesInventory[i].Agi);
                GUI.Label(new Rect(260, i * 80 + 25 + beforeAccessoryHeight, 50, 20), "Acc : " + GameInformation.accessoriesInventory[i].Acc);
                GUI.Label(new Rect(20, i * 80 + 50 + beforeAccessoryHeight, 500, 20), GameInformation.accessoriesInventory[i].Description);
                if (GameInformation.accessoriesInventory[i].Used == false)
                {
                    if (GUI.Button(new Rect(310, i * 80 -5 + beforeAccessoryHeight, 100, 30), "Sell"))
                    {
                        GameInformation.Gold += GameInformation.accessoriesInventory[i].SellPrice;
                        GameInformation.accessoriesInventory.RemoveAt(i);
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
            int weaponCount = weaponList.Count;
            int accessoryCount = accessoryList.Count;
            int bootsCount = bootsList.Count;
            int armorCount = armorList.Count; 
            int totalHeight = (weaponCount + armorCount + accessoryCount + bootsCount)*80 + 30;
            GUI.BeginGroup(new Rect(0.1f * Screen.width, 0.05f * Screen.height, 0.6f * Screen.width, 0.6f * Screen.height));
            GUI.Box(new Rect(0, 0, 0.6f * Screen.width, 0.6f * Screen.height), "");
            buyScrollPosition = GUI.BeginScrollView(new Rect(20, 20, 0.6f * Screen.width - 40, 0.6f * Screen.height - 40), buyScrollPosition, new Rect(0, 0, 430, totalHeight));
            for (int i = 0; i < weaponList.Count; i++)
            {
                GUI.Label(new Rect(20, i * 80 + 25, 150, 20), weaponList[i].Name);
                GUI.Label(new Rect(170, i * 80 + 25, 70, 20), "WEAPON");
                GUI.Label(new Rect(240, i * 80 + 25, 50, 20), weaponList[i].BuyPrice + " G");
                GUI.Label(new Rect(20, i * 80 + 50, 50, 20), "Str : " + weaponList[i].Str);
                GUI.Label(new Rect(80, i * 80 + 50, 50, 20), "Mag : " + weaponList[i].Mag);
                GUI.Label(new Rect(140, i * 80 + 50, 50, 20), "End : " + weaponList[i].End);
                GUI.Label(new Rect(200, i * 80 + 50, 50, 20), "Agi : " + weaponList[i].Agi);
                GUI.Label(new Rect(260, i * 80 + 50, 50, 20), "Acc : " + weaponList[i].Acc);
                GUI.Label(new Rect(20, i * 80 + 75, 500, 20), weaponList[i].Description);
                if (GameInformation.Gold >= weaponList[i].BuyPrice)
                {
                    if (GUI.Button(new Rect(310, i * 80 + 20, 100, 30), "Buy"))
                    {
                        //Debug.Log("Buy " + shopList[i].Name);
                        //weaponList[i].Index = Random.Range(0, 10000);
                        //Debug.Log(weaponList[i].Index);
                        BaseWeapon weapon = new BaseWeapon(weaponList[i].ID);
                        GameInformation.weaponInventory.Add(weapon);
                        GameInformation.Gold -= weaponList[i].BuyPrice;
                    }
                }
            }
            int weaponHeight = weaponList.Count * 80 + 25;
            for (int i = 0; i < armorList.Count; i++)
            {
                GUI.Label(new Rect(20, i * 80 + weaponHeight, 150, 20), armorList[i].Name);
                GUI.Label(new Rect(170, i * 80 + weaponHeight, 70, 20), "ARMOR");
                GUI.Label(new Rect(240, i * 80 + weaponHeight, 50, 20), armorList[i].BuyPrice + " G");
                GUI.Label(new Rect(20, i * 80 + 25 + weaponHeight, 50, 20), "Str : " + armorList[i].Str);
                GUI.Label(new Rect(80, i * 80 + 25 + weaponHeight, 50, 20), "Mag : " + armorList[i].Mag);
                GUI.Label(new Rect(140, i * 80 + 25 + weaponHeight, 50, 20), "End : " + armorList[i].End);
                GUI.Label(new Rect(200, i * 80 + 25 + weaponHeight, 50, 20), "Agi : " + armorList[i].Agi);
                GUI.Label(new Rect(260, i * 80 + 25 + weaponHeight, 50, 20), "Acc : " + armorList[i].Acc);
                GUI.Label(new Rect(20, i * 80 + 50 + weaponHeight, 500, 20), armorList[i].Description);
                if (GameInformation.Gold >= armorList[i].BuyPrice)
                {
                    if (GUI.Button(new Rect(310, i * 80 + weaponHeight - 5, 100, 30), "Buy"))
                    {
                        //Debug.Log("Buy " + shopList[i].Name);
                        BaseArmor armor = new BaseArmor(armorList[i].ID);
                        GameInformation.armorInventory.Add(armor);
                        GameInformation.Gold -= armorList[i].BuyPrice;
                    }
                } 
            }
            int armorHeight = armorList.Count * 80;
            int beforeBootsHeight = weaponHeight + armorHeight;
            for (int i = 0; i < bootsList.Count; i++)
            {
                GUI.Label(new Rect(20, i * 80 + beforeBootsHeight, 150, 20), bootsList[i].Name);
                GUI.Label(new Rect(170, i * 80 + beforeBootsHeight, 70, 20), "BOOTS");
                GUI.Label(new Rect(240, i * 80 + beforeBootsHeight, 50, 20), bootsList[i].BuyPrice + " G");
                GUI.Label(new Rect(20, i * 80 + 25 + beforeBootsHeight, 50, 20), "Str : " + bootsList[i].Str);
                GUI.Label(new Rect(80, i * 80 + 25 + beforeBootsHeight, 50, 20), "Mag : " + bootsList[i].Mag);
                GUI.Label(new Rect(140, i * 80 + 25 + beforeBootsHeight, 50, 20), "End : " + bootsList[i].End);
                GUI.Label(new Rect(200, i * 80 + 25 + beforeBootsHeight, 50, 20), "Agi : " + bootsList[i].Agi);
                GUI.Label(new Rect(260, i * 80 + 25 + beforeBootsHeight, 50, 20), "Acc : " + bootsList[i].Acc);
                GUI.Label(new Rect(20, i * 80 + 50 + beforeBootsHeight, 500, 20), bootsList[i].Description);
                if (GameInformation.Gold >= bootsList[i].BuyPrice)
                {
                    if (GUI.Button(new Rect(310, i * 80 + beforeBootsHeight - 5, 100, 30), "Buy"))
                    {
                        //Debug.Log("Buy " + shopList[i].Name);
                        BaseBoots boots = new BaseBoots(bootsList[i].ID);
                        GameInformation.bootsInventory.Add(boots);
                        GameInformation.Gold -= bootsList[i].BuyPrice;
                    }
                }
                
            }
            int bootsHeight = bootsList.Count * 80;
            int beforeAccessoryHeight = beforeBootsHeight + bootsHeight;
            for (int i = 0; i < accessoryList.Count; i++)
            {
                GUI.Label(new Rect(20, i * 80 + beforeAccessoryHeight, 150, 20), accessoryList[i].Name);
                GUI.Label(new Rect(170, i * 80 + beforeAccessoryHeight, 70, 20), "ACCESSORIES");
                GUI.Label(new Rect(240, i * 80 + beforeAccessoryHeight, 50, 20), accessoryList[i].BuyPrice + " G");
                GUI.Label(new Rect(20, i * 80 + 25 + beforeAccessoryHeight, 50, 20), "Str : " + accessoryList[i].Str);
                GUI.Label(new Rect(80, i * 80 + 25 + beforeAccessoryHeight, 50, 20), "Mag : " + accessoryList[i].Mag);
                GUI.Label(new Rect(140, i * 80 + 25 + beforeAccessoryHeight, 50, 20), "End : " + accessoryList[i].End);
                GUI.Label(new Rect(200, i * 80 + 25 + beforeAccessoryHeight, 50, 20), "Agi : " + accessoryList[i].Agi);
                GUI.Label(new Rect(260, i * 80 + 25 + beforeAccessoryHeight, 50, 20), "Acc : " + accessoryList[i].Acc);
                GUI.Label(new Rect(20, i * 80 + 50 + beforeAccessoryHeight, 500, 20), accessoryList[i].Description);
                if (GameInformation.Gold >= accessoryList[i].BuyPrice)
                {
                    if (GUI.Button(new Rect(310, i * 80 + beforeAccessoryHeight - 5, 100, 30), "Buy"))
                    {
                        //Debug.Log("Buy " + shopList[i].Name);
                        BaseAccessory accessory = new BaseAccessory(accessoryList[i].ID);
                        GameInformation.accessoriesInventory.Add(accessory);
                        GameInformation.Gold -= accessoryList[i].BuyPrice;
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
        GUI.BeginGroup(new Rect(0.3f * Screen.height, 0.4f * Screen.height, 200, 140));
        if (isBuy == false && isSell == false)
        {
            if (GUI.Button(new Rect(0, 0, 200, 40), "Buy"))
            {
                isBuy = true;
            }
            if (GUI.Button(new Rect(0, 50, 200, 40), "Sell"))
            {
                isSell = true;
            }
            if (GUI.Button(new Rect(0, 100, 200, 40), "Return"))
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
