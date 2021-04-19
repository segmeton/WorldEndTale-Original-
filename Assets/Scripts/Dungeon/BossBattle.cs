using UnityEngine;
using System.Collections;

public class BossBattle : MonoBehaviour 
{
    public string enemyGroup;
    private bool enterBosFight = false;

    void OnTriggerEnter2D(Collider2D player)
    {
        BattleInformation.groupID = enemyGroup;
        switch(enemyGroup)
        {
            case "GR04":
                if (BattleInformation.firstBossDefeat == false)
                {
                    enterBosFight = true;
                }
                break;
            case "GR05":
                if (BattleInformation.secondBossDefeat == false)
                {
                    enterBosFight = true;
                }
                break;
            case "GR06":
                if (BattleInformation.thirdBossDefeat == false)
                {
                    enterBosFight = true;
                }
                break;
            case "GR07":
                if (BattleInformation.lastBossDefeat == false)
                {
                    enterBosFight = true;
                }
                break;
        }
        if (enterBosFight == true)
        {
            EncounterManager.isBattle = true;
            BattleStateManager.currentState = BattleStateManager.BattleState.START;
        }
    }
}
