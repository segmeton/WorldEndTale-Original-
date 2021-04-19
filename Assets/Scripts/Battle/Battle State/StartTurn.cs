using UnityEngine;
using System.Collections;

public class StartTurn
{
    public static bool isStarted = false;

    public static void InitTurn()
    {
        isStarted = true;
        BattleStateManager.currentState = BattleStateManager.BattleState.BATTLE;
    }

    public static void CheckDebug() 
    {
        Debug.Log("StartTurn");
        //Debug.Log(BattleInformation.Cecil.Name);
        //Debug.Log(BattleInformation.Limca.Name);
        //Debug.Log(BattleInformation.Galard.Name);
        for (int i = 0; i < 3; i++)
        {
            if (BattleInformation.Enemy[i] != null)
            {
                Debug.Log("Enemy "+(i+1)+" : "+BattleInformation.Enemy[i].Name);
            }
        }
        //BattleStateManager.currentState = BattleStateManager.BattleState.FANFARE;
    }
}
