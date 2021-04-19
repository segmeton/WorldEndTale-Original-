using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleGUI2 : MonoBehaviour
{
    private GameObject mainCamera;
    public Texture cecilSprite;
    public Texture limcaSprite;
    public Texture galardSprite;
    //public Texture enemy01Sprite;
    //public Texture enemy02Sprite;
    //public Texture enemy03Sprite;
    public Texture red;
    public Texture blue;
    public Texture green;
    public Texture yellow;
    public Texture white;
    private int selectedButton = 5;
    private int selectedSkill = 5;
    //private bool isNoMpWarning = false;
    private bool isShowSkillName = false;
    private string abilityName;
    private DamageCalculation damageCalculation = new DamageCalculation();
    private Vector2 itemScrollPosition = Vector2.zero;
    private bool showItemTarget;
    private int itemIndex;
    private bool showItem = false;
    private BaseCharacter.CharacterUnit currentTurn;
    private List<Item> itemDropList;
    private Texture enemy01Sprite;
    private Texture enemy02Sprite;
    private Texture enemy03Sprite;

    void Start()
    {
        mainCamera = (GameObject)GameObject.FindWithTag("MainCamera");
    }

    void Update()
    {
        ToggleRenderer();
        if (EncounterManager.isBattle == true)
        {
            transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 0);
        }
    }

    public void ToggleRenderer()
    {
        if (EncounterManager.isBattle == false)
        {
            renderer.enabled = false;
        }
        else if (EncounterManager.isBattle == true)
        {
            renderer.enabled = true;
        }
    }

    void OnGUI()
    {
        if (EncounterManager.isBattle == true)
        {
            //if (GUI.Button(new Rect(10, 10, 100, 30), "Back"))
            //{
            //    EncounterManager.isBattle = false;
            //    StartBattle.isInitialized = false;
            //    BattleInformation.playerTurn = false;
            //    BattleStateManager.currentState = BattleStateManager.BattleState.DUNGEON;
            //    BattleInformation.cecilAtb = 0;
            //    BattleInformation.limcaAtb = 0;
            //    BattleInformation.galardAtb = 0;
            //    BattleInformation.enemy01Atb = 0;
            //    BattleInformation.enemy02Atb = 0;
            //    BattleInformation.enemy03Atb = 0;
            //}

            ShowSprite();
            ShowActionMenu();
            ShowSkillName();
            ShowBattleResult();
            if (showItem == true)
            {
                ShowItem();
            }
        }
    }

    private void ShowSprite()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float battleSpaceWidth = screenWidth - 20;
        float battleSpaceHeight = (screenHeight * 3 / 4) - 15;
        float groupWidth = battleSpaceWidth / 3;
        float groupHeight = battleSpaceHeight / 3;
        float charWidth = battleSpaceWidth / 10;
        float charHeight = (battleSpaceHeight / 3) - 10;
        float dataWidth = groupWidth - charWidth - 5;
        float maxWidth = dataWidth / 2;

        if (StartTurn.isStarted == true)
        {
            GUI.BeginGroup(new Rect(10, 5, battleSpaceWidth, battleSpaceHeight));
            GUI.BeginGroup(new Rect(groupWidth * 2, 5, groupWidth, groupHeight));

            CharPosition(BattleInformation.Cecil, dataWidth, charWidth, charHeight, maxWidth, BattleInformation.cecilAtb, cecilSprite);

            GUI.EndGroup();
            GUI.BeginGroup(new Rect(groupWidth * 2, (battleSpaceHeight / 3) + 5, groupWidth, groupHeight));

            CharPosition(BattleInformation.Limca, dataWidth, charWidth, charHeight, maxWidth, BattleInformation.limcaAtb, limcaSprite);

            GUI.EndGroup();
            GUI.BeginGroup(new Rect(groupWidth * 2, (battleSpaceHeight * 2 / 3) + 5, groupWidth, groupHeight));

            CharPosition(BattleInformation.Galard, dataWidth, charWidth, charHeight, maxWidth, BattleInformation.galardAtb, galardSprite);

            GUI.EndGroup();

            if (BattleInformation.enemySpawn == 1)
            {
                enemy01Sprite = GetEnemySprite(BattleInformation.Enemy[0].ID);

                GUI.BeginGroup(new Rect(0, (battleSpaceHeight / 3) + 5, groupWidth, groupHeight));

                EnemyPosition(BattleInformation.Enemy[0], dataWidth, charWidth, charHeight, maxWidth, BattleInformation.enemy01Atb, enemy01Sprite);

                GUI.EndGroup();
            }
            else if (BattleInformation.enemySpawn == 2)
            {
                enemy01Sprite = GetEnemySprite(BattleInformation.Enemy[0].ID);
                enemy02Sprite = GetEnemySprite(BattleInformation.Enemy[1].ID);

                GUI.BeginGroup(new Rect(0, 5, groupWidth, groupHeight));

                EnemyPosition(BattleInformation.Enemy[0], dataWidth, charWidth, charHeight, maxWidth, BattleInformation.enemy01Atb, enemy01Sprite);

                GUI.EndGroup();
                GUI.BeginGroup(new Rect(0, (battleSpaceHeight * 2 / 3) + 5, groupWidth, groupHeight));

                EnemyPosition(BattleInformation.Enemy[1], dataWidth, charWidth, charHeight, maxWidth, BattleInformation.enemy02Atb, enemy02Sprite);

                GUI.EndGroup();
            }
            else if (BattleInformation.enemySpawn == 3)
            {
                enemy01Sprite = GetEnemySprite(BattleInformation.Enemy[0].ID);
                enemy02Sprite = GetEnemySprite(BattleInformation.Enemy[1].ID);
                enemy03Sprite = GetEnemySprite(BattleInformation.Enemy[2].ID);

                GUI.BeginGroup(new Rect(0, 5, groupWidth, groupHeight));

                EnemyPosition(BattleInformation.Enemy[0], dataWidth, charWidth, charHeight, maxWidth, BattleInformation.enemy01Atb, enemy01Sprite);

                GUI.EndGroup();
                GUI.BeginGroup(new Rect(0, (battleSpaceHeight / 3) + 5, groupWidth, groupHeight));

                EnemyPosition(BattleInformation.Enemy[1], dataWidth, charWidth, charHeight, maxWidth, BattleInformation.enemy02Atb, enemy02Sprite);

                GUI.EndGroup();
                GUI.BeginGroup(new Rect(0, (battleSpaceHeight * 2 / 3) + 5, groupWidth, groupHeight));

                EnemyPosition(BattleInformation.Enemy[2], dataWidth, charWidth, charHeight, maxWidth, BattleInformation.enemy03Atb, enemy03Sprite);

                GUI.EndGroup();
            }

            GUI.EndGroup();
        }
    }

    private Texture GetEnemySprite(string enemyID)
    {
        Texture enemySprite = Resources.Load<Texture>(enemyID);
        return enemySprite;
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

    private float AtbBarWidth (float current, int max, float maxLength)
    {
        float barWidth;
        float hpPercentage = current / (float)max;
        barWidth = hpPercentage * maxLength;
        return barWidth;
    }

    private void EnemyPosition(BaseEnemy enemy, float dataWidth, float charWidth, float charHeight, float maxWidth, float atb, Texture sprite)
    {
        Texture healthTexture;
        float barWidth;
        if (enemy.CurrentHp != 0) GUI.DrawTexture(new Rect(dataWidth + 5, 0, charWidth, charHeight), sprite, ScaleMode.ScaleToFit);

        GUI.Label(new Rect(0, 0, dataWidth, 30), "Lv " + enemy.Lv + " " + enemy.Name);

        healthTexture = HealthTexture(enemy.CurrentHp, enemy.Hp);
        barWidth = BarWidth(enemy.CurrentHp, enemy.Hp, maxWidth);
        GUI.DrawTexture(new Rect((dataWidth / 2), 25, barWidth, 10), healthTexture, ScaleMode.ScaleAndCrop);
        GUI.Label(new Rect(0, 20, (dataWidth / 2) - 5, 20), enemy.CurrentHp + " / " + enemy.Hp);

        barWidth = BarWidth(enemy.CurrentMp, enemy.Mp, maxWidth);
        GUI.DrawTexture(new Rect((dataWidth / 2), 45, barWidth, 10), blue, ScaleMode.StretchToFill);
        GUI.Label(new Rect(0, 40, (dataWidth / 2) - 5, 20), enemy.CurrentMp + " / " + enemy.Mp);

        barWidth = AtbBarWidth(atb, BattleInformation.maxAtbValue, maxWidth);
        GUI.DrawTexture(new Rect((dataWidth / 2), 65, barWidth, 10), white, ScaleMode.StretchToFill);
    }

    private void CharPosition(BaseCharacter character, float dataWidth, float charWidth, float charHeight, float maxWidth, float atb, Texture sprite)
    {
        Texture healthTexture;
        float barWidth;
        if (character.CurrentHp != 0) GUI.DrawTexture(new Rect(0, 0, charWidth, charHeight), sprite, ScaleMode.ScaleToFit);
        
        GUI.Label(new Rect(charWidth + 5, 0, dataWidth, 20), "Lv " + character.Lv + " " + character.Name);

        healthTexture = HealthTexture(character.CurrentHp, character.Hp);
        barWidth = BarWidth(character.CurrentHp, character.Hp, maxWidth);
        GUI.DrawTexture(new Rect(charWidth + 5, 25, barWidth, 10), healthTexture, ScaleMode.ScaleAndCrop);
        GUI.Label(new Rect((charWidth + 5) + (dataWidth / 2) + 5, 20, (dataWidth / 2) - 5, 20), character.CurrentHp + " / " + character.Hp);

        barWidth = BarWidth(character.CurrentMp, character.Mp, maxWidth);
        GUI.DrawTexture(new Rect(charWidth + 5, 45, barWidth, 10), blue, ScaleMode.StretchToFill);
        GUI.Label(new Rect((charWidth + 5) + (dataWidth / 2) + 5, 40, (dataWidth / 2) - 5, 20), character.CurrentMp + " / " + character.Mp);

        barWidth = AtbBarWidth(atb, BattleInformation.maxAtbValue, maxWidth);
        GUI.DrawTexture(new Rect(charWidth + 5, 65, barWidth, 10), white, ScaleMode.StretchToFill);
    }

    private void ShowActionMenu()
    {
        if (BattleInformation.cecilAtb == 300)
        {
            currentTurn = BaseCharacter.CharacterUnit.CECIL;
            ShowActionMenuButton(BattleInformation.Cecil);
        }
        if (BattleInformation.limcaAtb == 300)
        {
            currentTurn = BaseCharacter.CharacterUnit.LIMCA;
            ShowActionMenuButton(BattleInformation.Limca);
        }
        if (BattleInformation.galardAtb == 300)
        {
            currentTurn = BaseCharacter.CharacterUnit.GALARD;
            ShowActionMenuButton(BattleInformation.Galard);
        }
    }

    private void ShowActionMenuButton(BaseCharacter character)
    {
        float groupWidth = Screen.width - 20;
        float groupHeight = Screen.height / 4 - 10;
        //float blockWidth = (Screen.width * 1 / 3) - 5;
        bool isMain = true;
        //int enemySpawn = BattleInformation.enemySpawn;
        GUI.BeginGroup(new Rect(10, Screen.height * 3 / 4, groupWidth, groupHeight));

            if (isMain == true)
            {
                GUI.BeginGroup(new Rect(0, 0, 200, groupHeight), "");
                    GUI.Box(new Rect(0, 0, 200, groupHeight), "");
                    GUI.Label(new Rect(10, 5, 200, groupHeight), "What will " + character.Name + " do?");
                GUI.EndGroup();
                    GUI.BeginGroup(new Rect(205, 0, (Screen.width * 1 / 3) - 5, groupHeight), "");
                    GUI.Box(new Rect(0, 0, 200, groupHeight), "");
                    string[] selStrings = new string[] { "Attack", "Skill", "Item", "Run" };
                    selectedButton = GUI.SelectionGrid(new Rect(5, 5, 190, groupHeight - 10), selectedButton, selStrings, 1);
                GUI.EndGroup();
            }
            
            if (selectedButton == 0)
            {
                showItem = false;
                GUI.BeginGroup(new Rect(410, 0, 200, groupHeight), "");
                GUI.Box(new Rect(0, 0, 200, groupHeight), "");
                ShowAttackTargetGUI(character);
                GUI.EndGroup(); 
            }
            else if (selectedButton == 1)
            {
                showItem = false;
                string[] skillNames = new string[4];
                GUI.BeginGroup(new Rect(410, 0, 200, groupHeight), "");
                GUI.Box(new Rect(0, 0, 200, groupHeight), "");
                if (character.ChosenAbility == null)
                {
                    GUI.Label(new Rect(5, 5, 190, groupHeight - 10), "No Skill");
                }
                else 
                {
                    skillNames = GetSkillNames(character);
                    selectedSkill = GUI.SelectionGrid(new Rect(5, 5, 190, groupHeight - 10), selectedSkill, skillNames, 1);   
                }
                GUI.EndGroup();

                if (selectedSkill != 5)
                {
                    if (skillNames[selectedSkill] != "No Skill")
                    {
                        BaseAbility abilityUsed = new BaseAbility();
                        abilityUsed = GetAbilityUsed(character,selectedSkill);
                        //GUI.EndGroup();
                        UseAbility(abilityUsed,character);
                        //if (abilityUsed.ID == "SK13" || abilityUsed.ID == "SK17")
                        //{
                        //    if (abilityUsed.ID == "SK13")
                        //    {
                        //        Heal(character, abilityUsed);
                        //    }
                        //    else if (abilityUsed.ID == "SK17")
                        //    {
                        //        HealAll(character, abilityUsed);
                        //    }
                        //}
                        //else if (abilityUsed.ID == "SK15" || abilityUsed.ID == "SK18")
                        //{
                        //    if (abilityUsed.ID == "SK15")
                        //    {
                        //        Ressurect(character, abilityUsed, "");
                        //    }
                        //    else if (abilityUsed.ID == "SK18")
                        //    {
                        //        Ressurect(character, abilityUsed, "full");
                        //    }
                        //}
                        //else
                        //{
                        //    GUI.BeginGroup(new Rect(Screen.width/2 - 150, Screen.height * 3 / 4 - 40, 300, 40));
                        //    GUI.Box(new Rect(0, 0, 300, 40), "");
                        //    GUI.Label(new Rect(10, 10, 280, 20), abilityUsed.Description);
                        //    AttackSkill(character, abilityUsed);
                        //}
                    }
                }              
            }
            else if (selectedButton == 2)
            {
                showItem = true;
            }
            else if (selectedButton == 3)
            {
                showItem = false;
                Escape(character);
            }
        GUI.EndGroup();
    }

    private void UseAbility(BaseAbility ability, BaseCharacter character)
    {
        if (ability.ID == "SK13" || ability.ID == "SK17")
        {
            if (ability.TargetEnemy == BaseAbility.Target.SINGLE)
            {
                Heal(character, ability);
            }
            else if (ability.TargetEnemy == BaseAbility.Target.ALL)
            {
                HealAll(character, ability);
            }
        }
        else if (ability.ID == "SK15" || ability.ID == "SK18")
        {
            if (ability.ID == "SK15")
            {
                Ressurect(character, ability, "");
            }
            else if (ability.ID == "SK18")
            {
                Ressurect(character, ability, "full");
            }
        }
        else 
        {
            AttackSkill(character, ability);
        }
    }

    private void ShowItem()
    {
        int usableCount = GameInformation.usableInventory.Count;
        int height = usableCount * 80 + 30;
        GUI.BeginGroup(new Rect((Screen.width / 2) - 250, (Screen.height * 3 / 4) - 420, 500, 400));
        GUI.Box(new Rect(0, 0, 500, 400), "");
        itemScrollPosition = GUI.BeginScrollView(new Rect(20, 20, 500, 400), itemScrollPosition, new Rect(0, 0, 360, height));
        for (int i = 0; i < GameInformation.usableInventory.Count; i++)
        {
            GUI.Label(new Rect(20, i * 80 + 25, 100, 20), GameInformation.usableInventory[i].Name);
            GUI.Label(new Rect(140, i * 80 + 25, 100, 20), "Owned : " + GameInformation.usableInventory[i].Amount);
            GUI.Label(new Rect(20, i * 80 + 65, 360, 20), GameInformation.usableInventory[i].Description);
            if (GameInformation.usableInventory[i].ID != "IT13")
            {
                if (GUI.Button(new Rect(260, i * 80 + 20, 100, 30), "Use"))
                {
                    showItemTarget = false;
                    itemIndex = i;
                    showItemTarget = true;
                }
            }
        }
        GUI.EndScrollView();
        GUI.EndGroup();
        ShowTargetItem(itemIndex);
    }

    private void ShowTargetItem(int index)
    {
        if (showItemTarget == true)
        {
            float groupHeight = Screen.height / 4 - 10;
            GUI.BeginGroup(new Rect(420, Screen.height * 3 / 4, 200, groupHeight), "");
            GUI.Box(new Rect(0, 0, 200, groupHeight), "");
            if (GameInformation.usableInventory[index].ItemTypeValue == Item.ItemType.HEALTH)
            {
                if (GameInformation.Cecil.CurrentHp > 0 && GameInformation.Cecil.CurrentHp < GameInformation.Cecil.Hp)
                {
                    if (GUI.Button(new Rect(5, 5, 190, ((groupHeight - 10) / 3) - 5), GameInformation.Cecil.Name))
                    {
                        int heal = GameInformation.usableInventory[index].Heal(GameInformation.Cecil.Hp);
                        GameInformation.Cecil.CurrentHp += heal;
                        if (GameInformation.Cecil.CurrentHp > GameInformation.Cecil.Hp)
                        {
                            GameInformation.Cecil.CurrentHp = GameInformation.Cecil.Hp;
                        }
                        showItem = false;
                        showItemTarget = false;
                        GameInformation.usableInventory[index].Amount -= 1;
                        if (GameInformation.usableInventory[index].Amount == 0)
                        {
                            GameInformation.usableInventory.RemoveAt(index);
                        }
                        ResetAtb(currentTurn);
                        BattleInformation.playerTurn = false;
                        selectedButton = 5;
                    }
                }
                if (GameInformation.Limca.CurrentHp > 0 && GameInformation.Limca.CurrentHp < GameInformation.Limca.Hp)
                {
                    if (GUI.Button(new Rect(5, ((groupHeight - 10) / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), GameInformation.Limca.Name))
                    {
                        int heal = GameInformation.usableInventory[index].Heal(GameInformation.Limca.Hp);
                        GameInformation.Limca.CurrentHp += heal;
                        if (GameInformation.Limca.CurrentHp > GameInformation.Limca.Hp)
                        {
                            GameInformation.Limca.CurrentHp = GameInformation.Limca.Hp;
                        }
                        showItem = false;
                        showItemTarget = false;
                        GameInformation.usableInventory[index].Amount -= 1;
                        if (GameInformation.usableInventory[index].Amount == 0)
                        {
                            GameInformation.usableInventory.RemoveAt(index);
                        }
                        ResetAtb(currentTurn);
                        BattleInformation.playerTurn = false;
                        selectedButton = 5;
                    }
                }
                if (GameInformation.Galard.CurrentHp > 0 && GameInformation.Galard.CurrentHp < GameInformation.Galard.Hp)
                {
                    if (GUI.Button(new Rect(5, ((groupHeight - 10) * 2 / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), GameInformation.Galard.Name))
                    {
                        int heal = GameInformation.usableInventory[index].Heal(GameInformation.Galard.Hp);
                        GameInformation.Galard.CurrentHp += heal;
                        if (GameInformation.Galard.CurrentHp > GameInformation.Galard.Hp)
                        {
                            GameInformation.Galard.CurrentHp = GameInformation.Galard.Hp;
                        }
                        showItem = false;
                        showItemTarget = false;
                        GameInformation.usableInventory[index].Amount -= 1;
                        if (GameInformation.usableInventory[index].Amount == 0)
                        {
                            GameInformation.usableInventory.RemoveAt(index);
                        }
                        ResetAtb(currentTurn);
                        BattleInformation.playerTurn = false;
                        selectedButton = 5;
                    }
                }
            }
            else if (GameInformation.usableInventory[index].ItemTypeValue == Item.ItemType.MANA)
            {
                if (GameInformation.Cecil.CurrentHp > 0 && GameInformation.Cecil.CurrentMp < GameInformation.Cecil.Mp)
                {
                    if (GUI.Button(new Rect(5, 5, 190, ((groupHeight - 10) / 3) - 5), GameInformation.Cecil.Name))
                    {
                        int heal = GameInformation.usableInventory[index].Heal(GameInformation.Cecil.Mp);
                        GameInformation.Cecil.CurrentMp += heal;
                        if (GameInformation.Cecil.CurrentMp > GameInformation.Cecil.Mp)
                        {
                            GameInformation.Cecil.CurrentMp = GameInformation.Cecil.Mp;
                        }
                        showItem = false;
                        showItemTarget = false;
                        GameInformation.usableInventory[index].Amount -= 1;
                        if (GameInformation.usableInventory[index].Amount == 0)
                        {
                            GameInformation.usableInventory.RemoveAt(index);
                        }
                        ResetAtb(currentTurn);
                        BattleInformation.playerTurn = false;
                        selectedButton = 5;
                    }
                }
                if (GameInformation.Limca.CurrentHp > 0 && GameInformation.Limca.CurrentMp < GameInformation.Limca.Mp)
                {
                    if (GUI.Button(new Rect(5, ((groupHeight - 10) / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), GameInformation.Limca.Name))
                    {
                        int heal = GameInformation.usableInventory[index].Heal(GameInformation.Limca.Mp);
                        GameInformation.Limca.CurrentMp += heal;
                        if (GameInformation.Limca.CurrentMp > GameInformation.Limca.Mp)
                        {
                            GameInformation.Limca.CurrentMp = GameInformation.Limca.Mp;
                        }
                        showItem = false;
                        showItemTarget = false;
                        GameInformation.usableInventory[index].Amount -= 1;
                        if (GameInformation.usableInventory[index].Amount == 0)
                        {
                            GameInformation.usableInventory.RemoveAt(index);
                        }
                        ResetAtb(currentTurn);
                        BattleInformation.playerTurn = false;
                        selectedButton = 5;
                    }
                }
                if (GameInformation.Galard.CurrentHp > 0 && GameInformation.Galard.CurrentMp < GameInformation.Galard.Mp)
                {
                    if (GUI.Button(new Rect(5, ((groupHeight - 10) * 2 / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), GameInformation.Galard.Name))
                    {
                        int heal = GameInformation.usableInventory[index].Heal(GameInformation.Galard.Mp);
                        GameInformation.Galard.CurrentMp += heal;
                        if (GameInformation.Galard.CurrentMp > GameInformation.Galard.Mp)
                        {
                            GameInformation.Galard.CurrentMp = GameInformation.Galard.Mp;
                        }
                        showItem = false;
                        showItemTarget = false;
                        GameInformation.usableInventory[index].Amount -= 1;
                        if (GameInformation.usableInventory[index].Amount == 0)
                        {
                            GameInformation.usableInventory.RemoveAt(index);
                        }
                        ResetAtb(currentTurn);
                        BattleInformation.playerTurn = false;
                        selectedButton = 5;
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
                            if (GUI.Button(new Rect(5, 5, 190, ((groupHeight - 10) / 3) - 5), GameInformation.Cecil.Name))
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
                                showItem = false;
                                showItemTarget = false;
                                GameInformation.usableInventory[index].Amount -= 1;
                                if (GameInformation.usableInventory[index].Amount == 0)
                                {
                                    GameInformation.usableInventory.RemoveAt(index);
                                }
                                ResetAtb(currentTurn);
                                BattleInformation.playerTurn = false;
                                selectedButton = 5;
                            }
                        }
                    }
                    if (GameInformation.Limca.CurrentHp > 0)
                    {
                        if (GameInformation.Limca.CurrentHp < GameInformation.Limca.Hp || GameInformation.Limca.CurrentMp < GameInformation.Limca.Mp)
                        {
                            if (GUI.Button(new Rect(5, ((groupHeight - 10) / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), GameInformation.Limca.Name))
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
                                showItem = false;
                                showItemTarget = false;
                                GameInformation.usableInventory[index].Amount -= 1;
                                if (GameInformation.usableInventory[index].Amount == 0)
                                {
                                    GameInformation.usableInventory.RemoveAt(index);
                                }
                                ResetAtb(currentTurn);
                                BattleInformation.playerTurn = false;
                                selectedButton = 5;
                            }
                        }
                    }
                    if (GameInformation.Galard.CurrentHp > 0)
                    {
                        if (GameInformation.Galard.CurrentHp < GameInformation.Galard.Hp || GameInformation.Galard.CurrentMp < GameInformation.Galard.Mp)
                        {
                            if (GUI.Button(new Rect(5, ((groupHeight - 10) * 2 / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), GameInformation.Galard.Name))
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
                                showItem = false;
                                showItemTarget = false;
                                GameInformation.usableInventory[index].Amount -= 1;
                                if (GameInformation.usableInventory[index].Amount == 0)
                                {
                                    GameInformation.usableInventory.RemoveAt(index);
                                }
                                ResetAtb(currentTurn);
                                BattleInformation.playerTurn = false;
                                selectedButton = 5;
                            }
                        }
                    }
                }
                else if (GameInformation.usableInventory[index].ID == "IT11" || GameInformation.usableInventory[index].ID == "IT12")
                {
                    if (GameInformation.Cecil.CurrentHp == 0)
                    {
                        if (GUI.Button(new Rect(5, 5, 190, ((groupHeight - 10) / 3) - 5), GameInformation.Cecil.Name))
                        {
                            int heal = GameInformation.usableInventory[index].Heal(GameInformation.Cecil.Hp);
                            GameInformation.Cecil.CurrentHp = heal;
                            showItem = false;
                            showItemTarget = false;
                            GameInformation.usableInventory[index].Amount -= 1;
                            if (GameInformation.usableInventory[index].Amount == 0)
                            {
                                GameInformation.usableInventory.RemoveAt(index);
                            }
                            ResetAtb(currentTurn);
                            BattleInformation.playerTurn = false;
                            selectedButton = 5;
                        }
                    }
                    if (GameInformation.Limca.CurrentHp == 0)
                    {
                        if (GUI.Button(new Rect(5, ((groupHeight - 10) / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), GameInformation.Limca.Name))
                        {
                            int heal = GameInformation.usableInventory[index].Heal(GameInformation.Limca.Hp);
                            GameInformation.Limca.CurrentHp = heal;
                            showItem = false;
                            showItemTarget = false;
                            GameInformation.usableInventory[index].Amount -= 1;
                            if (GameInformation.usableInventory[index].Amount == 0)
                            {
                                GameInformation.usableInventory.RemoveAt(index);
                            }
                            ResetAtb(currentTurn);
                            BattleInformation.playerTurn = false;
                            selectedButton = 5;
                        }
                    }
                    if (GameInformation.Galard.CurrentHp == 0)
                    {
                        if (GUI.Button(new Rect(5, ((groupHeight - 10) * 2 / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), GameInformation.Galard.Name))
                        {
                            int heal = GameInformation.usableInventory[index].Heal(GameInformation.Galard.Hp);
                            GameInformation.Galard.CurrentHp = heal;
                            showItem = false;
                            showItemTarget = false;
                            GameInformation.usableInventory[index].Amount -= 1;
                            if (GameInformation.usableInventory[index].Amount == 0)
                            {
                                GameInformation.usableInventory.RemoveAt(index);
                            }
                            ResetAtb(currentTurn);
                            BattleInformation.playerTurn = false;
                            selectedButton = 5;
                        }
                    }
                }
                else if (GameInformation.usableInventory[index].ID == "IT13")
                {
                    showItemTarget = false;
                }
            }
            GUI.EndGroup();
        }
    }

    private void ResetAtb(BaseCharacter.CharacterUnit characterTurn)
    {
        switch (characterTurn)
        {
            case (BaseCharacter.CharacterUnit.CECIL):
                BattleInformation.cecilAtb = 0;
                break;
            case (BaseCharacter.CharacterUnit.LIMCA):
                BattleInformation.limcaAtb = 0;
                break;
            case (BaseCharacter.CharacterUnit.GALARD):
                BattleInformation.galardAtb = 0;
                break;
        }
    }

    private void ShowAttackTargetGUI(BaseCharacter character)
    {
        float groupHeight = Screen.height / 4 - 10;
        int damage;
        int enemySpawn = BattleInformation.enemySpawn;
        if (enemySpawn == 1)
        {
            if (BattleInformation.Enemy[0] != null)
            {
                if (BattleInformation.Enemy[0].CurrentHp > 0)
                {
                    if (GUI.Button(new Rect(5, ((groupHeight - 10) / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Enemy[0].Name))
                    {
                        damage = damageCalculation.AttackDamage(character, BattleInformation.Enemy[0]);
                        BattleInformation.Enemy[0].CurrentHp -= damage;
                        if (BattleInformation.Enemy[0].CurrentHp < 0) BattleInformation.Enemy[0].CurrentHp = 0;
                        switch (character.CharacterUnitName)
                        {
                            case (BaseCharacter.CharacterUnit.CECIL):
                                BattleInformation.cecilAtb = 0;
                                break;
                            case (BaseCharacter.CharacterUnit.LIMCA):
                                BattleInformation.limcaAtb = 0;
                                break;
                            case (BaseCharacter.CharacterUnit.GALARD):
                                BattleInformation.galardAtb = 0;
                                break;
                        }
                        BattleInformation.playerTurn = false;
                        selectedButton = 5;
                    }
                }
            }
        }
        else if (enemySpawn == 2)
        {
            if (BattleInformation.Enemy[0] != null)
            {
                if (BattleInformation.Enemy[0].CurrentHp > 0)
                {
                    if (GUI.Button(new Rect(5, 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Enemy[0].Name))
                    {
                        damage = damageCalculation.AttackDamage(character, BattleInformation.Enemy[0]);
                        BattleInformation.Enemy[0].CurrentHp -= damage;
                        if (BattleInformation.Enemy[0].CurrentHp < 0) BattleInformation.Enemy[0].CurrentHp = 0;
                        switch (character.CharacterUnitName)
                        {
                            case (BaseCharacter.CharacterUnit.CECIL):
                                BattleInformation.cecilAtb = 0;
                                break;
                            case (BaseCharacter.CharacterUnit.LIMCA):
                                BattleInformation.limcaAtb = 0;
                                break;
                            case (BaseCharacter.CharacterUnit.GALARD):
                                BattleInformation.galardAtb = 0;
                                break;
                        }
                        BattleInformation.playerTurn = false;
                        selectedButton = 5;
                    }
                }
            }
            if (BattleInformation.Enemy[1] != null)
            {
                if (BattleInformation.Enemy[1].CurrentHp > 0)
                {
                    if (GUI.Button(new Rect(5, ((groupHeight - 10) * 2 / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Enemy[1].Name))
                    {
                        damage = damageCalculation.AttackDamage(character, BattleInformation.Enemy[1]);
                        //Debug.Log("damaeg : " + damage);
                        BattleInformation.Enemy[1].CurrentHp -= damage;
                        if (BattleInformation.Enemy[1].CurrentHp < 0) BattleInformation.Enemy[1].CurrentHp = 0;
                        switch (character.CharacterUnitName)
                        {
                            case (BaseCharacter.CharacterUnit.CECIL):
                                BattleInformation.cecilAtb = 0;
                                break;
                            case (BaseCharacter.CharacterUnit.LIMCA):
                                BattleInformation.limcaAtb = 0;
                                break;
                            case (BaseCharacter.CharacterUnit.GALARD):
                                BattleInformation.galardAtb = 0;
                                break;
                        }
                        BattleInformation.playerTurn = false;
                        selectedButton = 5;
                    }
                }
            }
        }
        else if (enemySpawn == 3)
        {
            if (BattleInformation.Enemy[0] != null)
            {
                if (BattleInformation.Enemy[0].CurrentHp > 0)
                {
                    if (GUI.Button(new Rect(5, 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Enemy[0].Name))
                    {
                        damage = damageCalculation.AttackDamage(character, BattleInformation.Enemy[0]);
                        //Debug.Log("damaeg : " + damage);
                        BattleInformation.Enemy[0].CurrentHp -= damage;
                        if (BattleInformation.Enemy[0].CurrentHp < 0) BattleInformation.Enemy[0].CurrentHp = 0;
                        switch (character.CharacterUnitName)
                        {
                            case (BaseCharacter.CharacterUnit.CECIL):
                                BattleInformation.cecilAtb = 0;
                                break;
                            case (BaseCharacter.CharacterUnit.LIMCA):
                                BattleInformation.limcaAtb = 0;
                                break;
                            case (BaseCharacter.CharacterUnit.GALARD):
                                BattleInformation.galardAtb = 0;
                                break;
                        }
                        BattleInformation.playerTurn = false;
                        selectedButton = 5;
                    }
                }
                if (BattleInformation.Enemy[1] != null)
                {
                    if (BattleInformation.Enemy[1].CurrentHp > 0)
                    {
                        if (GUI.Button(new Rect(5, ((groupHeight - 10) / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Enemy[1].Name))
                        {
                            damage = damageCalculation.AttackDamage(character, BattleInformation.Enemy[1]);
                            //Debug.Log("damaeg : " + damage);
                            BattleInformation.Enemy[1].CurrentHp -= damage;
                            if (BattleInformation.Enemy[1].CurrentHp < 0) BattleInformation.Enemy[1].CurrentHp = 0;
                            switch (character.CharacterUnitName)
                            {
                                case (BaseCharacter.CharacterUnit.CECIL):
                                    BattleInformation.cecilAtb = 0;
                                    break;
                                case (BaseCharacter.CharacterUnit.LIMCA):
                                    BattleInformation.limcaAtb = 0;
                                    break;
                                case (BaseCharacter.CharacterUnit.GALARD):
                                    BattleInformation.galardAtb = 0;
                                    break;
                            }
                            BattleInformation.playerTurn = false;
                            selectedButton = 5;
                        }
                    }
                }
                if (BattleInformation.Enemy[2] != null)
                {
                    if (BattleInformation.Enemy[2].CurrentHp > 0)
                    {
                        if (GUI.Button(new Rect(5, ((groupHeight - 10) * 2 / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Enemy[2].Name))
                        {
                            damage = damageCalculation.AttackDamage(character, BattleInformation.Enemy[2]);
                            //Debug.Log("damaeg : " + damage);
                            BattleInformation.Enemy[2].CurrentHp -= damage;
                            if (BattleInformation.Enemy[2].CurrentHp < 0) BattleInformation.Enemy[2].CurrentHp = 0;
                            switch (character.CharacterUnitName)
                            {
                                case (BaseCharacter.CharacterUnit.CECIL):
                                    BattleInformation.cecilAtb = 0;
                                    break;
                                case (BaseCharacter.CharacterUnit.LIMCA):
                                    BattleInformation.limcaAtb = 0;
                                    break;
                                case (BaseCharacter.CharacterUnit.GALARD):
                                    BattleInformation.galardAtb = 0;
                                    break;
                            }
                            BattleInformation.playerTurn = false;
                            selectedButton = 5;
                        }
                    }
                }
            }
        }
    }

    private BaseAbility GetAbilityUsed(BaseCharacter character, int selectedSkill)
    {
        BaseAbility abilityUsed = new BaseAbility();
        if (character.CharacterUnitName == BaseCharacter.CharacterUnit.CECIL)
        {
            abilityUsed = GameInformation.Cecil.ChosenAbility[selectedSkill];
        }
        else if (character.CharacterUnitName == BaseCharacter.CharacterUnit.LIMCA)
        {
            abilityUsed = GameInformation.Limca.ChosenAbility[selectedSkill];
        }
        else if (character.CharacterUnitName == BaseCharacter.CharacterUnit.GALARD)
        {
            abilityUsed = GameInformation.Galard.ChosenAbility[selectedSkill];
        }
        return abilityUsed;
    }

    private string[] GetSkillNames(BaseCharacter character)
    {
        string[] skillNames = new string[4];
        if (character.CharacterUnitName == BaseCharacter.CharacterUnit.CECIL)
        {
            for (int i = 0; i < 4; i++)
            {
                if (GameInformation.Cecil.ChosenAbility[i] != null)
                {
                    skillNames[i] = GameInformation.Cecil.ChosenAbility[i].Name;
                }
                else
                {
                    skillNames[i] = "No Skill";
                }
            }
        }
        else if (character.CharacterUnitName == BaseCharacter.CharacterUnit.LIMCA)
        {
            for (int i = 0; i < 4; i++)
            {
                if (GameInformation.Limca.ChosenAbility[i] != null)
                {
                    skillNames[i] = GameInformation.Limca.ChosenAbility[i].Name;
                }
                else
                {
                    skillNames[i] = "No Skill";
                }
            }
        }
        else if (character.CharacterUnitName == BaseCharacter.CharacterUnit.GALARD)
        {
            for (int i = 0; i < 4; i++)
            {
                if (GameInformation.Galard.ChosenAbility[i] != null)
                {
                    skillNames[i] = GameInformation.Galard.ChosenAbility[i].Name;
                }
                else
                {
                    skillNames[i] = "No Skill";
                }
            }
        }
        return skillNames;
    }

    private void Heal(BaseCharacter character, BaseAbility abilityUsed)
    {
        int heal;
        float groupHeight = Screen.height / 4 - 10;
        bool checkTargetHeal = false;
        if (BattleInformation.Cecil.CurrentHp < BattleInformation.Cecil.Hp || BattleInformation.Limca.CurrentHp < BattleInformation.Limca.Hp || BattleInformation.Galard.CurrentHp < BattleInformation.Galard.Hp)
        {
            checkTargetHeal = true;
        }
        if (character.CurrentMp >= abilityUsed.MpCost && checkTargetHeal == true)
        {
            GUI.BeginGroup(new Rect(615, 0, 200, groupHeight), "");
            GUI.Box(new Rect(0, 0, 200, groupHeight), "");
            if (BattleInformation.Cecil.CurrentHp > 0 && BattleInformation.Cecil.CurrentHp < BattleInformation.Cecil.Hp)
            {
                if (GUI.Button(new Rect(5, 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Cecil.Name))
                {
                    isShowSkillName = true;
                    abilityName = abilityUsed.Name;
                    heal = damageCalculation.HealPoint(character, abilityUsed);
                    BattleInformation.Cecil.CurrentHp += heal;
                    if (BattleInformation.Cecil.CurrentHp > BattleInformation.Cecil.Hp)
                    {
                        BattleInformation.Cecil.CurrentHp = BattleInformation.Cecil.Hp;
                    }
                    switch (character.CharacterUnitName)
                    {
                        case (BaseCharacter.CharacterUnit.CECIL):
                            BattleInformation.cecilAtb = 0;
                            BattleInformation.Cecil.CurrentMp -= abilityUsed.MpCost;
                            break;
                        case (BaseCharacter.CharacterUnit.LIMCA):
                            BattleInformation.limcaAtb = 0;
                            BattleInformation.Limca.CurrentMp -= abilityUsed.MpCost;
                            break;
                        case (BaseCharacter.CharacterUnit.GALARD):
                            BattleInformation.galardAtb = 0;
                            BattleInformation.Galard.CurrentMp -= abilityUsed.MpCost;
                            break;
                    }
                    BattleInformation.playerTurn = false;
                    selectedButton = 5;
                    selectedSkill = 5;
                    isShowSkillName = false;
                }
            }
            if (BattleInformation.Limca.CurrentHp > 0 && BattleInformation.Limca.CurrentHp < BattleInformation.Limca.Hp)
            {
                if (GUI.Button(new Rect(5, ((groupHeight - 10) / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Limca.Name))
                {
                    isShowSkillName = true;
                    abilityName = abilityUsed.Name;
                    heal = damageCalculation.HealPoint(character, abilityUsed);
                    BattleInformation.Limca.CurrentHp += heal;
                    if (BattleInformation.Limca.CurrentHp > BattleInformation.Limca.Hp)
                    {
                        BattleInformation.Limca.CurrentHp = BattleInformation.Limca.Hp;
                    }
                    switch (character.CharacterUnitName)
                    {
                        case (BaseCharacter.CharacterUnit.CECIL):
                            BattleInformation.cecilAtb = 0;
                            break;
                        case (BaseCharacter.CharacterUnit.LIMCA):
                            BattleInformation.limcaAtb = 0;
                            break;
                        case (BaseCharacter.CharacterUnit.GALARD):
                            BattleInformation.galardAtb = 0;
                            break;
                    }
                    BattleInformation.playerTurn = false;
                    selectedButton = 5;
                    selectedSkill = 5;
                    isShowSkillName = false;
                }
            }
            if (BattleInformation.Galard.CurrentHp > 0 && BattleInformation.Galard.CurrentHp < BattleInformation.Galard.Hp)
            {
                if (GUI.Button(new Rect(5, ((groupHeight - 10) * 2 / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Galard.Name))
                {
                    isShowSkillName = true;
                    abilityName = abilityUsed.Name;
                    heal = damageCalculation.HealPoint(character, abilityUsed);
                    BattleInformation.Galard.CurrentHp += heal;
                    if (BattleInformation.Galard.CurrentHp > BattleInformation.Galard.Hp)
                    {
                        BattleInformation.Galard.CurrentHp = BattleInformation.Galard.Hp;
                    }
                    switch (character.CharacterUnitName)
                    {
                        case (BaseCharacter.CharacterUnit.CECIL):
                            BattleInformation.cecilAtb = 0;
                            break;
                        case (BaseCharacter.CharacterUnit.LIMCA):
                            BattleInformation.limcaAtb = 0;
                            break;
                        case (BaseCharacter.CharacterUnit.GALARD):
                            BattleInformation.galardAtb = 0;
                            break;
                    }
                    BattleInformation.playerTurn = false;
                    selectedButton = 5;
                    selectedSkill = 5;
                    isShowSkillName = false;
                }
            }
            GUI.EndGroup();
        }
    }

    private void HealAll(BaseCharacter character, BaseAbility abilityUsed)
    {
        int heal;
        if (character.CurrentMp >= abilityUsed.MpCost)
        {
            isShowSkillName = true;
            abilityName = abilityUsed.Name;
            heal = damageCalculation.HealPoint(character, abilityUsed);
            if (BattleInformation.Cecil.CurrentHp > 0)
            {
                BattleInformation.Cecil.CurrentHp += heal;
                if (BattleInformation.Cecil.CurrentHp > BattleInformation.Cecil.Hp)
                {
                    BattleInformation.Cecil.CurrentHp = BattleInformation.Cecil.Hp;
                }
            }
            if (BattleInformation.Limca.CurrentHp > 0)
            {
                BattleInformation.Limca.CurrentHp += heal;
                if (BattleInformation.Limca.CurrentHp > BattleInformation.Limca.Hp)
                {
                    BattleInformation.Limca.CurrentHp = BattleInformation.Limca.Hp;
                }
            }
            if (BattleInformation.Galard.CurrentHp > 0)
            {
                BattleInformation.Galard.CurrentHp += heal;
                if (BattleInformation.Galard.CurrentHp > BattleInformation.Galard.Hp)
                {
                    BattleInformation.Galard.CurrentHp = BattleInformation.Galard.Hp;
                }
            }
            switch (character.CharacterUnitName)
            {
                case (BaseCharacter.CharacterUnit.CECIL):
                    BattleInformation.Cecil.CurrentMp -= abilityUsed.MpCost;
                    BattleInformation.cecilAtb = 0;
                    break;
                case (BaseCharacter.CharacterUnit.LIMCA):
                    BattleInformation.Limca.CurrentMp -= abilityUsed.MpCost;
                    BattleInformation.limcaAtb = 0;
                    break;
                case (BaseCharacter.CharacterUnit.GALARD):
                    BattleInformation.Galard.CurrentMp -= abilityUsed.MpCost;
                    BattleInformation.galardAtb = 0;
                    break;
            }
            BattleInformation.playerTurn = false;
            selectedButton = 5;
            selectedSkill = 5;
            isShowSkillName = false;
        }
    }

    private void Ressurect(BaseCharacter character, BaseAbility abilityUsed, string amount)
    {
        float groupHeight = Screen.height / 4 - 10;
        int healthIncrease = 1;
        if (character.CurrentMp >= abilityUsed.MpCost)
        {
            GUI.BeginGroup(new Rect(615, 0, 200, groupHeight), "");
            GUI.Box(new Rect(0, 0, 200, groupHeight), "");
            if (BattleInformation.Cecil.CurrentHp == 0)
            {
                if (GUI.Button(new Rect(5, 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Cecil.Name))
                {
                    isShowSkillName = true;
                    abilityName = abilityUsed.Name;
                    if (amount == "full") healthIncrease = BattleInformation.Cecil.Hp;
                    BattleInformation.Cecil.CurrentHp = healthIncrease;
                    switch (character.CharacterUnitName)
                    {
                        case (BaseCharacter.CharacterUnit.CECIL):
                            BattleInformation.Cecil.CurrentMp -= abilityUsed.MpCost;
                            BattleInformation.cecilAtb = 0;
                            break;
                        case (BaseCharacter.CharacterUnit.LIMCA):
                            BattleInformation.Limca.CurrentMp -= abilityUsed.MpCost;
                            BattleInformation.limcaAtb = 0;
                            break;
                        case (BaseCharacter.CharacterUnit.GALARD):
                            BattleInformation.Galard.CurrentMp -= abilityUsed.MpCost;
                            BattleInformation.galardAtb = 0;
                            break;
                    }
                    BattleInformation.playerTurn = false;
                    selectedButton = 5;
                    selectedSkill = 5;
                    isShowSkillName = false;
                }

            }
            if (BattleInformation.Limca.CurrentHp == 0)
            {
                if (GUI.Button(new Rect(5, ((groupHeight - 10) / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Limca.Name))
                {
                    isShowSkillName = true;
                    abilityName = abilityUsed.Name;
                    if (amount == "full") healthIncrease = BattleInformation.Limca.Hp;
                    BattleInformation.Limca.CurrentHp = healthIncrease;
                    switch (character.CharacterUnitName)
                    {
                        case (BaseCharacter.CharacterUnit.CECIL):
                            BattleInformation.Cecil.CurrentMp -= abilityUsed.MpCost;
                            BattleInformation.cecilAtb = 0;
                            break;
                        case (BaseCharacter.CharacterUnit.LIMCA):
                            BattleInformation.Limca.CurrentMp -= abilityUsed.MpCost;
                            BattleInformation.limcaAtb = 0;
                            break;
                        case (BaseCharacter.CharacterUnit.GALARD):
                            BattleInformation.Galard.CurrentMp -= abilityUsed.MpCost;
                            BattleInformation.galardAtb = 0;
                            break;
                    }
                    BattleInformation.playerTurn = false;
                    selectedButton = 5;
                    selectedSkill = 5;
                    isShowSkillName = false;
                }
            }
            if (BattleInformation.Galard.CurrentHp == 0)
            {
                if (GUI.Button(new Rect(5, ((groupHeight - 10) * 2 / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Galard.Name))
                {
                    isShowSkillName = true;
                    abilityName = abilityUsed.Name;
                    if (amount == "full") healthIncrease = BattleInformation.Galard.Hp;
                    BattleInformation.Galard.CurrentHp = healthIncrease;
                    switch (character.CharacterUnitName)
                    {
                        case (BaseCharacter.CharacterUnit.CECIL):
                            BattleInformation.Cecil.CurrentMp -= abilityUsed.MpCost;
                            BattleInformation.cecilAtb = 0;
                            break;
                        case (BaseCharacter.CharacterUnit.LIMCA):
                            BattleInformation.Limca.CurrentMp -= abilityUsed.MpCost;
                            BattleInformation.limcaAtb = 0;
                            break;
                        case (BaseCharacter.CharacterUnit.GALARD):
                            BattleInformation.Galard.CurrentMp -= abilityUsed.MpCost;
                            BattleInformation.galardAtb = 0;
                            break;
                    }
                    BattleInformation.playerTurn = false;
                    selectedButton = 5;
                    selectedSkill = 5;
                    isShowSkillName = false;
                }
            }
            GUI.EndGroup();
        }
    }

    private void AttackSkill(BaseCharacter character, BaseAbility abilityUsed)
    {
        int enemySpawn = BattleInformation.enemySpawn;
        if (character.CurrentMp >= abilityUsed.MpCost)
        {
            if (abilityUsed.TargetEnemy == BaseAbility.Target.ALL)
            {
                DamageAllEnemy(character, abilityUsed, enemySpawn);
            }
            else if (abilityUsed.TargetEnemy == BaseAbility.Target.SINGLE)
            {
                ShowAttackSkillTargetGUI(character, abilityUsed, enemySpawn);
            }
        }
    }

    private void DamageAllEnemy(BaseCharacter character, BaseAbility abilityUsed, int enemySpawn)
    {
        int damage;
        isShowSkillName = true;
        abilityName = abilityUsed.Name;
        if (enemySpawn == 1)
        {
            if (BattleInformation.Enemy[0] != null)
            {
                if (BattleInformation.Enemy[0].CurrentHp > 0)
                {
                    damage = damageCalculation.CharSkillDamage(character, BattleInformation.Enemy[0], abilityUsed);
                    BattleInformation.Enemy[0].CurrentHp -= damage;
                    if (BattleInformation.Enemy[0].CurrentHp < 0) BattleInformation.Enemy[0].CurrentHp = 0;
                }
            }
        }
        else if (enemySpawn == 2)
        {
            if (BattleInformation.Enemy[0] != null)
            {
                if (BattleInformation.Enemy[0].CurrentHp > 0)
                {
                    damage = damageCalculation.CharSkillDamage(character, BattleInformation.Enemy[0], abilityUsed);
                    BattleInformation.Enemy[0].CurrentHp -= damage;
                    if (BattleInformation.Enemy[0].CurrentHp < 0) BattleInformation.Enemy[0].CurrentHp = 0;
                }
            }
            if (BattleInformation.Enemy[1] != null)
            {
                if (BattleInformation.Enemy[1].CurrentHp > 0)
                {
                    damage = damageCalculation.CharSkillDamage(character, BattleInformation.Enemy[1], abilityUsed);
                    BattleInformation.Enemy[1].CurrentHp -= damage;
                    if (BattleInformation.Enemy[1].CurrentHp < 0) BattleInformation.Enemy[1].CurrentHp = 0;
                }
            }
        }
        else if (enemySpawn == 3)
        {
            if (BattleInformation.Enemy[0] != null)
            {
                if (BattleInformation.Enemy[0].CurrentHp > 0)
                {
                    damage = damageCalculation.CharSkillDamage(character, BattleInformation.Enemy[0], abilityUsed);
                    BattleInformation.Enemy[0].CurrentHp -= damage;
                    if (BattleInformation.Enemy[0].CurrentHp < 0) BattleInformation.Enemy[0].CurrentHp = 0;
                }
            }
            if (BattleInformation.Enemy[1] != null)
            {
                if (BattleInformation.Enemy[1].CurrentHp > 0)
                {
                    damage = damageCalculation.CharSkillDamage(character, BattleInformation.Enemy[1], abilityUsed);
                    BattleInformation.Enemy[1].CurrentHp -= damage;
                    if (BattleInformation.Enemy[1].CurrentHp < 0) BattleInformation.Enemy[1].CurrentHp = 0;
                }
            }
            if (BattleInformation.Enemy[2] != null)
            {
                if (BattleInformation.Enemy[2].CurrentHp > 0)
                {
                    damage = damageCalculation.CharSkillDamage(character, BattleInformation.Enemy[2], abilityUsed);
                    BattleInformation.Enemy[2].CurrentHp -= damage;
                    if (BattleInformation.Enemy[2].CurrentHp < 0) BattleInformation.Enemy[2].CurrentHp = 0;
                }
            }
        }
        switch (character.CharacterUnitName)
        {
            case (BaseCharacter.CharacterUnit.CECIL):
                BattleInformation.Cecil.CurrentMp -= abilityUsed.MpCost;
                BattleInformation.cecilAtb = 0;
                break;
            case (BaseCharacter.CharacterUnit.LIMCA):
                BattleInformation.Limca.CurrentMp -= abilityUsed.MpCost;
                BattleInformation.limcaAtb = 0;
                break;
            case (BaseCharacter.CharacterUnit.GALARD):
                BattleInformation.Galard.CurrentMp -= abilityUsed.MpCost;
                BattleInformation.galardAtb = 0;
                break;
        }
        BattleInformation.playerTurn = false;
        selectedButton = 5;
        selectedSkill = 5;
        isShowSkillName = false;
    }

    private void ShowAttackSkillTargetGUI(BaseCharacter character, BaseAbility abilityUsed, int enemySpawn)
    {
        float groupHeight = Screen.height / 4 - 10;
        int damage;
        GUI.BeginGroup(new Rect(615, 0, 200, groupHeight), "");
        GUI.Box(new Rect(0, 0, 200, groupHeight), "");
        if (enemySpawn == 1)
        {
            if (BattleInformation.Enemy[0] != null)
            {
                if (BattleInformation.Enemy[0].CurrentHp > 0)
                {
                    if (GUI.Button(new Rect(5, ((groupHeight - 10) / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Enemy[0].Name))
                    {
                        isShowSkillName = true;
                        abilityName = abilityUsed.Name;
                        damage = damageCalculation.CharSkillDamage(character, BattleInformation.Enemy[0], abilityUsed);
                        BattleInformation.Enemy[0].CurrentHp -= damage;
                        if (BattleInformation.Enemy[0].CurrentHp < 0) BattleInformation.Enemy[0].CurrentHp = 0;
                        switch (character.CharacterUnitName)
                        {
                            case (BaseCharacter.CharacterUnit.CECIL):
                                BattleInformation.Cecil.CurrentMp -= abilityUsed.MpCost;
                                BattleInformation.cecilAtb = 0;
                                break;
                            case (BaseCharacter.CharacterUnit.LIMCA):
                                BattleInformation.Limca.CurrentMp -= abilityUsed.MpCost;
                                BattleInformation.limcaAtb = 0;
                                break;
                            case (BaseCharacter.CharacterUnit.GALARD):
                                BattleInformation.Galard.CurrentMp -= abilityUsed.MpCost;
                                BattleInformation.galardAtb = 0;
                                break;
                        }
                        BattleInformation.playerTurn = false;
                        selectedButton = 5;
                        selectedSkill = 5;
                        isShowSkillName = false;
                    }
                }
            }
        }
        else if (enemySpawn == 2)
        {
            if (BattleInformation.Enemy[0] != null)
            {
                if (BattleInformation.Enemy[0].CurrentHp > 0)
                {
                    if (GUI.Button(new Rect(5, 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Enemy[0].Name))
                    {
                        isShowSkillName = true;
                        abilityName = abilityUsed.Name;
                        damage = damageCalculation.CharSkillDamage(character, BattleInformation.Enemy[0], abilityUsed);
                        BattleInformation.Enemy[0].CurrentHp -= damage;
                        if (BattleInformation.Enemy[0].CurrentHp < 0) BattleInformation.Enemy[0].CurrentHp = 0;
                        switch (character.CharacterUnitName)
                        {
                            case (BaseCharacter.CharacterUnit.CECIL):
                                BattleInformation.Cecil.CurrentMp -= abilityUsed.MpCost;
                                BattleInformation.cecilAtb = 0;
                                break;
                            case (BaseCharacter.CharacterUnit.LIMCA):
                                BattleInformation.Limca.CurrentMp -= abilityUsed.MpCost;
                                BattleInformation.limcaAtb = 0;
                                break;
                            case (BaseCharacter.CharacterUnit.GALARD):
                                BattleInformation.Galard.CurrentMp -= abilityUsed.MpCost;
                                BattleInformation.galardAtb = 0;
                                break;
                        }
                        BattleInformation.playerTurn = false;
                        selectedButton = 5;
                        selectedSkill = 5;
                        isShowSkillName = false;
                    }
                }
            }
            if (BattleInformation.Enemy[1] != null)
            {
                if (BattleInformation.Enemy[1].CurrentHp > 0)
                {
                    if (GUI.Button(new Rect(5, ((groupHeight - 10) * 2 / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Enemy[1].Name))
                    {
                        isShowSkillName = true;
                        abilityName = abilityUsed.Name;
                        damage = damageCalculation.CharSkillDamage(character, BattleInformation.Enemy[1], abilityUsed);
                        BattleInformation.Enemy[1].CurrentHp -= damage;
                        if (BattleInformation.Enemy[1].CurrentHp < 0) BattleInformation.Enemy[1].CurrentHp = 0;
                        switch (character.CharacterUnitName)
                        {
                            case (BaseCharacter.CharacterUnit.CECIL):
                                BattleInformation.Cecil.CurrentMp -= abilityUsed.MpCost;
                                BattleInformation.cecilAtb = 0;
                                break;
                            case (BaseCharacter.CharacterUnit.LIMCA):
                                BattleInformation.Limca.CurrentMp -= abilityUsed.MpCost;
                                BattleInformation.limcaAtb = 0;
                                break;
                            case (BaseCharacter.CharacterUnit.GALARD):
                                BattleInformation.Galard.CurrentMp -= abilityUsed.MpCost;
                                BattleInformation.galardAtb = 0;
                                break;
                        }
                        BattleInformation.playerTurn = false;
                        selectedButton = 5;
                        selectedSkill = 5;
                        isShowSkillName = false;
                    }
                }
            }
        }
        else if (enemySpawn == 3)
        {
            if (BattleInformation.Enemy[0] != null)
            {
                if (BattleInformation.Enemy[0].CurrentHp > 0)
                {
                    if (GUI.Button(new Rect(5, 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Enemy[0].Name))
                    {
                        isShowSkillName = true;
                        abilityName = abilityUsed.Name;
                        damage = damageCalculation.CharSkillDamage(character, BattleInformation.Enemy[0], abilityUsed);
                        BattleInformation.Enemy[0].CurrentHp -= damage;
                        if (BattleInformation.Enemy[0].CurrentHp < 0) BattleInformation.Enemy[0].CurrentHp = 0;
                        switch (character.CharacterUnitName)
                        {
                            case (BaseCharacter.CharacterUnit.CECIL):
                                BattleInformation.Cecil.CurrentMp -= abilityUsed.MpCost;
                                BattleInformation.cecilAtb = 0;
                                break;
                            case (BaseCharacter.CharacterUnit.LIMCA):
                                BattleInformation.Limca.CurrentMp -= abilityUsed.MpCost;
                                BattleInformation.limcaAtb = 0;
                                break;
                            case (BaseCharacter.CharacterUnit.GALARD):
                                BattleInformation.Galard.CurrentMp -= abilityUsed.MpCost;
                                BattleInformation.galardAtb = 0;
                                break;
                        }
                        BattleInformation.playerTurn = false;
                        selectedButton = 5;
                        selectedSkill = 5;
                        isShowSkillName = false;
                    }
                }
                if (BattleInformation.Enemy[1] != null)
                {
                    if (BattleInformation.Enemy[1].CurrentHp > 0)
                    {
                        if (GUI.Button(new Rect(5, ((groupHeight - 10) / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Enemy[1].Name))
                        {
                            isShowSkillName = true;
                            abilityName = abilityUsed.Name;
                            damage = damageCalculation.CharSkillDamage(character, BattleInformation.Enemy[1], abilityUsed);
                            BattleInformation.Enemy[1].CurrentHp -= damage;
                            if (BattleInformation.Enemy[1].CurrentHp < 0) BattleInformation.Enemy[1].CurrentHp = 0;
                            switch (character.CharacterUnitName)
                            {
                                case (BaseCharacter.CharacterUnit.CECIL):
                                    BattleInformation.Cecil.CurrentMp -= abilityUsed.MpCost;
                                    BattleInformation.cecilAtb = 0;
                                    break;
                                case (BaseCharacter.CharacterUnit.LIMCA):
                                    BattleInformation.Limca.CurrentMp -= abilityUsed.MpCost;
                                    BattleInformation.limcaAtb = 0;
                                    break;
                                case (BaseCharacter.CharacterUnit.GALARD):
                                    BattleInformation.Galard.CurrentMp -= abilityUsed.MpCost;
                                    BattleInformation.galardAtb = 0;
                                    break;
                            }
                            BattleInformation.playerTurn = false;
                            selectedButton = 5;
                            selectedSkill = 5;
                            isShowSkillName = false;
                        }
                    }
                }
                if (BattleInformation.Enemy[2] != null)
                {
                    if (BattleInformation.Enemy[2].CurrentHp > 0)
                    {
                        if (GUI.Button(new Rect(5, ((groupHeight - 10) * 2 / 3) + 5, 190, ((groupHeight - 10) / 3) - 5), BattleInformation.Enemy[2].Name))
                        {
                            isShowSkillName = true;
                            abilityName = abilityUsed.Name;
                            damage = damageCalculation.CharSkillDamage(character, BattleInformation.Enemy[2], abilityUsed);
                            BattleInformation.Enemy[2].CurrentHp -= damage;
                            if (BattleInformation.Enemy[2].CurrentHp < 0) BattleInformation.Enemy[2].CurrentHp = 0;
                            switch (character.CharacterUnitName)
                            {
                                case (BaseCharacter.CharacterUnit.CECIL):
                                    BattleInformation.Cecil.CurrentMp -= abilityUsed.MpCost;
                                    BattleInformation.cecilAtb = 0;
                                    break;
                                case (BaseCharacter.CharacterUnit.LIMCA):
                                    BattleInformation.Limca.CurrentMp -= abilityUsed.MpCost;
                                    BattleInformation.limcaAtb = 0;
                                    break;
                                case (BaseCharacter.CharacterUnit.GALARD):
                                    BattleInformation.Galard.CurrentMp -= abilityUsed.MpCost;
                                    BattleInformation.galardAtb = 0;
                                    break;
                            }
                            BattleInformation.playerTurn = false;
                            selectedButton = 5;
                            selectedSkill = 5;
                            isShowSkillName = false;
                        }
                    }
                }
            }
        }
        GUI.EndGroup();
    }

    private void ShowSkillName()
    {
        if (isShowSkillName == true)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - 100, 50, 200, 30), "");
            GUI.Box(new Rect(0, 0, 200, 30), "");
            GUI.Label(new Rect(5, 5, 190, 20), abilityName);
            GUI.EndGroup();
        }
    }

    private void Escape(BaseCharacter character)
    {
        int escapeRate = EscapeRate(character.Agi);
        int random = Random.Range(0, 100);
        if (random < escapeRate)
        {
            BattleInformation.playerTurn = false;
            BattleStateManager.currentState = BattleStateManager.BattleState.WIN;
            selectedButton = 5;
        }
        else
        {
            switch (character.CharacterUnitName)
            {
                case (BaseCharacter.CharacterUnit.CECIL):
                    BattleInformation.cecilAtb = 0;
                    break;
                case (BaseCharacter.CharacterUnit.LIMCA):
                    BattleInformation.limcaAtb = 0;
                    break;
                case (BaseCharacter.CharacterUnit.GALARD):
                    BattleInformation.galardAtb = 0;
                    break;
            }
            BattleInformation.playerTurn = false;
            selectedButton = 5;
        }
    }

    private int EscapeRate(int agi)
    {
        int highestEnemyAgi = 0;
        if (BattleInformation.enemySpawn == 3)
        {
            if (BattleInformation.Enemy[0].Agi >= BattleInformation.Enemy[1].Agi && BattleInformation.Enemy[0].Agi >= BattleInformation.Enemy[2].Agi)
            {
                highestEnemyAgi = BattleInformation.Enemy[0].Agi;
            }
            else if (BattleInformation.Enemy[1].Agi >= BattleInformation.Enemy[0].Agi && BattleInformation.Enemy[1].Agi >= BattleInformation.Enemy[2].Agi)
            {
                highestEnemyAgi = BattleInformation.Enemy[1].Agi;
            }
            else if (BattleInformation.Enemy[2].Agi >= BattleInformation.Enemy[1].Agi && BattleInformation.Enemy[2].Agi >= BattleInformation.Enemy[0].Agi)
            {
                highestEnemyAgi = BattleInformation.Enemy[2].Agi;
            }
        }
        else if (BattleInformation.enemySpawn == 2)
        {
            if(BattleInformation.Enemy[0].Agi >= BattleInformation.Enemy[1].Agi)
            {
                highestEnemyAgi = BattleInformation.Enemy[0].Agi;
            }
            else if (BattleInformation.Enemy[0].Agi < BattleInformation.Enemy[1].Agi)
            {
                highestEnemyAgi = BattleInformation.Enemy[1].Agi;
            }
        }
        else if (BattleInformation.enemySpawn == 1)
        {
            highestEnemyAgi = BattleInformation.Enemy[0].Agi;
        }
        //Debug.Log("enemySpawn : " + BattleInformation.enemySpawn);
        //Debug.Log("highest agi : " + highestEnemyAgi);
        int escapeRate = 50 + (agi / highestEnemyAgi)*25;
        //Debug.Log(escapeRate);
        return escapeRate;
    }

    private void ShowBattleResult()
    {
        if (BattleStateManager.currentState == BattleStateManager.BattleState.LOSE)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height),"");
            //GUI.skin.GetStyle("Label").alignment = TextAnchor.UpperCenter;
            //GUI.skin.GetStyle("Label").fontSize = 48;
            GUI.Label(new Rect(0, Screen.height / 4, Screen.width, Screen.height), "Game Over");
            //GUI.skin.GetStyle("Label").fontSize = 24;
            GUI.Label(new Rect(0, Screen.height/2, Screen.width, Screen.height), "Left Click to return to Main Menu");
            //GUI.skin = null;
        }
        else if (BattleStateManager.currentState == BattleStateManager.BattleState.WIN)
        {
            itemDropList = BattleInformation.itemDropList;
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
            GUI.Label(new Rect(50, (Screen.height / 5), Screen.width-100, 20), "Exp obtained : " + BattleInformation.expObtained);
            GUI.Label(new Rect(50, (Screen.height / 5) + 30, Screen.width-100, 20), " Cecil Lv" + BattleInformation.Cecil.Lv+" Current exp : "+ BattleInformation.Cecil.CurrentXp+" Next Lv : "+BattleInformation.Cecil.XpToLvUp);
            GUI.Label(new Rect(50, (Screen.height / 5) + 60, Screen.width-100, 20), " Limca Lv" + BattleInformation.Limca.Lv + " Current exp : " + BattleInformation.Limca.CurrentXp + " Next Lv : " + BattleInformation.Limca.XpToLvUp);
            GUI.Label(new Rect(50, (Screen.height / 5) + 90, Screen.width-100, 20), " Galard Lv" + BattleInformation.Galard.Lv + " Current exp : " + BattleInformation.Galard.CurrentXp + " Next Lv : " + BattleInformation.Galard.XpToLvUp);
            GUI.Label(new Rect(50, (Screen.height / 5) + 130, Screen.width-100, 20), "Gold obtained : "+BattleInformation.goldObtained);
            GUI.Label(new Rect(50, (Screen.height / 5) + 160, Screen.width-100, 20), "Gold : " + GameInformation.Gold);
            GUI.Label(new Rect(50, (Screen.height / 5) + 200, 200, 20), "Item drop");
            int widthPosition = 0;
            int heightPosition = 0;
            if (itemDropList != null)
            {
                for (int i = 0; i < itemDropList.Count; i++)
                {
                    GUI.Label(new Rect(50 + widthPosition, (Screen.height / 5) + 230 + heightPosition, 200, 20), BattleInformation.itemDropList[i].Name);
                    if (widthPosition == 420)
                    {
                        heightPosition += 30;
                    }
                    if (widthPosition < 420)
                    {
                        widthPosition += 210;
                    }
                    else
                    {
                        widthPosition = 0;
                    }
                }
            }
            GUI.Label(new Rect(0, Screen.height * 4 / 5, Screen.width, Screen.height), "Left Click to return to Dungeon");

        }
    }
}
