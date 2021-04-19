using UnityEngine;
using System.Collections;

public class BaseQuest {
	
	private bool questFlag;
	//to flag when the quest is completed
	public bool QuestFlag
	{
		set{ questFlag = value; }
		get{ return questFlag; }
	}
	
	private int targetCounter;
	//to save the number of item/enemy. 2 means targetting 2 kind of enemy(enemy A & B) or item( item A & B)
	public int TargetCounter
	{
		set{ targetCounter = value; }
		get{ return targetCounter; }
	}
	
	public int questReward;
	//to store the reward value for each quest
	public int QuestReward{
		set{ questReward = value; }
		get{ return questReward; }
		
	}
	
	private string questTitle;
	//to store the quest title
	public string QuestTitle
	{
		set{ questTitle = value; }
		get{ return questTitle; }
	}
	
	private string questCondition;
	//to store the quest condition(how can the quest be completed) to be displayed to the player)
	public string QuestCondition
	{
		set{ questCondition = value; }
		get{ return questCondition; }
	}
	
	private string questDescription;
	//to store the quest description
	public string QuestDescription
	{
		set{ questDescription = value; }
		get{ return questDescription; }
	}
	
	private int questNumber;
	//to store the questnumber like questid, but uses int for the sake of convenience
	public int QuestNumber
	{
		set{ questNumber = value; }
		get{ return questNumber; }
	}

	private bool questRepetitionFlag;
	//to check whether the quest is repetable or not
	public bool QuestRepetitionFlag
	{
		set{ questRepetitionFlag = value; }
		get{ return questRepetitionFlag; }
	}

	private bool questTakenFlag;
	//to check whether the quest is taken or not
	public bool QuestTakenFlag
	{
		set{ questTakenFlag = value; }
		get{ return questTakenFlag; }
	}
	
	private string questTarget;
	//To store the target's ID(item or enemy)
	public string QuestTarget
	{
		set{ questTarget = value; }
		get{ return questTarget; }
	}
	
	private string questTarget2;
	//To store the 2nd target's ID(item or enemy)
	public string QuestTarget2
	{
		set{ questTarget2 = value; }
		get{ return questTarget2; }
	}
	
	private string questTarget3;
	//To store the 3rd target's ID(item or enemy)
	public string QuestTarget3
	{
		set{ questTarget3 = value; }
		get{ return questTarget3; }
	}
	
	private string questTarget4;
	//To store the 4th target's ID(item or enemy)
	public string QuestTarget4
	{
		set{ questTarget4 = value; }
		get{ return questTarget4; }
	}
	
	private int targetFlag;
	//To record the target's quantity (number of item needed or number of enemy you need to kill)
	public int TargetFlag
	{
		set{ targetFlag = value; }
		get{ return targetFlag; }
	}
	
	private int targetFlag2;
	//To record the 2nd target's quantity (number of item needed or number of enemy you need to kill)
	public int TargetFlag2
	{
		set{ targetFlag2 = value; }
		get{ return targetFlag2; }
	}
	
	private int targetFlag3;
	//To record the 3rd target's quantity (number of item needed or number of enemy you need to kill)
	public int TargetFlag3
	{
		set{ targetFlag3 = value; }
		get{ return targetFlag3; }
	}
	
	private int targetFlag4;
	//To record the 4th target's quantity (number of item needed or number of enemy you need to kill)
	public int TargetFlag4
	{
		set{ targetFlag4 = value; }
		get{ return targetFlag4; }
	}
	
	public enum QuestStatus
	{
		//The status of quest
		LOCKED,
		NOTTAKEN,
		ONGOING,
		COMPLETE
	}
	
	private QuestStatus questStat;
	
	public QuestStatus QuestStat
	{
		set{ questStat = value; }
		get{ return questStat; }
	}
	
	public enum QuestCategory
	{
		//The category of quest
		REPEATABLE,
		NONREPEATABLE
	}
	
	private QuestCategory questCat;
	
	public QuestCategory QuestCat
	{
		set{ questCat = value; }
		get{ return questCat; }
	}
	
	public enum QuestType
	{
		//The type of quest
		ITEMGATHERING,
		DEFEATENEMY
	}
	
	private QuestType questRequirement;
	
	public QuestType QuestRequirement
	{
		set{ questRequirement = value; }
		get{ return questRequirement; }
	}
	
	public enum QuestID
	{
		//The quest ID for each character
		Quest01,
		Quest02,
		Quest03,
		Quest04,
		Quest05,
		Quest06,
		Quest07,
		Quest08,
		Quest09,
		Quest10,
		Quest11,
		Quest12,
		Quest13,
		Quest14,
		Quest15,
		Quest16,
		Quest17,
		Quest18,
		Quest19,
		Quest20,
		Quest21,
		Quest22
	}
	
	private QuestID questCode;
	
	public QuestID QuestCode
	{
		set{ questCode = value; }
		get{ return questCode; }
	}


	public BaseQuest(string targetID, int flag, int objectFlag){
		//This is constructor for quest that hunts single target
		//Constructor for setting the value of QuestTarget(whether it's enemy ID or item ID),  flag(counting the number of target gathered or killed), 
		//object flag(setting the number of target to be hunted, 2 means hunting item/enemy A & B, 3 means hunting item/enemy C,D,E).
		TargetCounter = objectFlag;
		TargetFlag = flag;
		QuestTarget = targetID;
	}

