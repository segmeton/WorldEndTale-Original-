using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WinState 
{
    private GrowthCalculation growthCalculation = new GrowthCalculation();
    private bool isAdded = false;
    private List<Item> itemDropList = new List<Item>();
    private List<BaseAccessory> accessoryDrop = new List<BaseAccessory>();
    private int random;
    private List<Dictionary<string, string>> enemyDropTable = new List<Dictionary<string, string>>();

    public bool IsAdded
    {
        set { isAdded = value; }
        get { return isAdded; }
    }

    public void WinBattle()
    {
        if (isAdded == false)
        {
            BattleInformation.goldObtained = 0;
            BattleInformation.expObtained = 0;
            enemyDropTable = GameInformation.enemyDropTable;
            if (BattleInformation.Enemy[0] != null)
            {
                if (BattleInformation.Enemy[0].CurrentHp == 0)
                {
                    BattleInformation.goldObtained += BattleInformation.Enemy[0].GoldDrop;
                    BattleInformation.expObtained += BattleInformation.Enemy[0].ExpDrop;
                    string enemyID;
                    string commonDropID;
                    //Debug.Log("before drop");
                    for(int i = 0; i < enemyDropTable.Count; i++ )
                    {
                        enemyDropTable[i].TryGetValue("EnemyID", out enemyID);
                        //Debug.Log(" temp enemy ID = " + enemyID + " enemyID = " + BattleInformation.Enemy[0].ID);
                        if (enemyID == BattleInformation.Enemy[0].ID)
                        {
                            enemyDropTable[i].TryGetValue("CommonDropID", out commonDropID);
                            //Debug.Log("item ID : " + commonDropID);
                            if (commonDropID.Substring(0, 2) != "AC")
                            {
                                //Debug.Log("get item " + commonDropID);
                                Item commonDrop = new Item(commonDropID);
                                //Debug.Log("get item " + commonDrop.Name);
                                itemDropList.Add(commonDrop);
                            }
                            else 
                            {
                                BaseAccessory accessoryCommon = new BaseAccessory(commonDropID);
                                accessoryDrop.Add(accessoryCommon);
                            }
                            random = Random.Range(0, 100);
                            if (random < 20)
                            {
                                string uncommonDropID;
                                enemyDropTable[i].TryGetValue("UncommonDropID", out uncommonDropID);
                                if (uncommonDropID.Substring(0, 2) != "AC")
                                {
                                    Item uncommonDrop = new Item(uncommonDropID);
                                    itemDropList.Add(uncommonDrop);
                                }
                                else
                                {
                                    BaseAccessory accessoryUncommon = new BaseAccessory(commonDropID);
                                    accessoryDrop.Add(accessoryUncommon);
                                }
                            }
                            random = Random.Range(0, 100);
                            if (random < 8)
                            {
                                string rareDropID;
                                enemyDropTable[i].TryGetValue("RareDropID", out rareDropID);
                                if (rareDropID.Substring(0, 2) != "AC")
                                {
                                    Item rareDrop = new Item(rareDropID);
                                    itemDropList.Add(rareDrop);
                                }
                                else
                                {
                                    BaseAccessory accessoryRare = new BaseAccessory(commonDropID);
                                    accessoryDrop.Add(accessoryRare);
                                }
                            }
                            break;
                        }
                    }
                }
            }
            if (BattleInformation.Enemy[1] != null)
            {
                if (BattleInformation.Enemy[1].CurrentHp == 0)
                {
                    BattleInformation.goldObtained += BattleInformation.Enemy[1].GoldDrop;
                    BattleInformation.expObtained += BattleInformation.Enemy[1].ExpDrop;
                    string enemyID;
                    string commonDropID;
                    for (int i = 0; i < enemyDropTable.Count; i++)
                    {
                        enemyDropTable[i].TryGetValue("EnemyID", out enemyID);
                        if (enemyID == BattleInformation.Enemy[1].ID)
                        {
                            enemyDropTable[i].TryGetValue("CommonDropID", out commonDropID);
                            if (commonDropID.Substring(0, 2) != "AC")
                            {
                                Item commonDrop = new Item(commonDropID);
                                itemDropList.Add(commonDrop);
                            }
                            else
                            {
                                BaseAccessory accessoryCommon = new BaseAccessory(commonDropID);
                                accessoryDrop.Add(accessoryCommon);
                            }
                            random = Random.Range(0, 100);
                            if (random < 20)
                            {
                                string uncommonDropID;
                                enemyDropTable[i].TryGetValue("UncommonDropID", out uncommonDropID);
                                if (uncommonDropID.Substring(0, 2) != "AC")
                                {
                                    Item uncommonDrop = new Item(uncommonDropID);
                                    itemDropList.Add(uncommonDrop);
                                }
                                else
                                {
                                    BaseAccessory accessoryUncommon = new BaseAccessory(commonDropID);
                                    accessoryDrop.Add(accessoryUncommon);
                                }
                            }
                            random = Random.Range(0, 100);
                            if (random < 8)
                            {
                                string rareDropID;
                                enemyDropTable[i].TryGetValue("RareDropID", out rareDropID);
                                if (rareDropID.Substring(0, 2) != "AC")
                                {
                                    Item rareDrop = new Item(rareDropID);
                                    itemDropList.Add(rareDrop);
                                }
                                else
                                {
                                    BaseAccessory accessoryRare = new BaseAccessory(commonDropID);
                                    accessoryDrop.Add(accessoryRare);
                                }
                            }
                            break;
                        }
                    }
                }
            }
            if (BattleInformation.Enemy[2] != null)
            {
                if (BattleInformation.Enemy[2].CurrentHp == 0)
                {
                    BattleInformation.goldObtained += BattleInformation.Enemy[2].GoldDrop;
                    BattleInformation.expObtained += BattleInformation.Enemy[2].ExpDrop;
                    string enemyID;
                    string commonDropID;
                    for (int i = 0; i < enemyDropTable.Count; i++)
                    {
                        enemyDropTable[i].TryGetValue("EnemyID", out enemyID);
                        if (enemyID == BattleInformation.Enemy[2].ID)
                        {
                            enemyDropTable[i].TryGetValue("CommonDropID", out commonDropID);
                            if (commonDropID.Substring(0, 2) != "AC")
                            {
                                Item commonDrop = new Item(commonDropID);
                                itemDropList.Add(commonDrop);
                            }
                            else
                            {
                                BaseAccessory accessoryCommon = new BaseAccessory(commonDropID);
                                accessoryDrop.Add(accessoryCommon);
                            }
                            random = Random.Range(0, 100);
                            if (random < 20)
                            {
                                string uncommonDropID;
                                enemyDropTable[i].TryGetValue("UncommonDropID", out uncommonDropID);
                                if (uncommonDropID.Substring(0, 2) != "AC")
                                {
                                    Item uncommonDrop = new Item(uncommonDropID);
                                    itemDropList.Add(uncommonDrop);
                                }
                                else
                                {
                                    BaseAccessory accessoryUncommon = new BaseAccessory(commonDropID);
                                    accessoryDrop.Add(accessoryUncommon);
                                }
                            }
                            random = Random.Range(0, 100);
                            if (random < 8)
                            {
                                string rareDropID;
                                enemyDropTable[i].TryGetValue("RareDropID", out rareDropID);
                                if (rareDropID.Substring(0, 2) != "AC")
                                {
                                    Item rareDrop = new Item(rareDropID);
                                    itemDropList.Add(rareDrop);
                                }
                                else
                                {
                                    BaseAccessory accessoryRare = new BaseAccessory(commonDropID);
                                    accessoryDrop.Add(accessoryRare);
                                }
                            }
                            break;
                        }
                    }
                }
            }
            int charAlive = 0;
            if (BattleInformation.Cecil.CurrentHp > 0)
            {
                charAlive++;
            }
            if (BattleInformation.Limca.CurrentHp > 0)
            {
                charAlive++;
            }
            if (BattleInformation.Galard.CurrentHp > 0)
            {
                charAlive++;
            }
            int expPerChar = BattleInformation.expObtained / charAlive;
            if (BattleInformation.Cecil.CurrentHp > 0)
            {
                BattleInformation.Cecil = growthCalculation.GrowCharacter(BattleInformation.Cecil, expPerChar);
            }
            if (BattleInformation.Limca.CurrentHp > 0)
            {
                BattleInformation.Limca = growthCalculation.GrowCharacter(BattleInformation.Limca, expPerChar);
            }
            if (BattleInformation.Galard.CurrentHp > 0)
            {
                BattleInformation.Galard = growthCalculation.GrowCharacter(BattleInformation.Galard, expPerChar);
            }
            BattleInformation.itemDropList = itemDropList;
            BattleInformation.accessoryDrop = accessoryDrop;
            //Debug.Log(itemDropList[0].Name);
            int usableCount = GameInformation.usableInventory.Count;
            int miscCount = GameInformation.miscInventory.Count;
            int giftCount = GameInformation.giftInventory.Count;
            bool hasItem = false;
            Item newItem;
            int index = 0;
            for(int i = 0; i < itemDropList.Count; i++)
            {
                if (itemDropList[i].Amount == 0)
                {
                    itemDropList[i].Amount = 1;
                }
                if (itemDropList[i].ItemTypeValue == Item.ItemType.GIFT)
                {
                    if (giftCount == 0)
                    {
                        GameInformation.giftInventory.Add(itemDropList[i]);
                    }
                    else
                    {
                        hasItem = false;
                        newItem = new Item();
                        for (int j = 0; j < GameInformation.giftInventory.Count; j++)
                        {
                            if (GameInformation.giftInventory[j].ID == itemDropList[i].ID)
                            {
                                hasItem = true;
                                newItem = itemDropList[i];
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
                            GameInformation.giftInventory.Add(itemDropList[i]);
                        }
                    }
                }
                else if (itemDropList[i].ItemTypeValue == Item.ItemType.MISCELLANEOUS)
                {
                    if (miscCount == 0)
                    {
                        GameInformation.miscInventory.Add(itemDropList[i]);
                    }
                    else
                    {
                        hasItem = false;
                        newItem = new Item();
                        for (int j = 0; j < GameInformation.miscInventory.Count; j++)
                        {
                            if (GameInformation.miscInventory[j].ID == itemDropList[i].ID)
                            {
                                hasItem = true;
                                newItem = itemDropList[i];
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
                            GameInformation.miscInventory.Add(itemDropList[i]);
                        }
                    }
                }
                else 
                {
                    if (usableCount == 0)
                    {
                        GameInformation.usableInventory.Add(itemDropList[i]);
                    }
                    else
                    {
                        hasItem = false;
                        newItem = new Item();
                        for (int j = 0; j < GameInformation.usableInventory.Count; j++)
                        {
                            if (GameInformation.usableInventory[j].ID == itemDropList[i].ID)
                            {
                                hasItem = true;
                                newItem = itemDropList[i];
                                index = j;
                                break;
                            }
                        }
                        if (hasItem == true)
                        {
                            GameInformation.usableInventory[index].Amount += 1;
                        }
                        else
                        {
                            GameInformation.usableInventory.Add(itemDropList[i]);
                        }
                    }
                }
            }
            for (int i = 0; i < accessoryDrop.Count; i++)
            {
                GameInformation.accessoriesInventory.Add(accessoryDrop[i]);
            }
            flagger();
            GameInformation.Gold += BattleInformation.goldObtained;
            GameInformation.Cecil = BattleInformation.Cecil;
            GameInformation.Limca = BattleInformation.Limca;
            GameInformation.Galard = BattleInformation.Galard;
            isAdded = true;
        }
    }

    public void flagger()
    {
        Debug.Log("Entering function");
        int checkCounter;
        string Identifier;
        for (checkCounter = 0; checkCounter < GameInformation.spawnCount; checkCounter++)
        {
            Debug.Log("Entering second function");
            for (int i = 0; i < GameInformation.enemyTable.Count; i++)
            {
                Debug.Log("Entering third function");
                GameInformation.enemyTable[i].TryGetValue("ID", out Identifier);
                Debug.Log(Identifier);
                if (GameInformation.idChecker[checkCounter] == Identifier)
                {
                    if (GameInformation.flagCheck[i] == false)
                    {
                        GameInformation.enemyFlag[i] = 1;
                        GameInformation.flagCheck[i] = true;
                    }
                    else if (GameInformation.flagCheck[i] == true)
                    {
                        GameInformation.enemyFlag[i] += 1;
                    }
                    Debug.Log("Finishing function");
                    Debug.Log(GameInformation.enemyFlag[i]);
                    checkCounter++;
                    break;
                }
            }
        }
    }
}
