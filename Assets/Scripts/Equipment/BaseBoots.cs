using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseBoots : BaseEquipment
{
    private List<Dictionary<string, string>> bootsTable = new List<Dictionary<string, string>>();
    private List<Dictionary<string, string>> bootsUserTable = new List<Dictionary<string, string>>();

    public BaseBoots() { }

    public BaseBoots(string inputID) 
    {
        bootsTable = GameInformation.bootsTable;
        bootsUserTable = GameInformation.bootsUserTable;

        for (int i = 0; i < bootsTable.Count; i++)
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
            bootsTable[i].TryGetValue("ID", out tempID);
            if (tempID == inputID)
            {
                bootsTable[i].TryGetValue("Name", out name);
                bootsTable[i].TryGetValue("Description", out description);

                bootsTable[i].TryGetValue("SellPrice", out sellPriceString);
                bootsTable[i].TryGetValue("BuyPrice", out buyPriceString);
                bootsTable[i].TryGetValue("Str", out str);
                bootsTable[i].TryGetValue("End", out end);
                bootsTable[i].TryGetValue("Mag", out mag);
                bootsTable[i].TryGetValue("Agi", out agi);
                bootsTable[i].TryGetValue("Acc", out acc);

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
                EquipmentTypeValue = EquipmentType.BOOTS;
                for (int j = 0; j < bootsUserTable.Count; j++)
                {
                    string tempChar;
                    string bootsID;
                    bootsUserTable[j].TryGetValue("BootsID", out bootsID);
                    if(UseByCecil != true || UseByLimca != true || UseByGalard != true)
                    {
                        if(tempID == bootsID)
                        {
                            bootsUserTable[j].TryGetValue("CharID", out tempChar);
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
