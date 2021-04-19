using UnityEngine;
using System.Collections;

public class BaseRelationship {
	
	private bool relationshipEventTrigger;
	//To set & check the trigger for event
	public bool RelationshipEventTrigger{
		set{ relationshipEventTrigger = value; }
		get{ return relationshipEventTrigger; }
	}

	private bool relationshipStartFlag;
	//To set & check whether the relationship has started
	public bool RelationshipStartFlag{
		set{ relationshipStartFlag = value; }
		get{ return relationshipStartFlag; }
	}
	
	private int relationshipLevel;
	//To store relationship level
	public int RelationshipLevel
	{
		set{ relationshipLevel = value; }
		get{ return relationshipLevel; }
	}
	
	private int relationshipPoint;
	//To store relationship point
	public int RelationshipPoint
	{
		set{ relationshipPoint = value; }
		get{ return relationshipPoint; }
	}

	private string prefGiftID;
	//To store the first preferred giftID for a character
	public string PrefGiftID
	{
		set{ prefGiftID = value; }
		get{ return prefGiftID; }
	}

	private string prefGiftID2;
	//To store the second preferred giftID for a character
	public string PrefGiftID2
	{
		set{ prefGiftID2 = value; }
		get{ return prefGiftID2; }
	}
	
	private int giftReward;
	//To store the gift reward value
	public int GiftReward{
		set{ giftReward = value; }
		get{ return giftReward; }
	}
	
	public int GiftCheck(string GiftID, int Quantity){
		//To check whether the gift given matches the preferred gift
		if (GiftID == PrefGiftID) {
			GiftReward = 10 * Quantity;
		} 
		else if (GiftID == PrefGiftID2) {
			GiftReward = 50 * Quantity;
		} 
		else{
			GiftReward = 0;
		}
		return GiftReward;
	}
	public void RelationshipStart(){
		//To start the relationship
		relationshipLevel = 1;
		relationshipPoint = 0;
	}
	
	public int RelationshipProgress(int point){
		//To calculate the progress & level up the relationship level
		RelationshipPoint = RelationshipPoint + point;
		
		if (relationshipLevel == 1 && relationshipPoint >= 100) {
			relationshipLevel = 2;
			relationshipPoint = relationshipPoint - 100;
		}
		else if (relationshipLevel == 2 &&relationshipPoint >= 150) {
			relationshipLevel = 3;
			relationshipPoint = relationshipPoint - 150;
		}
		else if (relationshipLevel == 3 && relationshipPoint >= 250) {
			relationshipLevel = 4;
			relationshipPoint = relationshipPoint - 250;
		}
		else if (relationshipLevel == 4 &&relationshipPoint >= 375) {
			relationshipLevel = 5;
			relationshipPoint = relationshipPoint - 375;
		}
		else if (relationshipLevel == 5 &&relationshipPoint >= 480) {
			relationshipLevel = 6;
			relationshipPoint = relationshipPoint - 480;
		}
		else if (relationshipLevel == 6 &&relationshipPoint >= 600) {
			relationshipLevel = 7;
			relationshipPoint = 0;
		}

		RelationshipEventTrigger = true;
		
		return RelationshipLevel;
	}
	
	
}