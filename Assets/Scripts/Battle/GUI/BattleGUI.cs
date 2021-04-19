using UnityEngine;
using System.Collections;

public class BattleGUI : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        //GUI.Label(new Rect(50, 90, 200, 30), BattleInformation.Cecil.Name + " HP : " + BattleInformation.Cecil.Hp);
        //GUI.Label(new Rect(50, 130, 200, 30), BattleInformation.Enemy.Name + " HP : " + BattleInformation.Enemy.Hp);
        //if (BattleStateManager.currentState == BattleStateManager.BattleState.START)
        //{
        //    Debug.Log("Start State");
        //    StartStateGUI();
        //}
        //else if (BattleStateManager.currentState == BattleStateManager.BattleState.PLAYER)
        //{
        //    Debug.Log("Player State");
        //    PlayerStateGUI();
        //}
        //else if (BattleStateManager.currentState == BattleStateManager.BattleState.ENEMY)
        //{
        //    Debug.Log("Enemy State");
        //    EnemyStateGUI();
        //}
        //else if (BattleStateManager.currentState == BattleStateManager.BattleState.ENDTURN)
        //{
        //    Debug.Log("End Turn State");
        //    EndTurnStateGUI();
        //}
        //else if (BattleStateManager.currentState == BattleStateManager.BattleState.WIN)
        //{
        //    Debug.Log("Win State");
        //    WinStateGUI();
        //}
        //else if (BattleStateManager.currentState == BattleStateManager.BattleState.LOSE)
        //{
        //    Debug.Log("Lose State");
        //    LoseStateGUI();
        //}
    }

    private void StartStateGUI()
    {
        //if (GUI.Button(new Rect(50, 50, 200, 30), "Start"))
        //{
        //    BattleStateManager.currentState = BattleStateManager.BattleState.PLAYER;
        //}
    }

    private void PlayerStateGUI()
    {
        //if (GUI.Button(new Rect(50, 50, 100, 30), "Attack"))
        //{
        //    int damage = DamageCalculation.PlayerAtkDmg(BattleInformation.Cecil);
        //    Debug.Log("Cecil Damage : "+damage);
        //    BattleInformation.Enemy.Hp = DamageCalculation.HpReduced(BattleInformation.Enemy, damage);
        //    if (BattleInformation.Enemy.Hp <= 0)
        //    {
        //        BattleStateManager.currentState = BattleStateManager.BattleState.WIN;
        //    }
        //    else
        //    {
        //        BattleStateManager.currentState = BattleStateManager.BattleState.ENEMY;
        //    }
        //}
    }

    private void EnemyStateGUI()
    {
        //if (GUI.Button(new Rect(50, 50, 100, 30), "Enemy Attack"))
        //{
        //    int damage = DamageCalculation.PlayerAtkDmg(BattleInformation.Enemy);
        //    Debug.Log("Enemy Damage : " + damage);
        //    BattleInformation.Cecil.Hp = DamageCalculation.HpReduced(BattleInformation.Cecil, damage);
        //    if (BattleInformation.Cecil.Hp <= 0)
        //    {
        //        BattleStateManager.currentState = BattleStateManager.BattleState.LOSE;
        //    }
        //    else
        //    {
        //        BattleStateManager.currentState = BattleStateManager.BattleState.PLAYER;
        //    }
        //}
    }

    private void EndTurnStateGUI()
    { 
        
    }
    private void WinStateGUI()
    {
        GUI.Label(new Rect(250, 50, 200, 30),"You Win");
        if (GUI.Button(new Rect(250, 100, 200, 30), "Back"))
        {
            Application.LoadLevel("Dungeon 2");
        }
    }

    private void LoseStateGUI()
    {
        GUI.Label(new Rect(250, 50, 200, 30), "you Lose");
        if (GUI.Button(new Rect(250, 100, 200, 30), "Restart"))
        {
            Application.LoadLevel("MainMenu");
        }
    }
}
