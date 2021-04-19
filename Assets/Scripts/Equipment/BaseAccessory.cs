using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseAccessory : BaseEquipment
{
    private List<Dictionary<string, string>> accessoryTable = new List<Dictionary<string, string>>();
    private List<Dictionary<string, string>> accessoryUserTable = new List<Dictionary<string, string>>();

    public BaseAccessory() { }

    public BaseAccessory(string inputID) 
    {
        accessoryTable = GameInformation.accessoryTable;
        accessoryUserTable = GameInformation.accessoryUserTable;

        for (int i = 0; i < accessoryTable.Count; i++)
        {
            string tempID;
            string sellPriceString;
            string buyPriceString;
            string name;
            string description;
            string str;
            string mag;
            string end;
            string acc;
            string agi;
            Index = Random.Range(0, 10000);
            accessoryTable[i].TryGetValue("ID", out tempID);
            if (tempID == inputID)
            {
                accessoryTable[i].TryGetValue("Name", out name);
                accessoryTable[i].TryGetValue("Description", out description);

                accessoryTable[i].TryGetValue("SellPrice", out sellPriceString);
                accessoryTable[i].TryGetValue("BuyPrice", out buyPriceString);
                accessoryTable[i].TryGetValue("Str", out str);
                accessoryTable[i].TryGetValue("End", out end);
                accessoryTable[i].TryGetValue("Mag", out mag);
                accessoryTable[i].TryGetValue("Agi", out agi);
                accessoryTable[i].TryGetValue("Acc", out acc);

                ID = tempID;
                Name = name;
                Description = description;
                SellPrice = int.Parse(sellPriceString);
                BuyPrice = int.Parse(buyPriceString);
                Str = int.Parse(str);
                Mag = int.Parse(mag);
                End = int.Parse(end);
                Agi = int.Parse(agi);
                Acc = int.Parse(acc);

                EquipmentTypeValue = EquipmentType.ACCESSORY;
                for (int j = 0; j < accessoryUserTable.Count; j++)
                {
                    string tempChar;
                    string accID;
                    accessoryUserTable[j].TryGetValue("AccessoryID", out accID);
                    if (UseByCecil != true || UseByLimca != true || UseByGalard != true)
                    {
                        if (tempID == accID)
                        {
                            accessoryUserTable[j].TryGetValue("CharID", out tempChar);
                            if (tempChar == "CH01")
                            {
                                UseByCecil = true;
                            }
                            else if (tempChar == "CH02")
                            {
                                UseByLimca = true;
                            }
                            else if (tempChar == "CH03")
                            {
                                UseByGalard = true;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                break;
            }
        }
    }
}
