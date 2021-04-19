using UnityEngine;
using System.Collections;

public class PlayerTurn
{
    public bool Run(BaseCharacter character, BaseEnemy[] enemies)
    {
        bool success;
        //Current character AGI/highest AGI of enemies + 0.5. If results >= 0.75, escape success. Else, escape fail.
        int escapeChance = 50;
        int random = Random.Range(0, 100);
        if (random < escapeChance)
        {
            success = true;
        }
        else
        {
            success = false;
        }
        return success;
    }
}
