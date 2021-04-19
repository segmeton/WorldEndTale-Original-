using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseArmor : BaseEquipment
{
    private List<Dictionary<string, string>> armorTable = new List<Dictionary<string, string>>();
    private List<Dictionary<string, string>> armorUserTable = new List<Dictionary<string, string>>();

    public BaseArmor() { }

    public BaseArmor(string inputID) 
    {
        armorTable = GameInformation.armorTable;
        armorUserTable = GameInformation.armorUserTable;

        for (int i = 0; i < armorTable.Count; i++)
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
            armorTable[i].TryGetValue("ID", out tempID);
            if (tempID == inputID)
            {
                armorTable[i].TryGetValue("Name", out name);
                armorTable[i].TryGetValue("Description", out description);

                armorTable[i].TryGetValue("SellPrice", out sellPriceString);
                armorTable[i].TryGetValue("BuyPrice", out buyPriceString);
                armorTable[i].TryGetValue("Str", out str);
                armorTable[i].TryGetValue("End", out end);
                armorTable[i].TryGetValue("Mag", out mag);
                armorTable[i].TryGetValue("Agi", out agi);
                armorTable[i].TryGetValue("Acc", out acc);

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
                Index = Random.Range(0, 10000);
                EquipmentTypeValue = EquipmentType.ARMOR;
                for (int j = 0; j < armorUserTable.Count; j++)
                {
                    string tempChar;
                    string armorID;
                    armorUserTable[j].TryGetValue("ArmorID", out armorID);
                    if (UseByCecil != true || UseByLimca != true || UseByGalard != true)
                    {
                        if (tempID == armorID)
                        {
                            armorUserTable[j].TryGetValue("CharID", out tempChar);
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
