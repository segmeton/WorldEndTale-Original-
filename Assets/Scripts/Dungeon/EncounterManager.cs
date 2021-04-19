using UnityEngine;
using System.Collections;

public class EncounterManager : MonoBehaviour
{
    public static bool isBattle = false;
    private int frameCounter = 0;
    private int random;
    public int encounterRate;
    private int encounterValidate;

    void Update()
    {
        randomEncounter();
    }
    
    private void randomEncounter()
    {
        if (BattleInformation.groupID == "GR01" || BattleInformation.groupID == "GR02" || BattleInformation.groupID == "GR03")
        {
            if (isBattle == false && TownPortal.inPortal == false && GameStatusGUI.isOpen == false)
            {
                if (Input.GetKey("right") || Input.GetKey("left") || Input.GetKey("up") || Input.GetKey("down"))
                {
                    frameCounter++;
                    if (frameCounter == 4)
                    {
                        random = Random.Range(0, 1000);
                        encounterValidate = encounterRate * 10;
                        //Debug.Log("random : " + random);
                        if (random < encounterValidate)
                        {
                            isBattle = true;
                            BattleStateManager.currentState = BattleStateManager.BattleState.START;
                        }
                        frameCounter = 0;
                    }
                }
            }
        }     
    }
}
