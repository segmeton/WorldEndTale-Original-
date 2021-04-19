using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameInformation : MonoBehaviour 
{
    public static int Gold { set; get; }
    public static BaseCharacter Limca { set; get; }
    public static BaseCharacter Cecil { set; get; }
    public static BaseCharacter Galard { set; get; }

    public static List<Dictionary<string, int>> expTable = new List<Dictionary<string, int>>();
    public static List<Dictionary<string, string>> baseStatTable = new List<Dictionary<string, string>>();
    public static List<Dictionary<string, string>> growthTable = new List<Dictionary<string, string>>();
    public static List<Dictionary<string, string>> enemyTable = new List<Dictionary<string, string>>();
    public static List<Dictionary<string, string>> enemyDropTable = new List<Dictionary<string, string>>();
    public static List<Dictionary<string, string>> accessoryTable = new List<Dictionary<string, string>>();
    public static List<Dictionary<string, string>> accessoryUserTable = new List<Dictionary<string, string>>();
    public static List<Dictionary<string, string>> armorTable = new List<Dictionary<string, string>>();
    public static List<Dictionary<string, string>> armorUserTable = new List<Dictionary<string, string>>();
    public static List<Dictionary<string, string>> bootsTable = new List<Dictionary<string, string>>();
    public static List<Dictionary<string, string>> bootsUserTable = new List<Dictionary<string, string>>();
    public static List<Dictionary<string, string>> itemTable = new List<Dictionary<string, string>>();
    public static List<Dictionary<string, string>> skillTable = new List<Dictionary<string, string>>();
    public static List<Dictionary<string, string>> skillUserTable = new List<Dictionary<string, string>>();
    public static List<Dictionary<string, string>> weaponTable = new List<Dictionary<string, string>>();
    public static List<Dictionary<string, string>> weaponUserTable = new List<Dictionary<string, string>>();
    public static List<Dictionary<string, string>> enemyGroupTable = new List<Dictionary<string, string>>();
    public static List<Item> usableInventory = new List<Item>();
    public static List<Item> miscInventory = new List<Item>();
    public static List<Item> giftInventory = new List<Item>();
    public static List<BaseWeapon> weaponInventory = new List<BaseWeapon>();
    public static List<BaseArmor> armorInventory = new List<BaseArmor>();
    public static List<BaseAccessory> accessoriesInventory = new List<BaseAccessory>();
    public static List<BaseBoots> bootsInventory = new List<BaseBoots>();
    public static int[] enemyFlag = new int[15];
    public static bool[] flagCheck = new bool[15];
    public static string[] idChecker = new string[3];
    public static int spawnCount;
    public static bool isTavernAccessed;

    private int indexBaseStat;
    private int indexGrowth;
    private string charID;
    private string name;
    private string baseHp;
    private string baseMp;
    private string baseStr;
    private string baseEnd;
    private string baseMag;
    private string baseAgi;
    private string baseAcc;
    private string hpGrowth;
    private string mpGrowth;
    private string strGrowth;
    private string endGrowth;
    private string magGrowth;
    private string agiGrowth;
    private string accGrowth;
    private List<BaseAbility> abilityList;

    private static GameInformation _instance;

    public static GameInformation instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameInformation>();

                //Tell unity not to destroy this object when loading a new scene!
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    void Start()
    {
        NewGame();
        Gold = 50000;
        //Cecil.CurrentHp = (int)(0.5 * Cecil.Hp);
        //for (int i = 0; i < 6; i++)
        //{
        //    Cecil.AbilityList[i].IsUnlocked = true;
        //}
        //foreach (BaseAbility ability in Cecil.AbilityList)
        //{
        //    Debug.Log("skill name : " + ability.Name);
        //}
        //Debug.Log("skill 1 :"+Cecil.AbilityList[0].Name);
        //Debug.Log("skill 2 :" + Cecil.AbilityList[1].Name);
        //Debug.Log("skill 3 :" + Cecil.AbilityList[2].Name);
        //Debug.Log("skill 4 :" + Cecil.AbilityList[3].Name);
        //Debug.Log("skill 5 :" + Cecil.AbilityList[4].Name);
        //Debug.Log("skill 6 :" + Cecil.AbilityList[5].Name);
        //Debug.Log("skill 7 :" + Cecil.AbilityList[6].Name);
        
    }

    void Update()
    {
        if (MainMenuGUI.newGame == true)
        {
            NewGame();
        }
    }

    private void NewGame()
    {
        //Debug.Log("test first");
        //Debug.Log(gold);
        //if (Gold == 0)//still buggy
        //{
            //Gold = 100;
            //Debug.Log(Gold);
        //}
        Gold = 500;
        isTavernAccessed = false;
        if (Limca == null) { Limca = InitializeChar(BaseCharacter.CharacterUnit.LIMCA); }
        if (Cecil == null) { Cecil = InitializeChar(BaseCharacter.CharacterUnit.CECIL); }
        if (Galard == null) { Galard = InitializeChar(BaseCharacter.CharacterUnit.GALARD); }
        MainMenuGUI.newGame = false;
    }

    private BaseCharacter InitializeChar(BaseCharacter.CharacterUnit charUnit)
    {
        BaseCharacter character = new BaseCharacter();

        switch (charUnit)
        {
            case BaseCharacter.CharacterUnit.CECIL:
                character.CharacterUnitName = BaseCharacter.CharacterUnit.CECIL;
                for (int i = 0; i < baseStatTable.Count; i++)
                {
                    baseStatTable[i].TryGetValue("Name", out name);
                    if (name == "Cecil")
                    {
                        indexBaseStat = i;
                        break;
                    }
                }
                for (int i = 0; i < growthTable.Count; i++)
                {
                    growthTable[i].TryGetValue("Name", out name);
                    if (name == "Cecil")
                    {
                        indexGrowth = i;
                        break;
                    }
                }
                break;
            case BaseCharacter.CharacterUnit.LIMCA:
                character.CharacterUnitName = BaseCharacter.CharacterUnit.LIMCA;
                for (int i = 0; i < baseStatTable.Count; i++)
                {
                    baseStatTable[i].TryGetValue("Name", out name);
                    if (name == "Limca")
                    {
                        indexBaseStat = i;
                        break;
                    }
                }
                for (int i = 0; i < growthTable.Count; i++)
                {
                    growthTable[i].TryGetValue("Name", out name);
                    if (name == "Limca")
                    {
                        indexGrowth = i;
                        break;
                    }
                }
                break;
            case BaseCharacter.CharacterUnit.GALARD:
                character.CharacterUnitName = BaseCharacter.CharacterUnit.GALARD;
                for (int i = 0; i < baseStatTable.Count; i++)
                {
                    baseStatTable[i].TryGetValue("Name", out name);
                    if (name == "Galard")
                    {
                        indexBaseStat = i;
                        break;
                    }
                }
                for (int i = 0; i < growthTable.Count; i++)
                {
                    growthTable[i].TryGetValue("Name", out name);
                    if (name == "Galard")
                    {
                        indexGrowth = i;
                        break;
                    }
                }
                break;
        }
        baseStatTable[indexBaseStat].TryGetValue("ID", out charID);
        baseStatTable[indexBaseStat].TryGetValue("HP", out baseHp);
        baseStatTable[indexBaseStat].TryGetValue("MP", out baseMp);
        baseStatTable[indexBaseStat].TryGetValue("Str", out baseStr);
        baseStatTable[indexBaseStat].TryGetValue("End", out baseEnd);
        baseStatTable[indexBaseStat].TryGetValue("Mag", out baseMag);
        baseStatTable[indexBaseStat].TryGetValue("Agi", out baseAgi);
        baseStatTable[indexBaseStat].TryGetValue("Acc", out baseAcc);

        growthTable[indexGrowth].TryGetValue("HP", out hpGrowth); 
        growthTable[indexGrowth].TryGetValue("MP", out mpGrowth);
        growthTable[indexGrowth].TryGetValue("Str", out strGrowth);
        growthTable[indexGrowth].TryGetValue("End", out endGrowth);
        growthTable[indexGrowth].TryGetValue("Mag", out magGrowth);
        growthTable[indexGrowth].TryGetValue("Agi", out agiGrowth);
        growthTable[indexGrowth].TryGetValue("Acc", out accGrowth);
        
        character.ID = charID;
        character.Name = name;
        character.Lv = 1;
        character.CurrentXp = 0;
        int reqXp;
        expTable[character.Lv - 1].TryGetValue("ExpRequired", out reqXp);
        character.XpToLvUp = reqXp;

        character.BaseHp = int.Parse(baseHp);
        character.BaseMp = int.Parse(baseMp);
        character.BaseStr = int.Parse(baseStr);
        character.BaseEnd = int.Parse(baseEnd);
        character.BaseMag = int.Parse(baseMag);
        character.BaseAgi = int.Parse(baseAgi);
        character.BaseAcc = int.Parse(baseAcc);

        character.Hp = character.BaseHp;
        character.CurrentHp = character.Hp;
        character.Mp = character.BaseMp;
        character.CurrentMp = character.BaseMp;
        character.Str = character.BaseStr;
        character.End = character.BaseEnd;
        character.Mag = character.BaseMag;
        character.Agi = character.BaseAgi;
        character.Acc = character.BaseAcc;

        character.HpGrowth = int.Parse(hpGrowth);
        character.MpGrowth = int.Parse(mpGrowth);
        character.StrGrowth = int.Parse(strGrowth);
        character.EndGrowth = int.Parse(endGrowth);
        character.MagGrowth = int.Parse(magGrowth);
        character.AgiGrowth = int.Parse(agiGrowth);
        character.AccGrowth = int.Parse(accGrowth);

        character.AbilityList = GetAbilityList(character.ID);
        character.AbilityList[0].IsUnlocked = true;
        
        return character;
    }

    private List<BaseAbility> GetAbilityList(string ID)
    {
        string charID;
        string skillID;
        string tempID;
	    string name;
	    string description;
        string basePower;
        string mpCost;
        string element;
        string target;
        string type;
        BaseAbility ability;
        abilityList = new List<BaseAbility>();
        for (int i = 0; i < skillUserTable.Count; i++)
        {
            skillUserTable[i].TryGetValue("CharID", out charID);
            //Debug.Log("char ID from skill user table : " + charID);
            //Debug.Log("ID inputted to the function : " + ID);
            if (charID == ID)
            {
                skillUserTable[i].TryGetValue("SkillID", out skillID);
                //Debug.Log("Skill ID from skill user table : " + skillID);
                for (int j = 0; j < skillTable.Count; j++)
                {
                    skillTable[j].TryGetValue("ID", out tempID);
                    //Debug.Log("skill ID from skill table : " + tempID);
                    if (skillID == tempID)
                    {
                        skillTable[j].TryGetValue("Name", out name);
                        skillTable[j].TryGetValue("Description", out description);
                        skillTable[j].TryGetValue("BasePower", out basePower);
                        skillTable[j].TryGetValue("MPCost", out mpCost);
                        skillTable[j].TryGetValue("Element", out element);
                        skillTable[j].TryGetValue("Type", out type);
                        skillTable[j].TryGetValue("Target", out target);
                        //Debug.Log("Skill added : " + name);
                        ability = new BaseAbility();
                        ability.ID = skillID;
                        ability.Name = name;
                        //Debug.Log("Skill name : " + ability.Name);
                        ability.Description = description;
                        ability.BasePower = int.Parse(basePower);
                        ability.MpCost = int.Parse(mpCost);
                        switch (element)
                        {
                            case "Water":
                                ability.Element.ElementType = BaseElement.Element.WATER;
                                break;
                            case "Fire":
                                ability.Element.ElementType = BaseElement.Element.FIRE;
                                break;
                            case "Wind":
                                ability.Element.ElementType = BaseElement.Element.WIND;
                                break;
                            case "Electric":
                                ability.Element.ElementType = BaseElement.Element.ELECTRIC;
                                break;
                            case "Earth":
                                ability.Element.ElementType = BaseElement.Element.EARTH;
                                break;
                            case "Dark":
                                ability.Element.ElementType = BaseElement.Element.DARK;
                                break;
                            case "Light":
                                ability.Element.ElementType = BaseElement.Element.LIGHT;
                                break;
                            case "Neutral":
                                ability.Element.ElementType = BaseElement.Element.NEUTRAL;
                                break;
                        }
                        switch (type)
                        {
                            case "Physical":
                                ability.SkillType = BaseAbility.Type.PHYSICAL;
                                break;
                            case "Magical":
                                ability.SkillType = BaseAbility.Type.MAGICAL;
                                break;
                        }
                        switch (target)
                        {
                            case "Single":
                                ability.TargetEnemy = BaseAbility.Target.SINGLE;
                                break;
                            case "All":
                                ability.TargetEnemy = BaseAbility.Target.ALL;
                                break;
                        }
                        abilityList.Add(ability);
                        break;
                    }
                }
            }
        }
        //Debug.Log("skill 1 :" + abilityList[0].Name);
        //Debug.Log("skill 2 :" + abilityList[1].Name);
        //Debug.Log("skill 3 :" + abilityList[2].Name);
        //Debug.Log("skill 4 :" + abilityList[3].Name);
        //Debug.Log("skill 5 :" + abilityList[4].Name);
        //Debug.Log("skill 6 :" + abilityList[5].Name);
        //Debug.Log("skill 7 :" + abilityList[6].Name);
        return abilityList;
    }
}