	public BaseQuest(string targetID, string targetID2, int flag, int flag2, int objectFlag){
		//This is constructor for quest that hunts 2 targets
		//There are target ID & target ID 2, also flag & flag 2 
		//object flag is always equal to 2 in this constructor
		TargetCounter = objectFlag;
		TargetFlag = flag;
		QuestTarget = targetID;
		TargetFlag2 = flag2;
		QuestTarget2 = targetID2;
	}
	public BaseQuest(string targetID, string targetID2, string targetID3, int flag, int flag2, int flag3, int objectFlag){
		//This is constructor for quest that hunts 3 targets
		//There are target ID,  target ID 2 target ID 3, also there are flag, flag 2 & flag 3
		//object flag is always equal to 2 in this constructor
		TargetCounter = objectFlag;
		TargetFlag = flag;
		QuestTarget = targetID;
		TargetFlag2 = flag2;
		QuestTarget2 = targetID2;
		TargetFlag3 = flag3;
		QuestTarget3 = targetID3;
	}
	public BaseQuest(string targetID, string targetID2, string targetID3, string targetID4, int flag, int flag2, int flag3, int flag4, int objectFlag){
		//This is constructor for quest that hunts 3 targets
		//There are target ID,  target ID 2 target ID 3, also there are flag, flag 2 & flag 3
		//object flag is always equal to 2 in this constructor
		TargetCounter = objectFlag;
		TargetFlag = flag;
		QuestTarget = targetID;
		TargetFlag2 = flag2;
		QuestTarget2 = targetID2;
		TargetFlag3 = flag3;
		QuestTarget3 = targetID3;
		TargetFlag4 = flag4;
		QuestTarget4 = targetID4;
	}


	public int QuestChecker(){
		//This function is for checking the quest status, whether it's ongoing)
		if (QuestStat == BaseQuest.QuestStatus.ONGOING) {
			return 0;
		} 
		else {
			return 1;
		}
		
	}
	
	public int QuestProcessing(){
		//This `is for checking the targetflag
		if (TargetCounter == 1) {
			return 1;
		}
		else if (TargetCounter == 2) {
			return 2;
		}
		else if (TargetCounter == 3) {
			return 3;
		}
		else if (TargetCounter == 4) {
			return 4;
		}
		else{
			return 0;
		}
	}
	
	public void QuestConditionCheck1(string ID, int flag){
		//Checking the quest's completion by checking the quest target's ID & number of target acquired. For single target quests.
		if (ID == QuestTarget && flag >= TargetFlag) {
			QuestFlag = true;
		} 
		else if (ID == QuestTarget && flag < TargetFlag)
			QuestFlag = false;
	}
	public void QuestConditionCheck2(string ID, string ID2, int flag, int flag2){
		//Checking the quest's completion by checking the quest target's ID & number of target acquired. For 2 targets quests.
		if ((ID == QuestTarget && flag >= TargetFlag) && (ID2 == QuestTarget2 && flag2 >= TargetFlag2)) {
			QuestFlag = true;
			Debug.Log("Target Counter = "+TargetCounter);
			Debug.Log("Deeper Function Accessed");
		}
		
		else if ((ID == QuestTarget && flag < TargetFlag) || (ID2 == QuestTarget2 && flag2 < TargetFlag2))
			QuestFlag = false;
	}
	public void QuestConditionCheck3(string ID, string ID2, string ID3, int flag, int flag2, int flag3){
		//Checking the quest's completion by checking the quest target's ID & number of target acquired. For 3 targets quests.
		if ((ID == QuestTarget && flag >= TargetFlag) || (ID2 == QuestTarget2 && flag2 >= TargetFlag2) || (ID3 == QuestTarget3 && flag3 >= TargetFlag3)) {
			QuestFlag = true;
		}
		else if ((ID == QuestTarget && flag < TargetFlag) || (ID2 == QuestTarget2 && flag2 < TargetFlag2) || (ID3 == QuestTarget3 && flag3 < TargetFlag3))
			QuestFlag = false;
	}
	public void QuestConditionCheck4(string ID, string ID2, string ID3, string ID4, int flag, int flag2, int flag3, int flag4){
		//Checking the quest's completion by checking the quest target's ID & number of target acquired. For 4 targets quests.
		if ((ID == QuestTarget && flag >= TargetFlag) && (ID2 == QuestTarget2 && flag2 >= TargetFlag2) && (ID3 == QuestTarget3 && flag3 >= TargetFlag3) && (ID4 == QuestTarget4 && flag4 >= TargetFlag4)) {
			QuestFlag = true;
		}
		else if ((ID == QuestTarget && flag < TargetFlag) || (ID2 == QuestTarget2 && flag2 < TargetFlag2) || (ID3 == QuestTarget3 && flag3 < TargetFlag3) || (ID4 == QuestTarget4 && flag4 >= TargetFlag4))
			QuestFlag = false;
	}

	public int QuestRewardExecutor(){
		//For returning the reward value of a quest to be added to the gold information
		if (QuestFlag == true) {
			QuestFlag = false;
			QuestStat = QuestStatus.NOTTAKEN;
			return QuestReward;
		}
		else{
			return 0;
		}
	}


	public void QuestDeactivator(bool rewardcheck){
		//To check if the reward is given or not
		if (rewardcheck == true) {

		}
	}



}
