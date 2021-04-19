using UnityEngine;
using System.Collections;

public class EnemyGroupChanger : MonoBehaviour 
{
    public string enemyGroup;

    void OnTriggerEnter2D(Collider2D player)
    {
        BattleInformation.groupID = enemyGroup;
    }
}
