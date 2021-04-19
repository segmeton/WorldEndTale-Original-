using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseWeapon : BaseEquipment
{
    private List<Dictionary<string, string>> weaponTable = new List<Dictionary<string, string>>();
    private List<Dictionary<string, string>> weaponUserTable = new List<Dictionary<string, string>>();

    public BaseWeapon() { }

    public BaseWeapon(string inputID) 
    {
        weaponTable = GameInformation.weaponTable;
        weaponUserTable = GameInformation.weaponUserTable;

        for (int i = 0; i < weaponTable.Count; i++)
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
            weaponTable[i].TryGetValue("ID", out tempID);
            if (tempID == inputID)
            {
                weaponTable[i].TryGetValue("Name", out name);
                weaponTable[i].TryGetValue("Description", out description);

                weaponTable[i].TryGetValue("SellPrice", out sellPriceString);
                weaponTable[i].TryGetValue("BuyPrice", out buyPriceString);
                weaponTable[i].TryGetValue("Str", out str);
                weaponTable[i].TryGetValue("End", out end);
                weaponTable[i].TryGetValue("Mag", out mag);
                weaponTable[i].TryGetValue("Agi", out agi);
                weaponTable[i].TryGetValue("Acc", out acc);

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
                EquipmentTypeValue = EquipmentType.WEAPON;
                for (int j = 0; j < weaponUserTable.Count; j++)
                {
                    string tempChar;
                    string weaponID;
                    weaponUserTable[j].TryGetValue("WeaponID", out weaponID);
                    if(UseByCecil != true || UseByLimca != true || UseByGalard != true)
                    {
                        if(tempID == weaponID)
                        {
                            weaponUserTable[j].TryGetValue("CharID", out tempChar);
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
