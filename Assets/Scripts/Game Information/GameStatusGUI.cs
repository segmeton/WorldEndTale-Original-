using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStatusGUI : MonoBehaviour 
{
    public static bool isOpen = false;
    public Texture cecilSprite;
    public Texture limcaSprite;
    public Texture galardSprite;
    public Texture red;
    public Texture blue;
    public Texture green;
    public Texture yellow;
    private int option2;
    private int selectedMenu;
    private int selectedChar;
    private int selectedSkill;
    private string[] selStrings = new string[] { "Main Info", "Char", "Skill", "Equipment", "Item", "Quest", "Save or Load" };
    private string[] selTest = new string[] { "Igna", "Xelvaria", "Fei Long" };
    private string[] selCharStrings = new string[] { "Cecil", "Limca", "Galard" };
    private Vector2 itemScrollPosition = Vector2.zero;
    private Vector2 equipScrollPosition = Vector2.zero;
    private bool showItemTarget = false;
    private int equipment;
    int itemIndex = 0;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        ValidateGUI();
    }

    void Update()
    {
        ValidateGUI();
    }

    private void ValidateGUI()
    {
        //Debug.Log("validate");
        string levelName = Application.loadedLevelName;
        if (levelName == "Dungeon")
        {
            if (Input.GetKeyDown("escape"))
            {
                if (EncounterManager.isBattle == false && isOpen == false)
                {
                    isOpen = true;
                }
                else if (EncounterManager.isBattle == false && isOpen == true)
                {
                    isOpen = false;
                }
            }
        }
        else if (levelName == "Town")
        {
            if (Input.GetKeyDown("escape"))
            {
                if (isOpen == false)
                {
                    isOpen = true;
                }
                else if (isOpen == true)
                {
                    isOpen = false;
                }
            }
        }
    }

    void OnGUI()
    {
        if (isOpen == true)
        {
            ShowGameStatus();
        }
        //bool button = GUI.Button(new Rect(20, 20, 100, 30),"test");
        
            //if (GUI.Button(new Rect(20, 20, 100, 30), "test"))
            //{
            //    GameInformation.armorInventory[0].Name = "guuhaaaa";
            //    for (int i = 0; i < GameInformation.armorInventory.Count; i++)
            //    {
            //        Debug.Log(GameInformation.armorInventory[i].Name);
            //        Debug.Log("cecil : " + GameInformation.armorInventory[i].UseByCecil);
            //        Debug.Log("galard : " + GameInformation.armorInventory[i].UseByGalard);
            //        Debug.Log("limca : " + GameInformation.armorInventory[i].UseByLimca);
            //    }
            //}
        
    }

    private void ShowGameStatus()
    {
        GUI.skin.button.wordWrap = true;
        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            selectedMenu = GUI.SelectionGrid(new Rect(20, 20, Screen.width - 40, 30), selectedMenu, selStrings, 5);
            GUI.BeginGroup(new Rect(20, 60, Screen.width - 40, Screen.height - 100));
                if(selectedMenu == 0)
                {
                    showItemTarget = false;
                    ShowMainInfo();
                }
                else if (selectedMenu == 1)
                {
                    showItemTarget = false;
                    ShowCharData(selectedMenu);
                }
                else if (selectedMenu == 2)
                {
                    showItemTarget = false;
                    ShowCharData(selectedMenu);
                }
                else if (selectedMenu == 3)
                {
                    showItemTarget = false;
                    ShowCharData(selectedMenu);
                }
                else if (selectedMenu == 4)
                {
                    ShowItem();
                }
                else if (selectedMenu == 5)
                {
                    ShowQuest();
                }
                else if (selectedMenu == 6)
                {
                    SaveLoadInterface();
                }
            GUI.EndGroup();
        GUI.EndGroup();
    }
    private void ShowQuest()
    {
        int code = 0;
        string type = "";
        string status = "";
        string requirement = "";
        option2 = GUI.SelectionGrid(new Rect(0, 0, Screen.width - 300, 30), option2, selTest, 3);
        GUI.BeginGroup(new Rect(0, 40, Screen.width - 40, Screen.height - 140), "");
        if (option2 == 0)
        {
            if (GameInformation.isTavernAccessed == false)
            {
                code = 0;
                type = "";
                status = "";
                requirement = "";
            }
            else if (GameInformation.isTavernAccessed == true)
            {
                //				code = RelationshipDisplayGUI.IR.Quest100[RelationshipDisplayGUI.IgnaQuestIndex].QuestNumber;
                //				type = RelationshipDisplayGUI.IR.Quest100[RelationshipDisplayGUI.IgnaQuestIndex].QuestCat.ToString();
                //				status = RelationshipDisplayGUI.IR.Quest100[RelationshipDisplayGUI.IgnaQuestIndex].QuestStat.ToString();
                //				requirement = RelationshipDisplayGUI.IR.Quest100[RelationshipDisplayGUI.IgnaQuestIndex].QuestCondition.ToString();
            }

        }
        else if (option2 == 1)
        {
            if (GameInformation.isTavernAccessed == false)
            {
                code = 0;
                type = "";
                status = "";
                requirement = "";
            }
            else if (GameInformation.isTavernAccessed == true)
            {
                //				code = RelationshipDisplayGUI.XLR.Quest200[RelationshipDisplayGUI.XelvariaQuestIndex].QuestNumber;
                //				type = RelationshipDisplayGUI.XLR.Quest200[RelationshipDisplayGUI.XelvariaQuestIndex].QuestCat.ToString();
                //				status = RelationshipDisplayGUI.XLR.Quest200[RelationshipDisplayGUI.XelvariaQuestIndex].QuestStat.ToString();
                //				requirement = RelationshipDisplayGUI.XLR.Quest200[RelationshipDisplayGUI.XelvariaQuestIndex].QuestCondition.ToString();
            }
        }
        else if (option2 == 2)
        {
            if (GameInformation.isTavernAccessed == false)
            {
                code = 0;
                type = "";
                status = "";
                requirement = "";
            }
            else if (GameInformation.isTavernAccessed == true)
            {
                //				code = RelationshipDisplayGUI.FLR.Quest300[RelationshipDisplayGUI.FeiLongQuestIndex].QuestNumber;
                //				type = RelationshipDisplayGUI.FLR.Quest300[RelationshipDisplayGUI.FeiLongQuestIndex].QuestCat.ToString();
                //				status = RelationshipDisplayGUI.FLR.Quest300[RelationshipDisplayGUI.FeiLongQuestIndex].QuestStat.ToString();
                //				requirement = RelationshipDisplayGUI.FLR.Quest300[RelationshipDisplayGUI.FeiLongQuestIndex].QuestCondition.ToString();
            }
        }
        GUI.EndGroup();
        GUI.skin.button.wordWrap = true;
        if (status != "ONGOING")
        {
            GUI.Box(new Rect(0, 40, Screen.width - 40, Screen.height - 140), "");
            GUI.Label(new Rect(30, 60, Screen.width - 40, Screen.height - 140), "Quest Code: -");
            GUI.Label(new Rect(30, 100, Screen.width - 40, Screen.height - 140), "Quest Type: -");
            GUI.Label(new Rect(30, 140, Screen.width - 40, Screen.height - 140), "Quest Status: -");
            GUI.Label(new Rect(30, 180, Screen.width - 100, Screen.height - 140), "Quest Requirement: -");
        }
        else if (status == "ONGOING")
        {
            GUI.Box(new Rect(0, 40, Screen.width - 40, Screen.height - 140), "");
            GUI.Label(new Rect(30, 60, Screen.width - 40, Screen.height - 140), "Quest Code: " + code);
            GUI.Label(new Rect(30, 100, Screen.width - 40, Screen.height - 140), "Quest Type: " + type);
            GUI.Label(new Rect(30, 140, Screen.width - 40, Screen.height - 140), "Quest Status: " + status);
            GUI.Label(new Rect(30, 180, Screen.width - 100, Screen.height - 140), "Quest Requirement: " + requirement);
        }

    }

    private void SaveLoadInterface()
    {
        GUI.Box(new Rect(0, 40, Screen.width - 40, Screen.height - 140), "");

        int screenWidthPosition = Screen.width / 2;
        int screenHeightPosition = Screen.height / 2;
        int horizontalPosition1 = screenWidthPosition - 125;
        int horizontalPosition2 = screenWidthPosition - 50;
        int horizontalPosition3 = screenWidthPosition - 90;
        int verticalPosition1 = screenHeightPosition - 90;
        int verticalPosition2;

        GUI.Box(new Rect(horizontalPosition3, verticalPosition1 - 140, 180, 65), "Select the save slot.");
        if (GUI.Button(new Rect(horizontalPosition1, verticalPosition1 - 60, 250, 65), "Slot 1\n" + "Cecil Level: 6\n" + " HP: 175      MP: 100\n" + "Gold: 681"))
        {

        }
        if (GUI.Button(new Rect(horizontalPosition1, verticalPosition1 + 20, 250, 65), "Slot 2\n" + "Empty"))
        {

        }
        if (GUI.Button(new Rect(horizontalPosition1, verticalPosition1 + 100, 250, 65), "Slot 3\n" + "empty"))
        {

        }
        if (GUI.Button(new Rect(horizontalPosition2, verticalPosition1 + 180, 100, 80), "Cancel"))
        {

        }



    }

    private void ShowMainInfo()
    {
        float charUIGroupHeight = (Screen.height-140) / 3;
        float charWidth = 80;
        float charHeight = charUIGroupHeight - 5;
        float dataWidth = (Screen.width - 340) - charWidth - 5;
        float maxWidth = dataWidth * 0.6f;
        GUI.Box(new Rect(0, 0, Screen.width - 300, Screen.height - 100), "");
        GUI.BeginGroup(new Rect(20,20, Screen.width - 340, charUIGroupHeight),"");
            CharPosition(GameInformation.Cecil, dataWidth,charWidth,charHeight,maxWidth,cecilSprite);
        GUI.EndGroup();
        GUI.BeginGroup(new Rect(20,charUIGroupHeight+20, Screen.width - 340, charUIGroupHeight),"");
            CharPosition(GameInformation.Limca, dataWidth, charWidth, charHeight, maxWidth, limcaSprite);
        GUI.EndGroup();
        GUI.BeginGroup(new Rect(20,charUIGroupHeight * 2 + 20, Screen.width - 340, charUIGroupHeight),"");
            CharPosition(GameInformation.Galard, dataWidth, charWidth, charHeight, maxWidth, galardSprite);
        GUI.EndGroup();
        GUI.Box(new Rect(Screen.width -280, 0, 240, Screen.height - 100), "");
        GUI.Label(new Rect(Screen.width - 260, 20, 200, 20), "Gold : " + GameInformation.Gold + " G");
        GUI.Label(new Rect(Screen.width - 260, 60, 200, 20), "Relationship Point");
        GUI.Label(new Rect(Screen.width - 260, 90, 80, 20), "Igna");
        GUI.Label(new Rect(Screen.width - 260, 120, 80, 20), "Fei Long");
        GUI.Label(new Rect(Screen.width - 260, 150, 80, 20), "Xelvaria");
    }

    private void CharPosition(BaseCharacter character, float dataWidth, float charWidth, float charHeight, float maxWidth, Texture sprite)
    {
        Texture healthTexture;
        float barWidth;
        if (character.CurrentHp != 0) GUI.DrawTexture(new Rect(0, 0, charWidth, charHeight), sprite, ScaleMode.ScaleToFit);

        GUI.Label(new Rect(charWidth + 5, 0, dataWidth, 20), "Lv " + character.Lv + " " + character.Name);

        healthTexture = HealthTexture(character.CurrentHp, character.Hp);
        barWidth = BarWidth(character.CurrentHp, character.Hp, maxWidth);
        GUI.DrawTexture(new Rect(charWidth + 5, 25, barWidth, 10), healthTexture, ScaleMode.ScaleAndCrop);
        GUI.Label(new Rect((charWidth + 5) + (dataWidth * 0.6f ) + 5, 20, (dataWidth * 0.4f) - 5, 20), character.CurrentHp + " / " + character.Hp);

        barWidth = BarWidth(character.CurrentMp, character.Mp, maxWidth);
        GUI.DrawTexture(new Rect(charWidth + 5, 45, barWidth, 10), blue, ScaleMode.StretchToFill);
        GUI.Label(new Rect((charWidth + 5) + (dataWidth * 0.6f ) + 5, 40, (dataWidth * 0.4f) - 5, 20), character.CurrentMp + " / " + character.Mp);
    }

    private Texture HealthTexture(int currentHp, int maxHp)
    {
        Texture texture;
        float hpPercentage = (float)currentHp / (float)maxHp;
        if (hpPercentage <= 0.25f)
        {
            texture = red;
        }
        else if (hpPercentage <= 0.5f)
        {
            texture = yellow;
        }
        else
        {
            texture = green;
        }
        return texture;
    }

    private float BarWidth(int current, int max, float maxLength)
    {
        float barWidth;
        float Percentage = (float)current / (float)max;
        barWidth = Percentage * maxLength;
        return barWidth;
    }

    private void ShowCharData(int option)
    {
        selectedChar = GUI.SelectionGrid(new Rect(0, 0, Screen.width - 300, 30), selectedChar, selCharStrings, 3);
        GUI.BeginGroup(new Rect(0, 40, Screen.width - 40, Screen.height - 140), "");
        if (option == 1)
        {
            ShowCharStatus();
        }
        else if(option == 2)
        {
            ShowCharSkill();
        }
        else if (option == 3)
        {
            ShowCharEquip();
        }
        GUI.EndGroup();
    }

    private void ShowCharStatus()
    {
        BaseCharacter character = new BaseCharacter();
        Texture texture = new Texture();
        GUI.Box(new Rect(0, 0, Screen.width - 40, Screen.height - 140), "");
        if (selectedChar == 0)
        {
            character = GameInformation.Cecil;
            texture = cecilSprite;
        }
        else if (selectedChar == 1)
        {
            character = GameInformation.Limca;
            texture = limcaSprite;
        }
        else if (selectedChar == 2)
        {
            character = GameInformation.Galard;
            texture = galardSprite;
        }
        GUI.BeginGroup(new Rect(20, 20, Screen.width - 80, Screen.height - 180), "");
            GUI.DrawTexture(new Rect(0, 0, 100, 100), texture, ScaleMode.ScaleToFit);
            GUI.Label(new Rect(120, 0, 100, 20), "Name : " + character.Name);
            GUI.Label(new Rect(120, 25, 100, 20), "Level : " + character.Lv);
            GUI.Label(new Rect(120, 50, 100, 20), "Hp : " + character.Hp);
            GUI.Label(new Rect(120, 75, 100, 20), "Mp : " + character.Mp);
            GUI.Label(new Rect(120, 100, 100, 20), "Exp : " + character.CurrentXp);
            GUI.Label(new Rect(120, 125, 100, 20), "Level Up : " + character.XpToLvUp);
            GUI.Label(new Rect(120, 150, 220, 150), "Background : " + character.Description);
            GUI.Label(new Rect(240, 25, 100, 20), "Str : " + character.Str);
            GUI.Label(new Rect(240, 50, 100, 20), "Mag : " + character.Mag);
            GUI.Label(new Rect(240, 75, 100, 20), "End : " + character.End);
            GUI.Label(new Rect(240, 100, 100, 20), "Acc: " + character.Acc);
            GUI.Label(new Rect(240, 125, 100, 20), "Agi : " + character.Agi);
        GUI.EndGroup();
    }

    private void ShowCharSkill()
    {
        string[] skillStrings = new string[4] { "No Skill", "No Skill", "No Skill", "No Skill" };
        string[] skillListName = new string[] { "Unlocked", "Unlocked", "Unlocked", "Unlocked", "Unlocked", "Unlocked", "Unlocked" };
        
        int selectedSkillList = 10;
        string name = "";
        BaseCharacter character = new BaseCharacter();
        BaseAbility[] abilities = new BaseAbility[4];
        List<BaseAbility> abilityList = new List<BaseAbility>();
        string target = "";
        string type = "";
        string element = "";
        if (selectedChar == 0)
        {
            character = GameInformation.Cecil;
        }
        else if (selectedChar == 1)
        {
            character = GameInformation.Limca;
        }
        else if (selectedChar == 2)
        {
            character = GameInformation.Galard;
        }
        abilities = character.ChosenAbility;
        abilityList = character.AbilityList;
        name = character.Name;
        GUI.Box(new Rect(0, 0, 200, 30), "");
        GUI.Label(new Rect(20, 5, 160, 30), "Selected Skill for " + name);
        for (int i = 0; i < 4; i++)
        {
            if (abilities[i] != null)
            {
                skillStrings[i] = abilities[i].Name;
            }
            else
            {
                skillStrings[i] = "No Skill";
            }
        }
        for (int i = 0; i < 7; i++)
        {
            if (abilityList[i] != null)
            {
                if (abilityList[i].IsUnlocked == true)
                {
                    skillListName[i] = abilityList[i].Name;
                }
                else
                {
                    skillListName[i] = "Unlocked";
                }
            }
        }
        selectedSkill = GUI.SelectionGrid(new Rect(0, 50, 200, 140), selectedSkill, skillStrings, 1);
        GUI.Box(new Rect(220, 0, Screen.width - 260, Screen.height - 300), "");
        GUI.BeginGroup(new Rect(240,20,Screen.width -300,Screen.height - 300),"");
        if (abilities[selectedSkill] != null)
        {
            GUI.Label(new Rect(0, 0, 100, 20), "Name : " + abilities[selectedSkill].Name);
            GUI.Label(new Rect(0, 25, 100, 20), "Base Power : " + abilities[selectedSkill].BasePower);
            GUI.Label(new Rect(0, 50, 100, 20), "Mp Cost : " + abilities[selectedSkill].MpCost);
            switch (abilities[selectedSkill].SkillType)
            {
                case (BaseAbility.Type.MAGICAL):
                    type = "Magical";
                    break;
                case (BaseAbility.Type.PHYSICAL):
                    type = "Physical";
                    break;
            }
            GUI.Label(new Rect(0, 75, 100, 20), "Skill Type : " + type);
            switch (abilities[selectedSkill].Element.ElementType)
            {
                case (BaseElement.Element.DARK):
                    element = "Dark";
                    break;
                case (BaseElement.Element.EARTH):
                    element = "Earth";
                    break;
                case (BaseElement.Element.ELECTRIC):
                    element = "Electric";
                    break;
                case (BaseElement.Element.FIRE):
                    element = "Fire";
                    break;
                case (BaseElement.Element.LIGHT):
                    element = "Light";
                    break;
                case (BaseElement.Element.NEUTRAL):
                    element = "Neutral";
                    break;
                case (BaseElement.Element.WATER):
                    element = "Water";
                    break;
                case (BaseElement.Element.WIND):
                    element = "Wind";
                    break;
            }
            GUI.Label(new Rect(0, 100, 100, 20), "Element : " + element);
            switch (abilities[selectedSkill].TargetEnemy)
            {
                case (BaseAbility.Target.SINGLE):
                    target = "Single";
                    break;
                case (BaseAbility.Target.ALL):
                    target = "All";
                    break;
            }
            GUI.Label(new Rect(0, 125, 100, 20), "Target : " + target);
            GUI.Label(new Rect(0, 150, 200, 80), abilities[selectedSkill].Description);
        }
        GUI.EndGroup();
        GUI.BeginGroup(new Rect(240, Screen.height - 280, Screen.width - 300, 70), "");
        GUI.Box(new Rect(0, 0, 200, 30), "");
        GUI.Label(new Rect(20, 5, 200, 20), "Set New Skill");
        selectedSkillList = GUI.SelectionGrid(new Rect(0,40, Screen.width-300, 30), selectedSkillList, skillListName, 7);
        SetSkill(selectedChar, selectedSkill, selectedSkillList);
        GUI.EndGroup();
        //Debug.Log("selected skill : " + selectedSkill);
        //Debug.Log("selected skill list : " + selectedSkillList);
    }

    private void SetSkill(int character, int slot, int skill)
    {
        if (skill < 8)
        {
            if (character == 0)
            {
                if (GameInformation.Cecil.AbilityList[skill].IsUnlocked == true && GameInformation.Cecil.AbilityList[skill].IsAdded == false)
                {
                    if (GameInformation.Cecil.ChosenAbility[slot] != null)
                    {
                        foreach (BaseAbility ability in GameInformation.Cecil.AbilityList)
                        {
                            if (GameInformation.Cecil.ChosenAbility[slot].ID == ability.ID)
                            {
                                ability.IsAdded = false;
                            }
                        }
                    }
                    GameInformation.Cecil.AbilityList[skill].IsAdded = true;
                    GameInformation.Cecil.ChosenAbility[slot] = GameInformation.Cecil.AbilityList[skill];
                }
            }
            else if (character == 1)
            {
                if (GameInformation.Limca.AbilityList[skill].IsUnlocked == true && GameInformation.Limca.AbilityList[skill].IsAdded == false)
                {
                    if (GameInformation.Limca.ChosenAbility[slot] != null)
                    {
                        foreach (BaseAbility ability in GameInformation.Limca.AbilityList)
                        {
                            if (GameInformation.Limca.ChosenAbility[slot].ID == ability.ID)
                            {
                                ability.IsAdded = false;
                            }
                        }
                    }
                    GameInformation.Limca.AbilityList[skill].IsAdded = true;
                    GameInformation.Limca.ChosenAbility[slot] = GameInformation.Limca.AbilityList[skill];
                }
            }
            else if (character == 2)
            {
                if (GameInformation.Galard.AbilityList[skill].IsUnlocked == true && GameInformation.Galard.AbilityList[skill].IsAdded == false)
                {
                    if (GameInformation.Galard.ChosenAbility[slot] != null)
                    {
                        foreach (BaseAbility ability in GameInformation.Galard.AbilityList)
                        {
                            if (GameInformation.Galard.ChosenAbility[slot].ID == ability.ID)
                            {
                                ability.IsAdded = false;
                            }
                        }
                    }
                    GameInformation.Galard.AbilityList[skill].IsAdded = true;
                    GameInformation.Galard.ChosenAbility[slot] = GameInformation.Galard.AbilityList[skill];
                }
            }
        }
    }

    private void ShowCharEquip()
    {
        string[] equipmentNames = new string[4] { "Weapon", "Armor", "Boots", "Accessory" };
        string name = "";
        BaseCharacter character = new BaseCharacter();
        if (selectedChar == 0)
        {
            character = GameInformation.Cecil;
        }
        else if (selectedChar == 1)
        {
            character = GameInformation.Limca;
        }
        else if (selectedChar == 2)
        {
            character = GameInformation.Galard;
        }
        name = character.Name;
        //Debug.Log(character.Weapon.Name);
        if (character.Weapon.Name != null)
        {
            equipmentNames[0] = character.Weapon.Name;
        }
        else
        {
            equipmentNames[0] = "Weapon";
        }
        if (character.Armor.Name != null )
        {
            equipmentNames[1] = character.Armor.Name;
        }
        else
        {
            equipmentNames[1] = "Armor";
        }
        if (character.Boots.Name != null)
        {
            equipmentNames[2] = character.Boots.Name;
        }
        else
        {
            equipmentNames[2] = "Boots";
        }
        if (character.Accessory.Name != null)
        {
            equipmentNames[3] = character.Accessory.Name;
        }
        else
        {
            equipmentNames[3] = "Accessories";
        }
        GUI.Box(new Rect(0, 0, 200, 30), "");
        GUI.Label(new Rect(20, 5, 160, 30), "Equipment for " + name);
        equipment = GUI.SelectionGrid(new Rect(0, 50, 200, 140), equipment, equipmentNames, 1);
        GUI.Box(new Rect(220, 0, (Screen.width - 280)/2, Screen.height - 300), "");
        GUI.BeginGroup(new Rect(240, 20, ((Screen.width - 280) / 2) - 40, Screen.height - 300), "");
        if (equipment == 0)
        {
            //Debug.Log("before validate use weapon");
            //Debug.Log("weapon id : " + character.Weapon.ID);
            if(character.Weapon.ID != null)
            {
                //Debug.Log("show weapon data");
                GUI.Label(new Rect(0, 0, ((Screen.width - 280) / 2), 20), "Name : " + character.Weapon.Name);
                //Debug.Log(character.Weapon.Name);
                GUI.Label(new Rect(0, 25, 100, 20), "Str : " + character.Weapon.Str);
                GUI.Label(new Rect(0, 50, 100, 20), "Mag : " + character.Weapon.Mag);
                GUI.Label(new Rect(0, 75, 100, 20), "End : " + character.Weapon.End);
                GUI.Label(new Rect(120, 25, 100, 20), "Agi : " + character.Weapon.Agi);
                GUI.Label(new Rect(120, 50, 100, 20), "Acc : " + character.Weapon.Acc);
                GUI.Label(new Rect(0, 100, ((Screen.width - 280) / 2) - 40, 80), character.Weapon.Description);
            }
        }
        else if (equipment == 1)
        {
            if (character.Armor.ID != null)
            {
                GUI.Label(new Rect(0, 0, ((Screen.width - 280) / 2), 20), "Name : " + character.Armor.Name);
                GUI.Label(new Rect(0, 25, 100, 20), "Str : " + character.Armor.Str);
                GUI.Label(new Rect(0, 50, 100, 20), "Mag : " + character.Armor.Mag);
                GUI.Label(new Rect(0, 75, 100, 20), "End : " + character.Armor.End);
                GUI.Label(new Rect(120, 25, 100, 20), "Agi : " + character.Armor.Agi);
                GUI.Label(new Rect(120, 50, 100, 20), "Acc : " + character.Armor.Acc);
                GUI.Label(new Rect(0, 100, ((Screen.width - 280) / 2) - 40, 80), character.Armor.Description);
            }
        }
        else if (equipment == 2)
        {
            if (character.Boots.ID != null)
            {
                GUI.Label(new Rect(0, 0, ((Screen.width - 280) / 2), 20), "Name : " + character.Boots.Name);
                GUI.Label(new Rect(0, 25, 100, 20), "Str : " + character.Boots.Str);
                GUI.Label(new Rect(0, 50, 100, 20), "Mag : " + character.Boots.Mag);
                GUI.Label(new Rect(0, 75, 100, 20), "End : " + character.Boots.End);
                GUI.Label(new Rect(120, 25, 100, 20), "Agi : " + character.Boots.Agi);
                GUI.Label(new Rect(120, 50, 100, 20), "Acc : " + character.Boots.Acc);
                GUI.Label(new Rect(0, 100, ((Screen.width - 280) / 2) - 40, 80), character.Boots.Description);
            }
        }
        else if (equipment == 3)
        {
            if(character.Accessory.ID != null)
            {
                GUI.Label(new Rect(0, 0, ((Screen.width - 280) / 2), 20), "Name : " + character.Accessory.Name);
                GUI.Label(new Rect(0, 25, 100, 20), "Str : " + character.Accessory.Str);
                GUI.Label(new Rect(0, 50, 100, 20), "Mag : " + character.Accessory.Mag);
                GUI.Label(new Rect(0, 75, 100, 20), "End : " + character.Accessory.End);
                GUI.Label(new Rect(120, 25, 100, 20), "Agi : " + character.Accessory.Agi);
                GUI.Label(new Rect(120, 50, 100, 20), "Acc : " + character.Accessory.Acc);
                GUI.Label(new Rect(0, 100, ((Screen.width - 280) / 2) - 40, 80), character.Accessory.Description);
            }
        }
        GUI.EndGroup();
        GUI.Box(new Rect(((Screen.width - 280) / 2)+240, 0, ((Screen.width - 280) / 2) + 40, Screen.height - 100), "");
        GUI.BeginGroup(new Rect(((Screen.width - 280) / 2) + 260, 20,((Screen.width - 280) / 2), Screen.height - 140), "");
        if (equipment == 0)
        {
            //Debug.Log("weapon");
            ShowWeaponInventory(character);
        }
        else if (equipment == 1)
        {
            //Debug.Log("armor");
            ShowArmorInventory(character);
        }
        else if (equipment == 2)
        {
            //Debug.Log("boots");
            ShowBootsInventory(character);
        }
        else if (equipment == 3)
        {
            //Debug.Log("acc");
            ShowAccessoriesInventory(character);
        }
        GUI.EndGroup();
    }

    private void ShowAccessoriesInventory(BaseCharacter character)
    {
        bool showButton = false;
        int inventoryCount = GameInformation.accessoriesInventory.Count;
        int height = inventoryCount * 80 + 30;
        equipScrollPosition = GUI.BeginScrollView(new Rect(0, 0, ((Screen.width - 280) / 2), Screen.height - 140), equipScrollPosition, new Rect(0, 0, 430, height));
        for (int i = 0; i < inventoryCount; i++)
        {
            GUI.Label(new Rect(20, i * 80 + 25, 100, 20), GameInformation.accessoriesInventory[i].Name);
            GUI.Label(new Rect(20, i * 80 + 50, 100, 20), "Str : " + GameInformation.accessoriesInventory[i].Str);
            GUI.Label(new Rect(80, i * 80 + 50, 100, 20), "Mag : " + GameInformation.accessoriesInventory[i].Mag);
            GUI.Label(new Rect(140, i * 80 + 50, 100, 20), "End : " + GameInformation.accessoriesInventory[i].End);
            GUI.Label(new Rect(200, i * 80 + 50, 100, 20), "Agi : " + GameInformation.accessoriesInventory[i].Agi);
            GUI.Label(new Rect(260, i * 80 + 50, 100, 20), "Acc : " + GameInformation.accessoriesInventory[i].Acc);
            GUI.Label(new Rect(20, i * 80 + 75, 500, 20), GameInformation.accessoriesInventory[i].Description);
            if (GameInformation.accessoriesInventory[i].UseByCecil == true && character.CharacterUnitName == BaseCharacter.CharacterUnit.CECIL && GameInformation.accessoriesInventory[i].Used == false)
            {
                showButton = true;
            }
            else if (GameInformation.accessoriesInventory[i].UseByLimca == true && character.CharacterUnitName == BaseCharacter.CharacterUnit.LIMCA && GameInformation.accessoriesInventory[i].Used == false)
            {
                showButton = true;
            }
            else if (GameInformation.accessoriesInventory[i].UseByGalard == true && character.CharacterUnitName == BaseCharacter.CharacterUnit.GALARD && GameInformation.accessoriesInventory[i].Used == false)
            {
                showButton = true;
            }
            else
            {
                showButton = false;
            }
            if (showButton == true)
            {
                if (GUI.Button(new Rect(210, i * 80 + 20, 100, 30), "Change"))
                {
                    if (character.CharacterUnitName == BaseCharacter.CharacterUnit.CECIL)
                    {
                        if (GameInformation.Cecil.Accessory.ID != null)
                        {
                            for (int j = 0; j < inventoryCount; j++)
                            {
                                if (GameInformation.Cecil.Accessory.ID == GameInformation.accessoriesInventory[j].ID && GameInformation.accessoriesInventory[j].Used == true)
                                {
                                    GameInformation.accessoriesInventory[i].Used = false;
                                }
                            }
                        }
                        GameInformation.accessoriesInventory[i].Used = true;
                        GameInformation.Cecil.Accessory = GameInformation.accessoriesInventory[i];
                        GameInformation.Cecil.CalculateBonus();
                    }
                    else if (character.CharacterUnitName == BaseCharacter.CharacterUnit.LIMCA)
                    {
                        if (GameInformation.Limca.Accessory != null)
                        {
                            for (int j = 0; j < inventoryCount; j++)
                            {
                                if (GameInformation.Limca.Accessory.ID == GameInformation.accessoriesInventory[j].ID && GameInformation.accessoriesInventory[j].Used == true)
                                {
                                    GameInformation.accessoriesInventory[i].Used = false;
                                }
                            }
                        }
                        GameInformation.accessoriesInventory[i].Used = true;
                        GameInformation.Limca.Accessory = GameInformation.accessoriesInventory[i];
                        GameInformation.Limca.CalculateBonus();
                    }
                    else if (character.CharacterUnitName == BaseCharacter.CharacterUnit.GALARD)
                    {
                        if (GameInformation.Galard.Accessory != null)
                        {
                            for (int j = 0; j < inventoryCount; j++)
                            {
                                if (GameInformation.Galard.Accessory.ID == GameInformation.accessoriesInventory[j].ID && GameInformation.accessoriesInventory[j].Used == true)
                                {
                                    GameInformation.accessoriesInventory[i].Used = false;
                                }
                            }
                        }
                        GameInformation.accessoriesInventory[i].Used = true;
                        GameInformation.Galard.Accessory = GameInformation.accessoriesInventory[i];
                        GameInformation.Galard.CalculateBonus();
                    }
                }
            }
        }
        GUI.EndScrollView();
    }

    private void ShowBootsInventory(BaseCharacter character)
    {
        bool showButton = false;
        int inventoryCount = GameInformation.bootsInventory.Count;
        int height = inventoryCount * 80 + 30;
        equipScrollPosition = GUI.BeginScrollView(new Rect(0, 0, ((Screen.width - 280) / 2), Screen.height - 140), equipScrollPosition, new Rect(0, 0, 430, height));
        for (int i = 0; i < inventoryCount; i++)
        {
            GUI.Label(new Rect(20, i * 80 + 25, 100, 20), GameInformation.bootsInventory[i].Name);
            GUI.Label(new Rect(20, i * 80 + 50, 100, 20), "Str : " + GameInformation.bootsInventory[i].Str);
            GUI.Label(new Rect(80, i * 80 + 50, 100, 20), "Mag : " + GameInformation.bootsInventory[i].Mag);
            GUI.Label(new Rect(140, i * 80 + 50, 100, 20), "End : " + GameInformation.bootsInventory[i].End);
            GUI.Label(new Rect(200, i * 80 + 50, 100, 20), "Agi : " + GameInformation.bootsInventory[i].Agi);
            GUI.Label(new Rect(260, i * 80 + 50, 100, 20), "Acc : " + GameInformation.bootsInventory[i].Acc);
            GUI.Label(new Rect(20, i * 80 + 75, 500, 20), GameInformation.bootsInventory[i].Description);
            if (GameInformation.bootsInventory[i].UseByCecil == true && character.CharacterUnitName == BaseCharacter.CharacterUnit.CECIL && GameInformation.bootsInventory[i].Used == false)
            {
                showButton = true;
            }
            else if (GameInformation.bootsInventory[i].UseByLimca == true && character.CharacterUnitName == BaseCharacter.CharacterUnit.LIMCA && GameInformation.bootsInventory[i].Used == false)
            {
                showButton = true;
            }
            else if (GameInformation.bootsInventory[i].UseByGalard == true && character.CharacterUnitName == BaseCharacter.CharacterUnit.GALARD && GameInformation.bootsInventory[i].Used == false)
            {
                showButton = true;
            }
            else
            {
                showButton = false;
            }
            if (showButton == true)
            {
                if (GUI.Button(new Rect(210, i * 80 + 20, 100, 30), "Change"))
                {
                    if (character.CharacterUnitName == BaseCharacter.CharacterUnit.CECIL)
                    {
                        //Debug.Log("current ID : " + GameInformation.Cecil.Boots.ID);
                        if (GameInformation.Cecil.Boots.ID != null)
                        {
                            for (int j = 0; j < inventoryCount; j++)
                            {
                                //Debug.Log("find id : " + GameInformation.bootsInventory[j].ID);
                                if (GameInformation.Cecil.Boots.ID == GameInformation.bootsInventory[j].ID && GameInformation.bootsInventory[j].Used == true && GameInformation.Cecil.Boots.Index == GameInformation.bootsInventory[j].Index)
                                {
                                    //Debug.Log("match");
                                    GameInformation.bootsInventory[j].Used = false;
                                    //GameInformation.bootsInventory.RemoveAt(j);
                                    //BaseBoots boots = new BaseBoots(GameInformation.Cecil.Boots.ID);
                                    //GameInformation.bootsInventory.Add(boots);
                                }
                            }
                        }
                        GameInformation.bootsInventory[i].Used = true;
                        GameInformation.Cecil.Boots = GameInformation.bootsInventory[i];
                        GameInformation.Cecil.CalculateBonus();
                    }
                    else if (character.CharacterUnitName == BaseCharacter.CharacterUnit.LIMCA)
                    {
                        if (GameInformation.Limca.Boots != null)
                        {
                            //Debug.Log("current ID : " + GameInformation.Limca.Boots.ID);
                            for (int j = 0; j < inventoryCount; j++)
                            {
                                //Debug.Log("find id : " + GameInformation.bootsInventory[j].ID);
                                if (GameInformation.Limca.Boots.ID == GameInformation.bootsInventory[j].ID && GameInformation.bootsInventory[j].Used == true && GameInformation.Limca.Boots.Index == GameInformation.bootsInventory[j].Index)
                                {
                                    //Debug.Log("match");
                                    GameInformation.bootsInventory[j].Used = false;
                                    //GameInformation.bootsInventory.RemoveAt(j);
                                    //BaseBoots boots = new BaseBoots(GameInformation.Limca.Boots.ID);
                                    //GameInformation.bootsInventory.Add(boots);
                                }
                            }
                        }
                        GameInformation.bootsInventory[i].Used = true;
                        GameInformation.Limca.Boots = GameInformation.bootsInventory[i];
                        GameInformation.Limca.CalculateBonus();
                    }
                    else if (character.CharacterUnitName == BaseCharacter.CharacterUnit.GALARD)
                    {
                        if (GameInformation.Galard.Boots != null)
                        {
                            //Debug.Log("current ID : " + GameInformation.Galard.Boots.ID);
                            for (int j = 0; j < inventoryCount; j++)
                            {
                                //Debug.Log("find id : " + GameInformation.bootsInventory[j].ID);
                                if (GameInformation.Galard.Boots.ID == GameInformation.bootsInventory[j].ID && GameInformation.bootsInventory[j].Used == true && GameInformation.Galard.Boots.Index == GameInformation.bootsInventory[j].Index)
                                {
                                    //Debug.Log("macth");
                                    GameInformation.bootsInventory[j].Used = false;
                                    //GameInformation.bootsInventory.RemoveAt(j);
                                    //BaseBoots boots = new BaseBoots(GameInformation.Galard.Boots.ID);
                                    //GameInformation.bootsInventory.Add(boots);
                                }
                            }
                        }
                        GameInformation.bootsInventory[i].Used = true;
                        GameInformation.Galard.Boots = GameInformation.bootsInventory[i];
                        GameInformation.Galard.CalculateBonus();
                    }
                }
            }
        }
        GUI.EndScrollView();
    }

    private void ShowArmorInventory(BaseCharacter character)
    {
        bool showButton = false;
        int inventoryCount = GameInformation.armorInventory.Count;
        int height = inventoryCount * 80 + 30;
        equipScrollPosition = GUI.BeginScrollView(new Rect(0, 0, ((Screen.width - 280) / 2), Screen.height - 140), equipScrollPosition, new Rect(0, 0, 430, height));
        for (int i = 0; i < inventoryCount; i++)
        {
            GUI.Label(new Rect(20, i * 80 + 25, 100, 20), GameInformation.armorInventory[i].Name);
            GUI.Label(new Rect(20, i * 80 + 50, 100, 20), "Str : " + GameInformation.armorInventory[i].Str);
            GUI.Label(new Rect(80, i * 80 + 50, 100, 20), "Mag : " + GameInformation.armorInventory[i].Mag);
            GUI.Label(new Rect(140, i * 80 + 50, 100, 20), "End : " + GameInformation.armorInventory[i].End);
            GUI.Label(new Rect(200, i * 80 + 50, 100, 20), "Agi : " + GameInformation.armorInventory[i].Agi);
            GUI.Label(new Rect(260, i * 80 + 50, 100, 20), "Acc : " + GameInformation.armorInventory[i].Acc);
            GUI.Label(new Rect(20, i * 80 + 75, 500, 20), GameInformation.armorInventory[i].Description);
            if (GameInformation.armorInventory[i].UseByCecil == true && character.CharacterUnitName == BaseCharacter.CharacterUnit.CECIL && GameInformation.armorInventory[i].Used == false)
            {
                showButton = true;
            }
            if (GameInformation.armorInventory[i].UseByLimca == true && character.CharacterUnitName == BaseCharacter.CharacterUnit.LIMCA && GameInformation.armorInventory[i].Used == false)
            {
                showButton = true;
            }
            if (GameInformation.armorInventory[i].UseByGalard == true && character.CharacterUnitName == BaseCharacter.CharacterUnit.GALARD && GameInformation.armorInventory[i].Used == false)
            {
                showButton = true;
            }
            if (showButton == true)
            {
                if (GUI.Button(new Rect(210, i * 80 + 20, 100, 30), "Change"))
                {
                    if (character.CharacterUnitName == BaseCharacter.CharacterUnit.CECIL)
                    {
                        if (GameInformation.Cecil.Armor.ID != null)
                        {
                            for (int j = 0; j < inventoryCount; j++)
                            {
                                if (GameInformation.Cecil.Armor.ID == GameInformation.armorInventory[j].ID && GameInformation.armorInventory[j].Used == true)
                                {
                                    GameInformation.armorInventory[i].Used = false;
                                }
                            }
                        }
                        GameInformation.armorInventory[i].Used = true;
                        GameInformation.Cecil.Armor = GameInformation.armorInventory[i];
                        GameInformation.Cecil.CalculateBonus();
                    }
                    else if (character.CharacterUnitName == BaseCharacter.CharacterUnit.LIMCA)
                    {
                        if (GameInformation.Limca.Armor != null)
                        {
                            for (int j = 0; j < inventoryCount; j++)
                            {
                                if (GameInformation.Limca.Armor.ID == GameInformation.armorInventory[j].ID && GameInformation.armorInventory[j].Used == true)
                                {
                                    GameInformation.armorInventory[i].Used = false;
                                }
                            }
                        }
                        GameInformation.armorInventory[i].Used = true;
                        GameInformation.Limca.Armor = GameInformation.armorInventory[i];
                        GameInformation.Limca.CalculateBonus();
                    }
                    else if (character.CharacterUnitName == BaseCharacter.CharacterUnit.GALARD)
                    {
                        if (GameInformation.Galard.Armor != null)
                        {
                            for (int j = 0; j < inventoryCount; j++)
                            {
                                if (GameInformation.Galard.Armor.ID == GameInformation.armorInventory[j].ID && GameInformation.armorInventory[j].Used == true)
                                {
                                    GameInformation.armorInventory[i].Used = false;
                                }
                            }
                        }
                        GameInformation.armorInventory[i].Used = true;
                        GameInformation.Galard.Armor = GameInformation.armorInventory[i];
                        GameInformation.Galard.CalculateBonus();
                    }
                }
            }
        }
        GUI.EndScrollView();
    }

    private void ShowWeaponInventory(BaseCharacter character)
    {
        //Debug.Log("show weapon");
        //Debug.Log("char name : " + character.Name);
        //Debug.Log("use by cecil : " + character.Weapon.UseByCecil);
        //Debug.Log("use by limca : " + character.Weapon.UseByLimca);
        //Debug.Log("use by galard : " + character.Weapon.UseByGalard);
        //Debug.Log("used : " + character.Weapon.Used);
        bool showButton = false;
        int inventoryCount = GameInformation.weaponInventory.Count;
        int height = inventoryCount * 80 + 30;
        //Debug.Log("scroll height : "+ height);
        equipScrollPosition = GUI.BeginScrollView(new Rect(0, 0, ((Screen.width - 280) / 2), Screen.height - 140), equipScrollPosition, new Rect(0, 0, 430, height));
        //for (int i = 0; i < inventoryCount; i++)
        //{
        //    Debug.Log("weapon at " + i + " used : " + GameInformation.weaponInventory[i].Used);
        //}
        //for (int i = 0; i < inventoryCount; i++)
        //{
        //    Debug.Log("weapon at " + i + " index : " + GameInformation.weaponInventory[i].Index);
        //}
        for (int i = 0; i < inventoryCount; i++)
        {
            //Debug.Log(GameInformation.weaponInventory[i].Name);
            GUI.Label(new Rect(20, i * 80 + 25, 100, 20), GameInformation.weaponInventory[i].Name);
            GUI.Label(new Rect(20, i * 80 + 50, 100, 20), "Str : " + GameInformation.weaponInventory[i].Str);
            GUI.Label(new Rect(80, i * 80 + 50, 100, 20), "Mag : " + GameInformation.weaponInventory[i].Mag);
            GUI.Label(new Rect(140, i * 80 + 50, 100, 20), "End : " + GameInformation.weaponInventory[i].End);
            GUI.Label(new Rect(200, i * 80 + 50, 100, 20), "Agi : " + GameInformation.weaponInventory[i].Agi);
            GUI.Label(new Rect(260, i * 80 + 50, 100, 20), "Acc : " + GameInformation.weaponInventory[i].Acc);
            GUI.Label(new Rect(20, i * 80 + 75, 500, 20), GameInformation.weaponInventory[i].Description);
            if (GameInformation.weaponInventory[i].UseByCecil == true && character.CharacterUnitName == BaseCharacter.CharacterUnit.CECIL && GameInformation.weaponInventory[i].Used == false)
            {
                showButton = true;
            }
            else if (GameInformation.weaponInventory[i].UseByLimca == true && character.CharacterUnitName == BaseCharacter.CharacterUnit.LIMCA && GameInformation.weaponInventory[i].Used == false)
            {
                showButton = true;
            }
            else if (GameInformation.weaponInventory[i].UseByGalard == true && character.CharacterUnitName == BaseCharacter.CharacterUnit.GALARD && GameInformation.weaponInventory[i].Used == false)
            {
                showButton = true;
            }
            else
            {
                showButton = false;
            }
            if (showButton == true)
            {
                if (GUI.Button(new Rect(210, i * 80 + 20, 100, 30), "Change"))
                {
                    //Debug.Log("tets");
                    if (character.CharacterUnitName == BaseCharacter.CharacterUnit.CECIL)
                    {
                        //Debug.Log("test2");
                        if (GameInformation.Cecil.Weapon.ID != null)
                        {
                            //Debug.Log("current ID : " + GameInformation.Cecil.Weapon.ID);
                            for (int j = 0; j < inventoryCount; j++)
                            {
                                //Debug.Log("find id : " + GameInformation.weaponInventory[j].ID);
                                if (GameInformation.Cecil.Weapon.ID == GameInformation.weaponInventory[j].ID && GameInformation.weaponInventory[j].Used == true)
                                {
                                    //Debug.Log("match");
                                    GameInformation.weaponInventory[j].Used = false;
                                }
                            }
                        }
                        //Debug.Log("weapon at " + i + " ID : " + GameInformation.weaponInventory[i].ID);
                        GameInformation.weaponInventory[i].Used = true;
                        //Debug.Log("weapon at " + i + " ID : " + GameInformation.weaponInventory[i].ID);
                        GameInformation.Cecil.Weapon = GameInformation.weaponInventory[i];
                        GameInformation.Cecil.Weapon.Used = true;
                        GameInformation.Cecil.CalculateBonus();
                    }
                    //else if (character.CharacterUnitName == BaseCharacter.CharacterUnit.LIMCA)
                    //{
                    //    if (GameInformation.Limca.Weapon.ID != null)
                    //    {
                    //        for (int j = 0; j < inventoryCount; j++)
                    //        {
                    //            if (GameInformation.Limca.Weapon.ID == GameInformation.weaponInventory[j].ID && GameInformation.weaponInventory[j].Used == true)
                    //            {
                    //                GameInformation.weaponInventory[j].Used = false;
                    //            }
                    //        }
                    //    }
                    //    GameInformation.weaponInventory[i].Used = true;
                    //    GameInformation.Limca.Weapon = GameInformation.weaponInventory[i];
                    //    GameInformation.Limca.CalculateBonus();
                    //}
                    //else if (character.CharacterUnitName == BaseCharacter.CharacterUnit.GALARD)
                    //{
                    //    if (GameInformation.Galard.Weapon.ID != null)
                    //    {
                    //        for (int j = 0; j < inventoryCount; j++)
                    //        {
                    //            if (GameInformation.Galard.Weapon.ID == GameInformation.weaponInventory[j].ID && GameInformation.weaponInventory[j].Used == true)
                    //            {
                    //                GameInformation.weaponInventory[j].Used = false;
                    //            }
                    //        }
                    //    }
                    //    GameInformation.weaponInventory[i].Used = true;
                    //    GameInformation.Galard.Weapon = GameInformation.weaponInventory[i];
                    //    GameInformation.Galard.CalculateBonus();
                    //}
                }
            }
        }
        GUI.EndScrollView();
    }

    private void ShowItem()
    {
        int usableCount = GameInformation.usableInventory.Count;
        int miscCount = GameInformation.miscInventory.Count;
        int giftCount = GameInformation.giftInventory.Count;
        int height = (usableCount + miscCount + giftCount) * 80 + 30;
        GUI.BeginGroup(new Rect(0, 0, Screen.width - 40, Screen.height - 100));
        GUI.Box(new Rect(0, 0, Screen.width - 250, Screen.height - 100),"");
        itemScrollPosition = GUI.BeginScrollView(new Rect(20, 20, Screen.width - 140, Screen.height - 140), itemScrollPosition, new Rect(0, 0, 430, height));
        for (int i = 0; i < GameInformation.usableInventory.Count; i++)
        {
            GUI.Label(new Rect(20, i * 80 + 25, 200, 20), GameInformation.usableInventory[i].Name);
            GUI.Label(new Rect(240, i * 80 + 25, 100, 20), "Owned : " + GameInformation.usableInventory[i].Amount);
            GUI.Label(new Rect(20, i * 80 + 65, 500, 20), GameInformation.usableInventory[i].Description);
            if (GUI.Button(new Rect(310, i * 80 + 20, 100, 30), "Use"))
            {
                showItemTarget = false;
                itemIndex = i;
                showItemTarget = true;
            }
        }
        int usableHeight = usableCount * 80 + 25;
        for (int i = 0; i < GameInformation.miscInventory.Count; i++)
        {
            GUI.Label(new Rect(20, i * 80 + usableHeight, 200, 20), GameInformation.miscInventory[i].Name);
            GUI.Label(new Rect(240, i * 80 + usableHeight, 100, 20), "Owned : " + GameInformation.miscInventory[i].Amount);
            GUI.Label(new Rect(20, i * 80 + usableHeight + 40, 500, 20), GameInformation.miscInventory[i].Description);
        }
        int miscHeight = miscCount * 80 + usableHeight;
        for (int i = 0; i < GameInformation.giftInventory.Count; i++)
        {
            GUI.Label(new Rect(20, i * 80 + miscHeight, 200, 20), GameInformation.giftInventory[i].Name);
            GUI.Label(new Rect(240, i * 80 + miscHeight, 100, 20), "Owned : " + GameInformation.giftInventory[i].Amount);
            GUI.Label(new Rect(20, i * 80 + miscHeight + 40, 500, 20), GameInformation.giftInventory[i].Description);
        }
        GUI.EndScrollView();
        GUI.EndGroup();
        ShowTargetItem(itemIndex);
    }

    private void ShowTargetItem(int index)
    {
        if (showItemTarget == true)
        {
            GUI.BeginGroup(new Rect(Screen.width - 190, 0, 100, 30), "");
            //Debug.Log("item ID : "+GameInformation.usableInventory[index].ID);
            if (GameInformation.usableInventory[index].ItemTypeValue == Item.ItemType.HEALTH)
            {
                if (GameInformation.Cecil.CurrentHp > 0 && GameInformation.Cecil.CurrentHp < GameInformation.Cecil.Hp)
                {
                    if (GUI.Button(new Rect(0, 0, 100, 30), GameInformation.Cecil.Name))
                    {
                        int heal = GameInformation.usableInventory[index].Heal(GameInformation.Cecil.Hp);
                        GameInformation.Cecil.CurrentHp += heal;
                        if (GameInformation.Cecil.CurrentHp > GameInformation.Cecil.Hp)
                        {
                            GameInformation.Cecil.CurrentHp = GameInformation.Cecil.Hp;
                        }
                        showItemTarget = false;
                        GameInformation.usableInventory[index].Amount -= 1;
                        if (GameInformation.usableInventory[index].Amount == 0)
                        {
                            GameInformation.usableInventory.RemoveAt(index);
                        }
                    }
                }
                if (GameInformation.Limca.CurrentHp > 0 && GameInformation.Limca.CurrentHp < GameInformation.Limca.Hp)
                {
                    if (GUI.Button(new Rect(0, 40, 100, 30), GameInformation.Limca.Name))
                    {
                        int heal = GameInformation.usableInventory[index].Heal(GameInformation.Limca.Hp);
                        GameInformation.Limca.CurrentHp += heal;
                        if (GameInformation.Limca.CurrentHp > GameInformation.Limca.Hp)
                        {
                            GameInformation.Limca.CurrentHp = GameInformation.Limca.Hp;
                        }
                        showItemTarget = false;
                        GameInformation.usableInventory[index].Amount -= 1;
                        if (GameInformation.usableInventory[index].Amount == 0)
                        {
                            GameInformation.usableInventory.RemoveAt(index);
                        }
                    }
                }
                if (GameInformation.Galard.CurrentHp > 0 && GameInformation.Galard.CurrentHp < GameInformation.Galard.Hp)
                {
                    if (GUI.Button(new Rect(0, 80, 100, 30), GameInformation.Galard.Name))
                    {
                        int heal = GameInformation.usableInventory[index].Heal(GameInformation.Galard.Hp);
                        GameInformation.Galard.CurrentHp += heal;
                        if (GameInformation.Galard.CurrentHp > GameInformation.Galard.Hp)
                        {
                            GameInformation.Galard.CurrentHp = GameInformation.Galard.Hp;
                        }
                        showItemTarget = false;
                        GameInformation.usableInventory[index].Amount -= 1;
                        if (GameInformation.usableInventory[index].Amount == 0)
                        {
                            GameInformation.usableInventory.RemoveAt(index);
                        }
                    }
                }
            }
            else if (GameInformation.usableInventory[index].ItemTypeValue == Item.ItemType.MANA)
            {
                if (GameInformation.Cecil.CurrentHp > 0 && GameInformation.Cecil.CurrentMp < GameInformation.Cecil.Mp)
                {
                    if (GUI.Button(new Rect(0, 0, 100, 30), GameInformation.Cecil.Name))
                    {
                        int heal = GameInformation.usableInventory[index].Heal(GameInformation.Cecil.Mp);
                        GameInformation.Cecil.CurrentMp += heal;
                        if (GameInformation.Cecil.CurrentMp > GameInformation.Cecil.Mp)
                        {
                            GameInformation.Cecil.CurrentMp = GameInformation.Cecil.Mp;
                        }
                        showItemTarget = false;
                        GameInformation.usableInventory[index].Amount -= 1;
                        if (GameInformation.usableInventory[index].Amount == 0)
                        {
                            GameInformation.usableInventory.RemoveAt(index);
                        }
                    }
                }
                if (GameInformation.Limca.CurrentHp > 0 && GameInformation.Limca.CurrentMp < GameInformation.Limca.Mp)
                {
                    if (GUI.Button(new Rect(0, 40, 100, 30), GameInformation.Limca.Name))
                    {
                        int heal = GameInformation.usableInventory[index].Heal(GameInformation.Limca.Mp);
                        GameInformation.Limca.CurrentMp += heal;
                        if (GameInformation.Limca.CurrentMp > GameInformation.Limca.Mp)
                        {
                            GameInformation.Limca.CurrentMp = GameInformation.Limca.Mp;
                        }
                        showItemTarget = false;
                        GameInformation.usableInventory[index].Amount -= 1;
                        if (GameInformation.usableInventory[index].Amount == 0)
                        {
                            GameInformation.usableInventory.RemoveAt(index);
                        }
                    }
                }
                if (GameInformation.Galard.CurrentHp > 0 && GameInformation.Galard.CurrentMp < GameInformation.Galard.Mp)
                {
                    if (GUI.Button(new Rect(0, 80, 100, 30), GameInformation.Galard.Name))
                    {
                        int heal = GameInformation.usableInventory[index].Heal(GameInformation.Galard.Mp);
                        GameInformation.Galard.CurrentMp += heal;
                        if (GameInformation.Galard.CurrentMp > GameInformation.Galard.Mp)
                        {
                            GameInformation.Galard.CurrentMp = GameInformation.Galard.Mp;
                        }
                        showItemTarget = false;
                        GameInformation.usableInventory[index].Amount -= 1;
                        if (GameInformation.usableInventory[index].Amount == 0)
                        {
                            GameInformation.usableInventory.RemoveAt(index);
                        }
                    }
                }
            }
            else if (GameInformation.usableInventory[index].ItemTypeValue == Item.ItemType.SPECIAL)
            {
                if (GameInformation.usableInventory[index].ID == "IT10")
                {
                    if (GameInformation.Cecil.CurrentHp > 0)
                    {
                        if (GameInformation.Cecil.CurrentHp < GameInformation.Cecil.Hp || GameInformation.Cecil.CurrentMp < GameInformation.Cecil.Mp)
                        {
                            if (GUI.Button(new Rect(0, 0, 100, 30), GameInformation.Cecil.Name))
                            {
                                int healHp = GameInformation.usableInventory[index].Heal(GameInformation.Cecil.Hp);
                                int healMp = GameInformation.usableInventory[index].Heal(GameInformation.Cecil.Mp);
                                GameInformation.Cecil.CurrentMp += healHp;
                                GameInformation.Cecil.CurrentMp += healMp;
                                if (GameInformation.Cecil.CurrentHp > GameInformation.Cecil.Hp)
                                {
                                    GameInformation.Cecil.CurrentHp = GameInformation.Cecil.Hp;
                                }
                                if (GameInformation.Cecil.CurrentMp > GameInformation.Cecil.Mp)
                                {
                                    GameInformation.Cecil.CurrentMp = GameInformation.Cecil.Mp;
                                }
                                showItemTarget = false;
                                GameInformation.usableInventory[index].Amount -= 1;
                                if (GameInformation.usableInventory[index].Amount == 0)
                                {
                                    GameInformation.usableInventory.RemoveAt(index);
                                }
                            }
                        }
                    }
                    if (GameInformation.Limca.CurrentHp > 0)
                    {
                        if (GameInformation.Limca.CurrentHp < GameInformation.Limca.Hp || GameInformation.Limca.CurrentMp < GameInformation.Limca.Mp)
                        {
                            if (GUI.Button(new Rect(0, 40, 100, 30), GameInformation.Limca.Name))
                            {
                                int healHp = GameInformation.usableInventory[index].Heal(GameInformation.Limca.Hp);
                                int healMp = GameInformation.usableInventory[index].Heal(GameInformation.Limca.Mp);
                                GameInformation.Limca.CurrentMp += healHp;
                                GameInformation.Limca.CurrentMp += healMp;
                                if (GameInformation.Limca.CurrentHp > GameInformation.Limca.Hp)
                                {
                                    GameInformation.Limca.CurrentHp = GameInformation.Limca.Hp;
                                }
                                if (GameInformation.Limca.CurrentMp > GameInformation.Limca.Mp)
                                {
                                    GameInformation.Limca.CurrentMp = GameInformation.Limca.Mp;
                                }
                                showItemTarget = false;
                                GameInformation.usableInventory[index].Amount -= 1;
                                if (GameInformation.usableInventory[index].Amount == 0)
                                {
                                    GameInformation.usableInventory.RemoveAt(index);
                                }
                            }
                        }   
                    }
                    if (GameInformation.Galard.CurrentHp > 0)
                    {
                        if (GameInformation.Galard.CurrentHp < GameInformation.Galard.Hp || GameInformation.Galard.CurrentMp < GameInformation.Galard.Mp)
                        {
                            if (GUI.Button(new Rect(0, 80, 100, 30), GameInformation.Galard.Name))
                            {
                                int healHp = GameInformation.usableInventory[index].Heal(GameInformation.Galard.Hp);
                                int healMp = GameInformation.usableInventory[index].Heal(GameInformation.Galard.Mp);
                                GameInformation.Galard.CurrentMp += healHp;
                                GameInformation.Galard.CurrentMp += healMp;
                                if (GameInformation.Galard.CurrentHp > GameInformation.Galard.Hp)
                                {
                                    GameInformation.Galard.CurrentHp = GameInformation.Galard.Hp;
                                }
                                if (GameInformation.Galard.CurrentMp > GameInformation.Galard.Mp)
                                {
                                    GameInformation.Galard.CurrentMp = GameInformation.Galard.Mp;
                                }
                                showItemTarget = false;
                                GameInformation.usableInventory[index].Amount -= 1;
                                if (GameInformation.usableInventory[index].Amount == 0)
                                {
                                    GameInformation.usableInventory.RemoveAt(index);
                                }
                            }
                        }
                    }
                }
                else if (GameInformation.usableInventory[index].ID == "IT11" || GameInformation.usableInventory[index].ID == "IT12")
                {
                    if (GameInformation.Cecil.CurrentHp == 0)
                    {
                        if (GUI.Button(new Rect(0, 0, 100, 30), GameInformation.Cecil.Name))
                        {
                            int heal = GameInformation.usableInventory[index].Heal(GameInformation.Cecil.Hp);
                            GameInformation.Cecil.CurrentHp = heal;
                            showItemTarget = false;
                            GameInformation.usableInventory[index].Amount -= 1;
                            if (GameInformation.usableInventory[index].Amount == 0)
                            {
                                GameInformation.usableInventory.RemoveAt(index);
                            }
                        }
                    }
                    if (GameInformation.Limca.CurrentHp == 0)
                    {
                        if (GUI.Button(new Rect(0, 40, 100, 30), GameInformation.Limca.Name))
                        {
                            int heal = GameInformation.usableInventory[index].Heal(GameInformation.Limca.Hp);
                            GameInformation.Limca.CurrentHp = heal;
                            showItemTarget = false;
                            GameInformation.usableInventory[index].Amount -= 1;
                            if (GameInformation.usableInventory[index].Amount == 0)
                            {
                                GameInformation.usableInventory.RemoveAt(index);
                            }
                        }
                    }
                    if (GameInformation.Galard.CurrentHp == 0)
                    {
                        if (GUI.Button(new Rect(0, 80, 100, 30), GameInformation.Galard.Name))
                        {
                            int heal = GameInformation.usableInventory[index].Heal(GameInformation.Galard.Hp);
                            GameInformation.Galard.CurrentHp = heal;
                            showItemTarget = false;
                            GameInformation.usableInventory[index].Amount -= 1;
                            if (GameInformation.usableInventory[index].Amount == 0)
                            {
                                GameInformation.usableInventory.RemoveAt(index);
                            }
                        }
                    }
                }
                else if (GameInformation.usableInventory[index].ID == "IT13")
                {
                    if (Application.loadedLevelName == "Dungeon" && EncounterManager.isBattle == false)
                    {
                        showItemTarget = false;
                        GameInformation.usableInventory[index].Amount -= 1;
                        if (GameInformation.usableInventory[index].Amount == 0)
                        {
                            GameInformation.usableInventory.RemoveAt(index);
                        }
                        Application.LoadLevel("Town");
                    }
                }
            }
            GUI.EndGroup();
        }
    } 
}
