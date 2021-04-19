using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public class DatabaseReader : MonoBehaviour 
{
    private XmlDocument xmlDoc = new XmlDocument();
    public TextAsset expTableData;
    public TextAsset baseStatTableData;
    public TextAsset growthTableData;
    public TextAsset enemyTableData;
    public TextAsset enemyDropTableData;
    public TextAsset enemyGroupTableData;
    public TextAsset accessoryTableData;
    public TextAsset accessoryUserTableData;
    public TextAsset armorTableData;
    public TextAsset armorUserTableData;
    public TextAsset bootsTableData;
    public TextAsset bootsUserTableData;
    public TextAsset itemTableData;
    public TextAsset skillTableData;
    public TextAsset skillUserTableData;
    public TextAsset weaponTableData;
    public TextAsset weaponUserTableData;


    void Awake()
    {
        if (GameInformation.expTable.Count == 0){GameInformation.expTable = ReadExpTable();}
        if (GameInformation.baseStatTable.Count == 0){GameInformation.baseStatTable = ReadBaseStatTable(); }
        if (GameInformation.growthTable.Count == 0){GameInformation.growthTable = ReadGrowthTable();}
        if (GameInformation.enemyTable.Count == 0){GameInformation.enemyTable = ReadEnemyTable();}
        if (GameInformation.enemyDropTable.Count == 0){GameInformation.enemyDropTable = ReadEnemyDropTable();}
        if (GameInformation.enemyGroupTable.Count == 0){GameInformation.enemyGroupTable = ReadEnemyGroupTable();}
        if (GameInformation.accessoryTable.Count == 0) { GameInformation.accessoryTable = ReadAccessoryTable(); }
        if (GameInformation.accessoryUserTable.Count == 0){GameInformation.accessoryUserTable = ReadAccessoryUserTable();}
        if (GameInformation.armorTable.Count == 0){GameInformation.armorTable = ReadArmorTable();}
        if (GameInformation.armorUserTable.Count == 0){GameInformation.armorUserTable = ReadArmorUserTable();}
        if (GameInformation.bootsTable.Count == 0){GameInformation.bootsTable = ReadBootsTable();}
        if (GameInformation.bootsUserTable.Count == 0){GameInformation.bootsUserTable = ReadBootsUserTable();}
        if (GameInformation.weaponTable.Count == 0){GameInformation.weaponTable = ReadWeaponTable();}
        if (GameInformation.weaponUserTable.Count == 0) {GameInformation.weaponUserTable = ReadWeaponUserTable();}
        if (GameInformation.weaponTable.Count == 0) {GameInformation.weaponTable = ReadWeaponTable();}
        if (GameInformation.skillTable.Count == 0) { GameInformation.skillTable = ReadSkillTable(); }
        if (GameInformation.skillUserTable.Count == 0){GameInformation.skillUserTable = ReadSkillUserTable();}
        if (GameInformation.skillUserTable.Count == 0) { GameInformation.skillUserTable = ReadSkillUserTable(); }
        if (GameInformation.itemTable.Count == 0) { GameInformation.itemTable = ReadItemTable(); }
        DontDestroyOnLoad(transform.gameObject);
    }

    public List<Dictionary<string, int>> ReadExpTable()
    {
        List<Dictionary<string, int>> stringIntTable = new List<Dictionary<string, int>>();
        xmlDoc.LoadXml(expTableData.text);
        XmlNodeList List = xmlDoc.GetElementsByTagName("EXP");
        foreach (XmlNode Data in List)
        {
            XmlNodeList dataContent = Data.ChildNodes;
            Dictionary<string, int> Dictionary = new Dictionary<string, int>();
            foreach (XmlNode content in dataContent)
            {
                switch (content.Name)
                {
                    case "Level":
                        Dictionary.Add("Level", int.Parse(content.InnerText));
                        break;
                    case "Next_x0020_EXP" :
                        Dictionary.Add("ExpRequired", int.Parse(content.InnerText));
                        break;
                }
            }
            stringIntTable.Add(Dictionary);
        }
        return stringIntTable;
    }

    public List<Dictionary<string, string>> ReadBaseStatTable()
    {
        List<Dictionary<string, string>> stringStringTable = new List<Dictionary<string, string>>();
        xmlDoc.LoadXml(baseStatTableData.text);
        XmlNodeList List = xmlDoc.GetElementsByTagName("Base_x0020_Stats");
        foreach (XmlNode Data in List)
        {
            XmlNodeList dataContent = Data.ChildNodes;
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            foreach (XmlNode content in dataContent)
            {
                switch (content.Name)
                {
                    case "ID":
                        Dictionary.Add("ID", content.InnerText);
                        break;
                    case "Name":
                        Dictionary.Add("Name", content.InnerText);
                        break;
                    case "HP":
                        Dictionary.Add("HP", content.InnerText);
                        break;
                    case "MP":
                        Dictionary.Add("MP", content.InnerText);
                        break;
                    case "STR":
                        Dictionary.Add("Str", content.InnerText);
                        break;
                    case "END":
                        Dictionary.Add("End", content.InnerText);
                        break;
                    case "MAG":
                        Dictionary.Add("Mag", content.InnerText);
                        break;
                    case "AGI":
                        Dictionary.Add("Agi", content.InnerText);
                        break;
                    case "ACC":
                        Dictionary.Add("Acc", content.InnerText);
                        break;
                }
            }
            stringStringTable.Add(Dictionary);
        }
        return stringStringTable;
    }

    public List<Dictionary<string, string>> ReadGrowthTable()
    {
        List<Dictionary<string, string>> stringStringTable = new List<Dictionary<string, string>>();
        xmlDoc.LoadXml(growthTableData.text);
        XmlNodeList List = xmlDoc.GetElementsByTagName("Growth");
        foreach (XmlNode Data in List)
        {
            XmlNodeList dataContent = Data.ChildNodes;
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            foreach (XmlNode content in dataContent)
            {
                switch (content.Name)
                {
                    case "ID":
                        Dictionary.Add("ID", content.InnerText);
                        break;
                    case "Name":
                        Dictionary.Add("Name", content.InnerText);
                        break;
                    case "HP":
                        Dictionary.Add("HP", content.InnerText);
                        break;
                    case "MP":
                        Dictionary.Add("MP", content.InnerText);
                        break;
                    case "STR":
                        Dictionary.Add("Str", content.InnerText);
                        break;
                    case "END":
                        Dictionary.Add("End", content.InnerText);
                        break;
                    case "MAG":
                        Dictionary.Add("Mag", content.InnerText);
                        break;
                    case "AGI":
                        Dictionary.Add("Agi", content.InnerText);
                        break;
                    case "ACC":
                        Dictionary.Add("Acc", content.InnerText);
                        break;
                }
            }
            stringStringTable.Add(Dictionary);
        }
        return stringStringTable;
    }

    public List<Dictionary<string, string>> ReadEnemyTable()
    {
        List<Dictionary<string, string>> stringStringTable = new List<Dictionary<string, string>>();
        xmlDoc.LoadXml(enemyTableData.text);
        XmlNodeList List = xmlDoc.GetElementsByTagName("Enemy");
        foreach (XmlNode Data in List)
        {
            XmlNodeList dataContent = Data.ChildNodes;
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            foreach (XmlNode content in dataContent)
            {
                switch (content.Name)
                {
                    case "ID":
                        Dictionary.Add("ID", content.InnerText);
                        break;
                    case "Name":
                        Dictionary.Add("Name", content.InnerText);
                        break;
                    case "HP":
                        Dictionary.Add("HP", content.InnerText);
                        break;
                    case "MP":
                        Dictionary.Add("MP", content.InnerText);
                        break;
                    case "STR":
                        Dictionary.Add("Str", content.InnerText);
                        break;
                    case "END":
                        Dictionary.Add("End", content.InnerText);
                        break;
                    case "MAG":
                        Dictionary.Add("Mag", content.InnerText);
                        break;
                    case "AGI":
                        Dictionary.Add("Agi", content.InnerText);
                        break;
                    case "ACC":
                        Dictionary.Add("Acc", content.InnerText);
                        break;
                    case "Level":
                        Dictionary.Add("Level", content.InnerText);
                        break;
                    case "EXP":
                        Dictionary.Add("Exp", content.InnerText);
                        break;
                    case "Gold":
                        Dictionary.Add("Gold", content.InnerText);
                        break;
                    case "Element":
                        Dictionary.Add("Element", content.InnerText);
                        break;
                }
            }
            stringStringTable.Add(Dictionary);
        }
        return stringStringTable;
    }

    public List<Dictionary<string, string>> ReadEnemyGroupTable()
    {
        List<Dictionary<string, string>> stringStringTable = new List<Dictionary<string, string>>();
        xmlDoc.LoadXml(enemyGroupTableData.text);
        XmlNodeList List = xmlDoc.GetElementsByTagName("Monster_x0020_Group");
        foreach (XmlNode Data in List)
        {
            XmlNodeList dataContent = Data.ChildNodes;
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            foreach (XmlNode content in dataContent)
            {
                switch (content.Name)
                {
                    case "Monster_x0020_ID":
                        Dictionary.Add("EnemyID", content.InnerText);
                        break;
                    case "Group":
                        Dictionary.Add("GroupID", content.InnerText);
                        break;
                }
            }
            stringStringTable.Add(Dictionary);
        }
        return stringStringTable;
    }

    public List<Dictionary<string, string>> ReadEnemyDropTable()
    {
        List<Dictionary<string, string>> stringStringTable = new List<Dictionary<string, string>>();
        xmlDoc.LoadXml(enemyDropTableData.text);
        XmlNodeList List = xmlDoc.GetElementsByTagName("Monster_x0020_Drop");
        foreach (XmlNode Data in List)
        {
            XmlNodeList dataContent = Data.ChildNodes;
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            foreach (XmlNode content in dataContent)
            {
                switch (content.Name)
                {
                    case "Enemy_x0020_ID":
                        Dictionary.Add("EnemyID", content.InnerText);
                        break;
                    case "Common_x0020_Drop_x0020_ID":
                        Dictionary.Add("CommonDropID", content.InnerText);
                        break;
                    case "Uncommon_x0020_Drop_x0020_ID":
                        Dictionary.Add("UncommonDropID", content.InnerText);
                        break;
                    case "Rare_x0020_Drop_x0020_ID":
                        Dictionary.Add("RareDropID", content.InnerText);
                        break;
                }
            }
            stringStringTable.Add(Dictionary);
        }
        return stringStringTable;
    }

    public List<Dictionary<string, string>> ReadAccessoryTable()
    {
        List<Dictionary<string, string>> stringStringTable = new List<Dictionary<string, string>>();
        xmlDoc.LoadXml(accessoryTableData.text);
        XmlNodeList List = xmlDoc.GetElementsByTagName("Accessory");
        foreach (XmlNode Data in List)
        {
            XmlNodeList dataContent = Data.ChildNodes;
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            foreach (XmlNode content in dataContent)
            {
                switch (content.Name)
                {
                    case "ID":
                        Dictionary.Add("ID", content.InnerText);
                        break;
                    case "Name":
                        Dictionary.Add("Name", content.InnerText);
                        break;
                    case "Buy_x0020_Price":
                        Dictionary.Add("BuyPrice", content.InnerText);
                        break;
                    case "Sell_x0020_Price":
                        Dictionary.Add("SellPrice", content.InnerText);
                        break;
                    case "STR":
                        Dictionary.Add("Str", content.InnerText);
                        break;
                    case "MAG":
                        Dictionary.Add("Mag", content.InnerText);
                        break;
                    case "END":
                        Dictionary.Add("End", content.InnerText);
                        break;
                    case "AGI":
                        Dictionary.Add("Agi", content.InnerText);
                        break;
                    case "ACC":
                        Dictionary.Add("Acc", content.InnerText);
                        break;
                    case "Description":
                        Dictionary.Add("Description", content.InnerText);
                        break;
                }
            }
            stringStringTable.Add(Dictionary);
        }
        return stringStringTable;
    }

    public List<Dictionary<string, string>> ReadAccessoryUserTable()
    {
        List<Dictionary<string, string>> stringStringTable = new List<Dictionary<string, string>>();
        xmlDoc.LoadXml(accessoryUserTableData.text);
        XmlNodeList List = xmlDoc.GetElementsByTagName("Accessory_x0020_User");
        foreach (XmlNode Data in List)
        {
            XmlNodeList dataContent = Data.ChildNodes;
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            foreach (XmlNode content in dataContent)
            {
                switch (content.Name)
                {
                    case "Accesory_x0020_ID":
                        Dictionary.Add("AccessoryID", content.InnerText);
                        break;
                    case "User_x0020_ID":
                        Dictionary.Add("CharID", content.InnerText);
                        break;
                }
            }
            stringStringTable.Add(Dictionary);
        }
        return stringStringTable;
    }

    public List<Dictionary<string, string>> ReadArmorTable()
    {
        List<Dictionary<string, string>> stringStringTable = new List<Dictionary<string, string>>();
        xmlDoc.LoadXml(armorTableData.text);
        XmlNodeList List = xmlDoc.GetElementsByTagName("Armor");
        foreach (XmlNode Data in List)
        {
            XmlNodeList dataContent = Data.ChildNodes;
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            foreach (XmlNode content in dataContent)
            {
                switch (content.Name)
                {
                    case "ID":
                        Dictionary.Add("ID", content.InnerText);
                        break;
                    case "Name":
                        Dictionary.Add("Name", content.InnerText);
                        break;
                    case "Buy_x0020_Price":
                        Dictionary.Add("BuyPrice", content.InnerText);
                        break;
                    case "Sell_x0020_Price":
                        Dictionary.Add("SellPrice", content.InnerText);
                        break;
                    case "STR":
                        Dictionary.Add("Str", content.InnerText);
                        break;
                    case "MAG":
                        Dictionary.Add("Mag", content.InnerText);
                        break;
                    case "END":
                        Dictionary.Add("End", content.InnerText);
                        break;
                    case "AGI":
                        Dictionary.Add("Agi", content.InnerText);
                        break;
                    case "ACC":
                        Dictionary.Add("Acc", content.InnerText);
                        break;
                    case "Description":
                        Dictionary.Add("Description", content.InnerText);
                        break;
                }
            }
            stringStringTable.Add(Dictionary);
        }
        return stringStringTable;
    }

    public List<Dictionary<string, string>> ReadArmorUserTable()
    {
        List<Dictionary<string, string>> stringStringTable = new List<Dictionary<string, string>>();
        xmlDoc.LoadXml(armorUserTableData.text);
        XmlNodeList List = xmlDoc.GetElementsByTagName("Armor_x0020_User");
        foreach (XmlNode Data in List)
        {
            XmlNodeList dataContent = Data.ChildNodes;
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            foreach (XmlNode content in dataContent)
            {
                switch (content.Name)
                {
                    case "Armor_x0020_ID":
                        Dictionary.Add("ArmorID", content.InnerText);
                        break;
                    case "User_x0020_ID":
                        Dictionary.Add("CharID", content.InnerText);
                        break;
                }
            }
            stringStringTable.Add(Dictionary);
        }
        return stringStringTable;
    }

    public List<Dictionary<string, string>> ReadBootsTable()
    {
        List<Dictionary<string, string>> stringStringTable = new List<Dictionary<string, string>>();
        xmlDoc.LoadXml(bootsTableData.text);
        XmlNodeList List = xmlDoc.GetElementsByTagName("Boots");
        foreach (XmlNode Data in List)
        {
            XmlNodeList dataContent = Data.ChildNodes;
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            foreach (XmlNode content in dataContent)
            {
                switch (content.Name)
                {
                    case "ID":
                        Dictionary.Add("ID", content.InnerText);
                        break;
                    case "Name":
                        Dictionary.Add("Name", content.InnerText);
                        break;
                    case "Buy_x0020_Price":
                        Dictionary.Add("BuyPrice", content.InnerText);
                        break;
                    case "Sell_x0020_Price":
                        Dictionary.Add("SellPrice", content.InnerText);
                        break;
                    case "STR":
                        Dictionary.Add("Str", content.InnerText);
                        break;
                    case "MAG":
                        Dictionary.Add("Mag", content.InnerText);
                        break;
                    case "END":
                        Dictionary.Add("End", content.InnerText);
                        break;
                    case "AGI":
                        Dictionary.Add("Agi", content.InnerText);
                        break;
                    case "ACC":
                        Dictionary.Add("Acc", content.InnerText);
                        break;
                    case "Description":
                        Dictionary.Add("Description", content.InnerText);
                        break;
                }
            }
            stringStringTable.Add(Dictionary);
        }
        return stringStringTable;
    }

    public List<Dictionary<string, string>> ReadBootsUserTable()
    {
        List<Dictionary<string, string>> stringStringTable = new List<Dictionary<string, string>>();
        xmlDoc.LoadXml(bootsUserTableData.text);
        XmlNodeList List = xmlDoc.GetElementsByTagName("Boots_x0020_User");
        foreach (XmlNode Data in List)
        {
            XmlNodeList dataContent = Data.ChildNodes;
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            foreach (XmlNode content in dataContent)
            {
                switch (content.Name)
                {
                    case "Boots_x0020_ID":
                        Dictionary.Add("BootsID", content.InnerText);
                        break;
                    case "User_x0020_ID":
                        Dictionary.Add("CharID", content.InnerText);
                        break;
                }
            }
            stringStringTable.Add(Dictionary);
        }
        return stringStringTable;
    }

    public List<Dictionary<string, string>> ReadWeaponTable()
    {
        List<Dictionary<string, string>> stringStringTable = new List<Dictionary<string, string>>();
        xmlDoc.LoadXml(weaponTableData.text);
        XmlNodeList List = xmlDoc.GetElementsByTagName("Weapon");
        foreach (XmlNode Data in List)
        {
            XmlNodeList dataContent = Data.ChildNodes;
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            foreach (XmlNode content in dataContent)
            {
                switch (content.Name)
                {
                    case "ID":
                        Dictionary.Add("ID", content.InnerText);
                        break;
                    case "Name":
                        Dictionary.Add("Name", content.InnerText);
                        break;
                    case "Buy_x0020_Price":
                        Dictionary.Add("BuyPrice", content.InnerText);
                        break;
                    case "Sell_x0020_Price":
                        Dictionary.Add("SellPrice", content.InnerText);
                        break;
                    case "STR":
                        Dictionary.Add("Str", content.InnerText);
                        break;
                    case "MAG":
                        Dictionary.Add("Mag", content.InnerText);
                        break;
                    case "END":
                        Dictionary.Add("End", content.InnerText);
                        break;
                    case "AGI":
                        Dictionary.Add("Agi", content.InnerText);
                        break;
                    case "ACC":
                        Dictionary.Add("Acc", content.InnerText);
                        break;
                    case "Description":
                        Dictionary.Add("Description", content.InnerText);
                        break;
                }
            }
            stringStringTable.Add(Dictionary);
        }
        return stringStringTable;
    }

    public List<Dictionary<string, string>> ReadWeaponUserTable()
    {
        List<Dictionary<string, string>> stringStringTable = new List<Dictionary<string, string>>();
        xmlDoc.LoadXml(weaponUserTableData.text);
        XmlNodeList List = xmlDoc.GetElementsByTagName("Weapon_x0020_User");
        foreach (XmlNode Data in List)
        {
            XmlNodeList dataContent = Data.ChildNodes;
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            foreach (XmlNode content in dataContent)
            {
                switch (content.Name)
                {
                    case "Weapon_x0020_ID":
                        Dictionary.Add("WeaponID", content.InnerText);
                        break;
                    case "User_x0020_ID":
                        Dictionary.Add("CharID", content.InnerText);
                        break;
                }
            }
            stringStringTable.Add(Dictionary);
        }
        return stringStringTable;
    }

    public List<Dictionary<string, string>> ReadItemTable()
    {
        List<Dictionary<string, string>> stringStringTable = new List<Dictionary<string, string>>();
        xmlDoc.LoadXml(itemTableData.text);
        XmlNodeList List = xmlDoc.GetElementsByTagName("Item");
        foreach (XmlNode Data in List)
        {
            XmlNodeList dataContent = Data.ChildNodes;
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            foreach (XmlNode content in dataContent)
            {
                switch (content.Name)
                {
                    case "ID":
                        Dictionary.Add("ID", content.InnerText);
                        break;
                    case "Name":
                        Dictionary.Add("Name", content.InnerText);
                        break;
                    case "Type":
                        Dictionary.Add("Type", content.InnerText);
                        break;
                    case "Description":
                        Dictionary.Add("Description", content.InnerText);
                        break;
                    case "Buy_x0020_Price":
                        Dictionary.Add("BuyPrice", content.InnerText);
                        break;
                    case "Sell_x0020_Price":
                        Dictionary.Add("SellPrice", content.InnerText);
                        break;            
                }
            }
            stringStringTable.Add(Dictionary);
        }
        return stringStringTable;
    }

    public List<Dictionary<string, string>> ReadSkillTable()
    {
        List<Dictionary<string, string>> stringStringTable = new List<Dictionary<string, string>>();
        xmlDoc.LoadXml(skillTableData.text);
        XmlNodeList List = xmlDoc.GetElementsByTagName("Skill");
        foreach (XmlNode Data in List)
        {
            XmlNodeList dataContent = Data.ChildNodes;
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            foreach (XmlNode content in dataContent)
            {
                switch (content.Name)
                {
                    case "ID":
                        Dictionary.Add("ID", content.InnerText);
                        break;
                    case "Name":
                        Dictionary.Add("Name", content.InnerText);
                        break;
                    case "Base_x0020_Power":
                        Dictionary.Add("BasePower", content.InnerText);
                        break;
                    case "Element":
                        Dictionary.Add("Element", content.InnerText);
                        break;
                    case "Type":
                        Dictionary.Add("Type", content.InnerText);
                        break;
                    case "Target":
                        Dictionary.Add("Target", content.InnerText);
                        break;
                    case "MP_x0020_Cost":
                        Dictionary.Add("MPCost", content.InnerText);
                        break;
                    case "Description":
                        Dictionary.Add("Description", content.InnerText);
                        break;
                }
            }
            stringStringTable.Add(Dictionary);
        }
        return stringStringTable;
    }

    public List<Dictionary<string, string>> ReadSkillUserTable()
    {
        List<Dictionary<string, string>> stringStringTable = new List<Dictionary<string, string>>();
        xmlDoc.LoadXml(skillUserTableData.text);
        XmlNodeList List = xmlDoc.GetElementsByTagName("Skill_x0020_User");
        foreach (XmlNode Data in List)
        {
            XmlNodeList dataContent = Data.ChildNodes;
            Dictionary<string, string> Dictionary = new Dictionary<string, string>();
            foreach (XmlNode content in dataContent)
            {
                switch (content.Name)
                {
                    case "Skill_x0020_ID":
                        Dictionary.Add("SkillID", content.InnerText);
                        break;
                    case "User_x0020_ID":
                        Dictionary.Add("CharID", content.InnerText);
                        break;
                }
            }
            stringStringTable.Add(Dictionary);
        }
        return stringStringTable;
    }
}
