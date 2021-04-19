using UnityEngine;
using System.Collections;
using System;

public class BattleStateManager : MonoBehaviour 
{
    public enum BattleState
    {
        START,
        STARTTURN,
        BATTLE,
        PLAYER,
        ENEMY,
        ENDTURN,
        WIN,
        LOSE,
        FANFARE,
        DUNGEON,
    }

    public static BattleState currentState = BattleState.DUNGEON;
    private BattleState currentTurn;
    private Battle battle = new Battle();
    private WinState winBattle = new WinState();
    //private StartBattle startState = new StartBattle();
    //private PlayerTurn playerTurn = new PlayerTurn();
    //private bool isInitialized;

    //public bool IsInitialized
    //{
    //    set { isInitialized = value; }
    //    get { return isInitialized; }
    //}

    void Start () 
    {
        //currentState = BattleState.START;
        //BaseCharacter cecil = new Cecil();
        //BattleInformation.Cecil = cecil;
        //battleStartState.startBattle();
	}
	
	void Update () 
    {
        //Debug.Log("current State : " + currentState);
        switch (currentState)
        {
            case (BattleState.START):
                string groupID = BattleInformation.groupID;
                //Debug.Log("array size : "+BattleInformation.Enemy.Length);
                StartBattle.Initialize(groupID);
                //startState.Initialize();
                break;
            case (BattleState.STARTTURN):
                //StartTurn.CheckDebug();
                StartTurn.InitTurn();
                break;
            case (BattleState.BATTLE):
                battle.BattlePhase();
                if (BattleInformation.Cecil.CurrentHp == 0 && BattleInformation.Limca.CurrentHp == 0 && BattleInformation.Galard.CurrentHp == 0)
                {
                    currentState = BattleState.LOSE;
                }
                int enemySpawn = BattleInformation.enemySpawn;
                if(enemySpawn==1)
                {
                    if (BattleInformation.Enemy[0].CurrentHp == 0) currentState = BattleState.WIN;
                }
                else if (enemySpawn == 2)
                {
                    if (BattleInformation.Enemy[0].CurrentHp == 0 && BattleInformation.Enemy[1].CurrentHp == 0) currentState = BattleState.WIN;
                }
                else if (enemySpawn == 3)
                {
                    if (BattleInformation.Enemy[0].CurrentHp == 0 && BattleInformation.Enemy[1].CurrentHp == 0 && BattleInformation.Enemy[2].CurrentHp == 0) currentState = BattleState.WIN;
                }
                winBattle.IsAdded = false;
                //Debug.Log(BattleInformation.cecilAtb);
                break;
            case (BattleState.PLAYER):
                break;
            case(BattleState.ENEMY):
                break;
            case(BattleState.ENDTURN):
                break;
            case(BattleState.WIN):
                winBattle.WinBattle();
                if (Input.GetMouseButton(0))
                {
                    BattleStateManager.currentState = BattleStateManager.BattleState.DUNGEON;
                    EncounterManager.isBattle = false;
                    StartBattle.isInitialized = false;
                }
                break;
            case(BattleState.LOSE):
                GameInformation.Cecil = new BaseCharacter();
                GameInformation.Limca = new BaseCharacter();
                GameInformation.Galard = new BaseCharacter();
                if (Input.GetMouseButton(0)) Application.LoadLevel("MainMenu");
                break;
            case (BattleState.FANFARE):
                break;
            case (BattleState.DUNGEON):
                if (BattleInformation.Enemy != null)
                {
                    Array.Clear(BattleInformation.Enemy, 0, BattleInformation.Enemy.Length);
                }
                if(BattleInformation.cecilAtb != 0)BattleInformation.cecilAtb = 0;
                if (BattleInformation.galardAtb != 0) BattleInformation.galardAtb = 0;
                if (BattleInformation.limcaAtb != 0) BattleInformation.limcaAtb = 0;
                if (BattleInformation.enemy01Atb != 0) BattleInformation.enemy01Atb = 0;
                if (BattleInformation.enemy02Atb != 0) BattleInformation.enemy02Atb = 0;
                if (BattleInformation.enemy03Atb != 0) BattleInformation.enemy03Atb = 0;
                   
                break;
        }
	}
}
