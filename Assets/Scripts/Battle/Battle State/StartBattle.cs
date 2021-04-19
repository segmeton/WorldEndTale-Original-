using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartBattle
{
    public static bool isInitialized = false;
    //public static string groupID = "GR01";

    public static void Initialize(string groupID)
    {
        if (BattleStateManager.currentState == BattleStateManager.BattleState.START && isInitialized == false)
        {
            //Debug.Log("StartBattle");
            InitializeParty();
            SpawnEnemy(groupID);
            isInitialized = true;
            BattleStateManager.currentState = BattleStateManager.BattleState.STARTTURN;
            //BattleInformation.cecilAtb = 0;
            //BattleInformation.limcaAtb = 0;
            //BattleInformation.galardAtb = 0;
            //BattleInformation.enemy01Atb = 0;
            //BattleInformation.enemy02Atb = 0;
            //BattleInformation.enemy03Atb = 0;
        }
    }

    public static void InitializeParty()
    {
        //GameInformation.Cecil.Lv = 1;
        //GameInformation.Limca.Lv = 1;
        //GameInformation.Galard.Lv = 1;
        BattleInformation.Cecil = GameInformation.Cecil;
        BattleInformation.Limca = GameInformation.Limca;
        BattleInformation.Galard = GameInformation.Galard;
    }
    public static void SpawnEnemy(string groupID)
    {
        //Debug.Log("numSpawn : "+numSpawn);
        string enemyID;
        string tempEnemyID;
        List<string> enemyList = new List<string>();
        switch (groupID)
        {
            case "GR01":
                enemyList = BattleInformation.enemyGroup01;
                break;
            case "GR02":
                enemyList = BattleInformation.enemyGroup02;
                break;
            case "GR03":
                enemyList = BattleInformation.enemyGroup03;
                break;
            case "GR04":
                enemyList = BattleInformation.enemyGroup04;
                break;
            case "GR05":
                enemyList = BattleInformation.enemyGroup05;
                break;
            case "GR06":
                enemyList = BattleInformation.enemyGroup06;
                break;
            case "GR07":
                enemyList = BattleInformation.enemyGroup07;
                break;
        }
        if (groupID != "GR01" && groupID != "GR02" && groupID != "GR03")
        {
            BattleInformation.enemySpawn = 1;
            enemyID = enemyList[0];
            for (int i = 0; i < GameInformation.enemyTable.Count; i++)
            {
                GameInformation.enemyTable[i].TryGetValue("ID", out tempEnemyID);
                if (enemyID == tempEnemyID)
                {
                    BattleInformation.Enemy[0] = GetEnemyData(enemyID, groupID);
                    GameInformation.idChecker[0] = BattleInformation.Enemy[0].ID;
                    break;
                }
            }
        }
        else
        {
            int numSpawn = Random.Range(1, BattleInformation.Enemy.Length + 1);
            GameInformation.spawnCount = numSpawn;
            BattleInformation.enemySpawn = numSpawn;
            for (int i = 0; i < numSpawn; i++)
            {
                int temp = Random.Range(0, enemyList.Count);
                //Debug.Log("count : " + enemyList.Count);
                //Debug.Log("temp : " + temp);
                enemyID = enemyList[temp];
                //Debug.Log("EnemyID : " + enemyID);
                for (int j = 0; j < GameInformation.enemyTable.Count; j++)
                {
                    GameInformation.enemyTable[j].TryGetValue("ID", out tempEnemyID);
                    //Debug.Log("tempEnemyID : "+tempEnemyID);
                    if (enemyID == tempEnemyID)
                    {
                        BattleInformation.Enemy[i] = GetEnemyData(enemyID, groupID);
                        GameInformation.idChecker[i] = BattleInformation.Enemy[i].ID;
                        break;
                    }
                }
            }
        }
    }

    private static BaseEnemy GetEnemyData(string enemyID, string groupID)
    {
        BaseEnemy enemyData = new BaseEnemy();
        string tempEnemyID;
        string name;
        string hp;
        string mp;
        string str;
        string agi;
        string end;
        string mag;
        string acc;
        string lv;
        string exp;
        string gold;
        string element;
        string commonDrop;
        string uncommonDrop;
        string rareDrop;
       
        for (int j = 0; j < GameInformation.enemyTable.Count; j++)
        {
            GameInformation.enemyTable[j].TryGetValue("ID", out tempEnemyID);
            if (enemyID == tempEnemyID)
            {
                GameInformation.enemyTable[j].TryGetValue("Name", out name);
                GameInformation.enemyTable[j].TryGetValue("HP", out hp);
                GameInformation.enemyTable[j].TryGetValue("MP", out mp);
                GameInformation.enemyTable[j].TryGetValue("Str", out str);
                GameInformation.enemyTable[j].TryGetValue("Agi", out agi);
                GameInformation.enemyTable[j].TryGetValue("End", out end);
                GameInformation.enemyTable[j].TryGetValue("Acc", out acc);
                GameInformation.enemyTable[j].TryGetValue("Mag", out mag);
                GameInformation.enemyTable[j].TryGetValue("Level", out lv);
                GameInformation.enemyTable[j].TryGetValue("Exp", out exp);
                GameInformation.enemyTable[j].TryGetValue("Gold", out gold);
                GameInformation.enemyTable[j].TryGetValue("Element", out element);

                enemyData.Name = name;
                enemyData.ID = enemyID;
                enemyData.Group = groupID;
                enemyData.Lv = int.Parse(lv);

                enemyData.Hp = int.Parse(hp);
                enemyData.Mp = int.Parse(mp);
                enemyData.CurrentHp = int.Parse(hp);
                enemyData.CurrentMp = int.Parse(mp);
                enemyData.Str = int.Parse(str);
                enemyData.End = int.Parse(end);
                enemyData.Mag = int.Parse(mag);
                enemyData.Acc = int.Parse(acc);
                enemyData.Agi = int.Parse(agi);

                enemyData.AbilityList = GetAbilityList(enemyID);

                enemyData.GoldDrop = int.Parse(gold);
                enemyData.ExpDrop = int.Parse(exp);
                //Debug.Log("element : " + element);
                //enemyData.Element.ElementType = BaseElement.Element.WATER;
                switch (element)
                {
                    case "Water":
                        enemyData.Element.ElementType = BaseElement.Element.WATER;
                        break;
                    case "Fire":
                        enemyData.Element.ElementType = BaseElement.Element.FIRE;
                        break;
                    case "Wind":
                        enemyData.Element.ElementType = BaseElement.Element.WIND;
                        break;
                    case "Electric":
                        enemyData.Element.ElementType = BaseElement.Element.ELECTRIC;
                        break;
                    case "Earth":
                        enemyData.Element.ElementType = BaseElement.Element.EARTH;
                        break;
                    case "Dark":
                        enemyData.Element.ElementType = BaseElement.Element.DARK;
                        break;
                    case "Light":
                        enemyData.Element.ElementType = BaseElement.Element.LIGHT;
                        break;
                    case "Neutral":
                        enemyData.Element.ElementType = BaseElement.Element.NEUTRAL;
                        break;
                }

                for (int k = 0; k < GameInformation.enemyDropTable.Count; k++)
                {
                    GameInformation.enemyDropTable[k].TryGetValue("EnemyID", out tempEnemyID);
                    if (enemyID == tempEnemyID)
                    {
                        GameInformation.enemyDropTable[k].TryGetValue("CommonDropID", out commonDrop);
                        GameInformation.enemyDropTable[k].TryGetValue("UncommonDropID", out uncommonDrop);
                        GameInformation.enemyDropTable[k].TryGetValue("RareDropID", out rareDrop);
                        enemyData.CommonDropID = commonDrop;
                        enemyData.UncommonDropID = uncommonDrop;
                        enemyData.RareDropID = rareDrop;
                        break;
                    }
                }
                break;
            }
        }
        return enemyData;
    }

    private static List<BaseAbility> GetAbilityList(string ID)
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
        BaseAbility ability = new BaseAbility();
        List<BaseAbility> abilityList = new List<BaseAbility>();
        for (int i = 0; i < GameInformation.skillUserTable.Count; i++)
        {
            GameInformation.skillUserTable[i].TryGetValue("CharID", out charID);
            if (charID == ID)
            {
                GameInformation.skillUserTable[i].TryGetValue("SkillID", out skillID);
                for (int j = 0; j < GameInformation.skillTable.Count; j++)
                {
                    GameInformation.skillTable[j].TryGetValue("ID", out tempID);
                    if (skillID == tempID)
                    {
                        GameInformation.skillTable[j].TryGetValue("Name", out name);
                        GameInformation.skillTable[j].TryGetValue("Description", out description);
                        GameInformation.skillTable[j].TryGetValue("BasePower", out basePower);
                        GameInformation.skillTable[j].TryGetValue("MPCost", out mpCost);
                        GameInformation.skillTable[j].TryGetValue("Element", out element);
                        GameInformation.skillTable[j].TryGetValue("Type", out type);
                        GameInformation.skillTable[j].TryGetValue("Target", out target);

                        ability.ID = skillID;
                        ability.Name = name;
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
        return abilityList;
    }
}
