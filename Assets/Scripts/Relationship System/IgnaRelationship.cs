using UnityEngine;
using System.Collections;

public class IgnaRelationship : BaseRelationship {
	
	public int QuestOpen;
	
	public BaseQuest[] Quest100  = new BaseQuest[22];
	
	
	public void QuestAssigner(){
		
	}
	
	public IgnaRelationship(){
		//setting the relationship starting point
		RelationshipLevel = 0;
		RelationshipPoint = 0;
		//setting the preffered Gift ID for the characters
		PrefGiftID = "IT39";
		PrefGiftID2 = "IT40";
		//setting the quest via constructor
		Quest100 [0] = new BaseQuest ("IT14", 1, 1);
		Quest100 [1] = new BaseQuest ("IT15", 3, 1);
		Quest100 [2] = new BaseQuest ("IT14", "IT17", 5, 1, 2);
		Quest100 [3] = new BaseQuest ("IT14", "IT15", 7, 4, 2);
		Quest100 [4] = new BaseQuest ("IT17", 4, 1);
		Quest100 [5] = new BaseQuest ("IT14", "IT15", 7, 7, 2);
		Quest100 [6] = new BaseQuest ("IT15", "IT30", 5, 2, 2);
		Quest100 [7] = new BaseQuest ("IT18", 3, 1);
		Quest100 [8] = new BaseQuest ("IT14", "IT15", "IT17", 7, 4, 6, 3);
		Quest100 [9] = new BaseQuest ("IT20", 2, 1);
		Quest100 [10] = new BaseQuest ("IT16", "IT17", "IT20", 4, 5, 2, 3);
		Quest100 [11] = new BaseQuest ("IT18", "IT19", 4, 2, 2);
		Quest100 [12] = new BaseQuest ("IT14", "IT16", "IT21", 7, 3, 1, 3);
		Quest100 [13] = new BaseQuest ("IT17", "IT18", "IT22", 6, 4, 3, 3);
		Quest100 [14] = new BaseQuest ("IT24", "IT28", "IT31", 6, 4, 1, 3);
		Quest100 [15] = new BaseQuest ("IT19", "IT20", "IT21", 7, 5, 3, 3);
		Quest100 [16] = new BaseQuest ("IT23", "IT26", 2, 2, 2);
		Quest100 [17] = new BaseQuest ("IT22", "IT24", "IT25", 5, 2, 2, 3);
		Quest100 [18] = new BaseQuest ("IT28", "IT29", 3, 3, 2);
		Quest100 [19] = new BaseQuest ("IT33", "IT34", 2, 2, 2);
		Quest100 [20] = new BaseQuest ("IT29", "IT33", "IT35", 3, 4, 1, 3);
		Quest100 [21] = new BaseQuest ("IT19", "IT20", "IT27", "IT32", 7, 5, 2, 2, 4);
		
		
		for (int i =0; i<22; i++) {
			//setting the quest status, completion flag, taken flag(indicating the quest being taken) & types
			Quest100[i].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest100[i].QuestFlag = false;
			Quest100[i].QuestFlag = false;
			Quest100[i].QuestTakenFlag = false;
			Quest100 [i].QuestRequirement = BaseQuest.QuestType.ITEMGATHERING;
			if(i==0){
				Quest100 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
			}
			else if(i==2){
				Quest100 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
			}
			
			else if(i==4){
				Quest100 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
			}
			else if(i==7){
				Quest100 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
			}
			else if(i==11){
				Quest100 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
			}
			else if(i==16){
				Quest100 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
			}
			else if(i==17){
				Quest100 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
			}
			else{
				Quest100 [i].QuestCat = BaseQuest.QuestCategory.NONREPEATABLE;
			}
			
		}
		
		//Assigning QuestID
		
		
		Quest100 [0].QuestCode = BaseQuest.QuestID.Quest01;
		Quest100 [1].QuestCode = BaseQuest.QuestID.Quest02;
		Quest100 [2].QuestCode = BaseQuest.QuestID.Quest03;
		Quest100 [3].QuestCode = BaseQuest.QuestID.Quest04;
		Quest100 [4].QuestCode = BaseQuest.QuestID.Quest05;
		Quest100 [5].QuestCode = BaseQuest.QuestID.Quest06;
		Quest100 [6].QuestCode = BaseQuest.QuestID.Quest07;
		Quest100 [7].QuestCode = BaseQuest.QuestID.Quest08;
		Quest100 [8].QuestCode = BaseQuest.QuestID.Quest09;
		Quest100 [9].QuestCode = BaseQuest.QuestID.Quest10;
		Quest100 [10].QuestCode = BaseQuest.QuestID.Quest11;
		Quest100 [11].QuestCode = BaseQuest.QuestID.Quest12;
		Quest100 [12].QuestCode = BaseQuest.QuestID.Quest13;
		Quest100 [13].QuestCode = BaseQuest.QuestID.Quest14;
		Quest100 [14].QuestCode = BaseQuest.QuestID.Quest15;
		Quest100 [15].QuestCode = BaseQuest.QuestID.Quest16;
		Quest100 [16].QuestCode = BaseQuest.QuestID.Quest17;
		Quest100 [17].QuestCode = BaseQuest.QuestID.Quest18;
		Quest100 [18].QuestCode = BaseQuest.QuestID.Quest19;
		Quest100 [19].QuestCode = BaseQuest.QuestID.Quest20;
		Quest100 [20].QuestCode = BaseQuest.QuestID.Quest21;
		Quest100 [21].QuestCode = BaseQuest.QuestID.Quest22;
		
		//Quest Locking and Unlocking
		
		if (RelationshipLevel == 1) {
			Quest100 [0].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest100 [1].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
		}
		else if(RelationshipLevel == 2){
			Quest100 [0].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest100 [1].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest100 [2].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest100 [3].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
		}
		
		else if(RelationshipLevel == 3){
			Quest100 [2].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest100 [3].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest100 [4].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest100 [5].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest100 [6].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
		}
		
		
		else if(RelationshipLevel == 4){
			Quest100 [4].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest100 [5].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest100 [6].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest100 [7].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest100 [8].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest100 [9].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest100 [10].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			
		}
		
		else if(RelationshipLevel == 5){
			Quest100 [7].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest100 [8].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest100 [9].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest100 [10].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest100 [11].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest100 [12].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest100 [13].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest100 [14].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest100 [15].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
		}
		
		else if(RelationshipLevel == 6){
			Quest100 [11].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest100 [12].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest100 [13].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest100 [14].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest100 [15].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest100 [16].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest100 [17].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest100 [18].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest100 [19].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest100 [20].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest100 [21].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
		}
		
		//used to assign the data that will be displayed to the player
		
		Quest100 [0].QuestTitle = "Please Get Me a Blue Gel!";
		Quest100 [0].QuestDescription = "I need to get 1x Blue Gel. It’s a daily necessity for my experiment. I have to take care of another matter at hand, so please look for it for me. Of course I will pay.";
		Quest100 [0].QuestCondition = "Hand 1x Blue Gel to Igna.";
		Quest100 [0].QuestReward = 150;
		Quest100 [0].QuestNumber = 101;
		
		Quest100 [1].QuestTitle = "Experiment Time!";
		Quest100 [1].QuestDescription = "I need 3x Rotten Teeth! I currently don’t have time to go to find the victim, err I mean the monster. Please bring them to me, and I will give you handsome reward!";
		Quest100 [1].QuestCondition = "Hand 3x Rotten Teeth to Igna.";
		Quest100 [1].QuestReward = 300;
		Quest100 [1].QuestNumber = 102;
		
		Quest100 [2].QuestTitle = "More Experiment!";
		Quest100 [2].QuestDescription = "This time, I need 5x Blue Gel and 1x Tiger Fur.  Please bring it to me if you have them.";
		Quest100 [2].QuestCondition = "Hand 5x Blue Gel and 1x Tiger Fur to Igna.";
		Quest100 [2].QuestReward = 250;
		Quest100 [2].QuestNumber = 103;
		
		Quest100 [3].QuestTitle = "Just A Little Prank!";
		Quest100 [3].QuestDescription = "I’m kind of bored, so I want to try few new things. Can you please bring me 4x Rotten Teeth and 7x Blue Gel? I’m going enjoy my time trying to create something out of them. As usual, don’t worry about the reward.";
		Quest100 [3].QuestCondition = "Hand 4x Rotten Teeth and 7x Blue Gel to Igna.";
		Quest100 [3].QuestReward = 350;
		Quest100 [3].QuestNumber = 104;
		
		Quest100 [4].QuestTitle = "Fur Hunting!";
		Quest100 [4].QuestDescription = "The Tiger Fur you gave me last time was so comfortable. I wish to get more of them! Please gather 4x Tiger Fur and I will provide a good reward for you!";
		Quest100 [4].QuestCondition = "Hand 4x Tiger Fur to Igna.";
		Quest100 [4].QuestReward = 340;
		Quest100 [4].QuestNumber = 105;
		
		Quest100 [5].QuestTitle = "New Combination!";
		Quest100 [5].QuestDescription = "I just got a new idea for my experiment. Please bring me 7x Blue Gel and 7x Rotten Teeth! As usual, the payment’s not a problem.";
		Quest100 [5].QuestCondition = "Hand 7x Blue Gel and 7x Rotten Teeth to Igna.";
		Quest100 [5].QuestReward = 350;
		Quest100 [5].QuestNumber = 106;
		
		Quest100 [6].QuestTitle = "Challenge for You";
		Quest100 [6].QuestDescription = "This time, I want to test your skill. I don’t actually need them, but please gather 2x Colorful Ball and 5x Rotten Teeth! Rest assured, I will pay you like usual.";
		Quest100 [6].QuestCondition = "Hand 2x Colorful Ball and 5x Rotten Teeth to Igna.";
		Quest100 [6].QuestReward = 450;
		Quest100 [6].QuestNumber = 107;
		
		Quest100 [7].QuestTitle = "Get Me Broken Weapons!";
		Quest100 [7].QuestDescription = "It’s a not-so-rare material for my next experiment. The monster might be a bit dangerous, but I believe you can handle it. Please gather 3x Broken Weapon for me.";
		Quest100 [7].QuestCondition = "Hand 3x Broken Weapon to Igna.";
		Quest100 [7].QuestReward = 420;
		Quest100 [7].QuestNumber = 108;
		
		Quest100 [8].QuestTitle = "AJust the Right Time!";
		Quest100 [8].QuestDescription = "I’m short on Blue Gel, Rotten Teeth, and Tiger Fur. Please bring me 7x Blue Gel, 4x Rotten Teeth and 6x Tiger Fur.";
		Quest100 [8].QuestCondition = "Hand 7x Blue Gel, 4x Rotten Teeth and 6x Tiger Fur to Igna.";
		Quest100 [8].QuestReward = 500;
		Quest100 [8].QuestNumber = 109;
		
		Quest100 [9].QuestTitle = "Test Again";
		Quest100 [9].QuestDescription = "Try to get 2x White Feather for me. Ah, please be careful and don’t blame me for your death.";
		Quest100 [9].QuestCondition = "Hand 2x White Feather to Igna.";
		Quest100 [9].QuestReward = 470;
		Quest100 [9].QuestNumber = 110;
		
		Quest100 [10].QuestTitle = "Unlikely Combination!";
		Quest100 [10].QuestDescription = "Try to get 4x Plain Cloth, 5x Tiger Fur and 2x White Feather for me. I have a new ridiculous idea that needs to be tested.";
		Quest100 [10].QuestCondition = "Hand 4x Plain Cloth, 5x Tiger Fur and 2x White Feather to Igna.";
		Quest100 [10].QuestReward = 700;
		Quest100 [10].QuestNumber = 111;
		
		Quest100 [11].QuestTitle = "Let’s get dangerous!";
		Quest100 [11].QuestDescription = "Don’t ask me what I will do with them. I need 2x Liquid Poison and 4x Broken Weapon.  Some things are better left unknown…";
		Quest100 [11].QuestCondition = "Hand 2x Liquid Poison and 4x Broken Weapon to Igna.";
		Quest100 [11].QuestReward = 600;
		Quest100 [11].QuestNumber = 112;
		
		Quest100 [12].QuestTitle = "It’s Show Time!";
		Quest100 [12].QuestDescription = "I am currently in the mood to create crazy things! Please bring me 1x Chipped Axe, 7x Blue Gel and 3x Plain Cloth.";
		Quest100 [12].QuestCondition = "Hand 1x Chipped Axe, 7x Blue Gel and 3x Plain Cloth to Igna.";
		Quest100 [12].QuestReward = 650;
		Quest100 [12].QuestNumber = 113;
		
		Quest100 [13].QuestTitle = "Old Friend’s Request";
		Quest100 [13].QuestDescription = "An acquaintance of mine requested my help in gathering 3x Black Ash, 6x Tiger Fur and 4x Broken Weapon. As I’m currently busy, I will leave it to you. I know you won’t disappoint me.";
		Quest100 [13].QuestCondition = "Hand 3x Black Ash, 6x Tiger Fur and 4x Broken Weapon to Igna.";
		Quest100 [13].QuestReward = 800;
		Quest100 [13].QuestNumber = 114;
		
		Quest100 [14].QuestTitle = "Bored Again";
		Quest100 [14].QuestDescription = "It seems that I have no current experiment in mind, so I want you to gather some materials for me to play with. Please gather 1x Black Heart, 4x Azure Plate and 6x Steel Claw for me.";
		Quest100 [14].QuestCondition = "Hand 1x Black Heart, 4x Azure Plate and 6x Steel Claw to Igna.";
		Quest100 [14].QuestReward = 850;
		Quest100 [14].QuestNumber = 115;
		
		Quest100 [15].QuestTitle = "It’s About Business";
		Quest100 [15].QuestDescription = "Someone asked me to gather 7x Liquid Poison, 5x White Feather and 3x Chipped Axe. Please get them to me as I’m busy at the moment.";
		Quest100 [15].QuestCondition = "Hand 7x Liquid Poison, 5x White Feather and 3x Chipped Axe to Igna.";
		Quest100 [15].QuestReward = 760;
		Quest100 [15].QuestNumber = 116;
		
		Quest100 [16].QuestTitle = "My Collections";
		Quest100 [16].QuestDescription = "Please get me 2x Broken Scale and 2x Dragon Bone. They are essential in completing my collection.";
		Quest100 [16].QuestCondition = "Hand 2x Broken Scale and 2x Dragon Bone to Igna.";
		Quest100 [16].QuestReward = 850;
		Quest100 [16].QuestNumber = 117;
		
		Quest100 [17].QuestTitle = "A New Request!";
		Quest100 [17].QuestDescription = "My acquaintance asks me again for more favor. Please bring me 2x Rotten Bone, 5x Black Ash and 2x Steel Claw.";
		Quest100 [17].QuestCondition = "Hand 2x Rotten Bone, 5x Black Ash and 2x Steel Claw to Igna.";
		Quest100 [17].QuestReward = 900;
		Quest100 [17].QuestNumber = 118;
		
		Quest100 [18].QuestTitle = "Red and Blue";
		Quest100 [18].QuestDescription = "I want you to gather 3x Blazing Core and 3x Azure Plate. They are quite valuable, so treat them with care.";
		Quest100 [18].QuestCondition = "Hand gather 3x Blazing Core and 3x Azure Plate to Igna.";
		Quest100 [18].QuestReward = 850;
		Quest100 [18].QuestNumber = 119;
		
		Quest100 [19].QuestTitle = "Magical Weapon and Jewelry";
		Quest100 [19].QuestDescription = "A rumor has intrigued me. Please get me 2x Lightning Gem and 2x Cursed Sword. I heard that by mixing them, I will obtain an unexpected result.";
		Quest100 [19].QuestCondition = "Hand 2x Lightning Gem and 2x Cursed Sword to Igna.";
		Quest100 [19].QuestReward = 1000;
		Quest100 [19].QuestNumber = 120;
		
		Quest100 [20].QuestTitle = "Once Again for My Experiment!";
		Quest100 [20].QuestDescription = "Be prepared for a grand experiment! I’m at the peak of inspiration! Please gather 1x Dragon Heart, 3x Blazing Core and 4x Lightning Gem. I need these items for my grand experiment!";
		Quest100 [20].QuestCondition = "Hand 1x Dragon Heart, 3x Blazing Core and 4x Lightning Gem to Igna.";
		Quest100 [20].QuestReward = 1200;
		Quest100 [20].QuestNumber = 121;
		
		Quest100 [21].QuestTitle = "Another Random Curiosity!";
		Quest100 [21].QuestDescription = "I’m currently bored, so I want to test a new experiment. It might be the craziest one I’ve had and I’m counting on you. I need 2x Ectoplasm, 7x Liquid Poison, 5x White Feather and 2x Ball and Chain.";
		Quest100 [21].QuestCondition = "Hand 2x Ectoplasm, 7x Liquid Poison, 5x White Feather and 2x Ball and Chain to Igna.";
		Quest100 [21].QuestReward = 1500;
		Quest100 [21].QuestNumber = 122;
	}
	
	
	
//	public int QuestCompletion(int x){
//		if (Quest100[x].QuestFlag == true) {
//			Quest100[x].QuestStat = BaseQuest.QuestStatus.COMPLETE;
//			RelationshipProgress(70);
//			return Quest100 [x].QuestReward;
//		}
//		else{
//			return 0;
//		}
//	}
}
