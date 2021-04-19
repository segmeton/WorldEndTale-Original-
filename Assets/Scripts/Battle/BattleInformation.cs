using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleInformation : MonoBehaviour
{
    public static BaseCharacter Cecil { set; get; }
    public static BaseCharacter Limca { set; get; }
    public static BaseCharacter Galard { set; get; }
    public static BaseEnemy[] Enemy = new BaseEnemy[3];
    public static List<string> enemyGroup01 = new List<string>();
    public static List<string> enemyGroup02 = new List<string>();
    public static List<string> enemyGroup03 = new List<string>();
    public static List<string> enemyGroup04 = new List<string>();
    public static List<string> enemyGroup05 = new List<string>();
    public static List<string> enemyGroup06 = new List<string>();
    public static List<string> enemyGroup07 = new List<string>();
    public static int maxAtbValue = 300;
    public static float cecilAtb = 0;
    public static float limcaAtb = 0;
    public static float galardAtb = 0;
    public static float enemy01Atb = 0;
    public static float enemy02Atb = 0;
    public static float enemy03Atb = 0;
    public static int enemySpawn;
    public static bool playerTurn = false;
    public static int goldObtained;
    public static int expObtained;
    public static string groupID;
    public static List<Item> itemDropList = new List<Item>();
    public static List<BaseAccessory> accessoryDrop = new List<BaseAccessory>();
    public static bool firstBossDefeat = false;
    public static bool secondBossDefeat = false;
    public static bool thirdBossDefeat = false;
    public static bool lastBossDefeat = false;
    //public static List<BaseEnemy> enemyGroup01 = new List<BaseEnemy>();
    //public static List<BaseEnemy> enemyGroup02 = new List<BaseEnemy>();
    //public static List<BaseEnemy> enemyGroup03 = new List<BaseEnemy>();

    void Awake()
    {
        enemyGroup01 = GetEnemyList("GR01");
        enemyGroup02 = GetEnemyList("GR02");
        enemyGroup03 = GetEnemyList("GR03");
        enemyGroup04 = GetEnemyList("GR04");
        enemyGroup05 = GetEnemyList("GR05");
        enemyGroup06 = GetEnemyList("GR06");
        enemyGroup07 = GetEnemyList("GR07");
    }

    private List<string> GetEnemyList(string groupID)
    {
        List<string> enemyList = new List<string>();
        string tempGroupID;
        string enemyID;
        for (int i = 0; i < GameInformation.enemyGroupTable.Count; i++)
        {
            GameInformation.enemyGroupTable[i].TryGetValue("GroupID", out tempGroupID);
            if (groupID == tempGroupID)
            {
                GameInformation.enemyGroupTable[i].TryGetValue("EnemyID", out enemyID);
                enemyList.Add(enemyID);
            }
        }
        return enemyList;
    }
}
