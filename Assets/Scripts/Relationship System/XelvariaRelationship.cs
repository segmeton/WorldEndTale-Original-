using UnityEngine;
using System.Collections;

public class XelvariaRelationship : BaseRelationship {
	
	public int QuestOpen;
	
	public BaseQuest[] Quest200  = new BaseQuest[22];
	
	

	
	public XelvariaRelationship(){
		RelationshipLevel = 0;
		RelationshipPoint = 0;
		PrefGiftID = "IT41";
		PrefGiftID2 = "IT42";
		Quest200 [0] = new BaseQuest ("IT16", 5, 1);
		Quest200 [1] = new BaseQuest ("EN01", 6, 1);
		Quest200 [2] = new BaseQuest ("IT17", 3, 1);
		Quest200 [3] = new BaseQuest ("EN02", 5, 1);
		Quest200 [4] = new BaseQuest ("IT18", "IT20", 5, 2, 2);
		Quest200 [5] = new BaseQuest ("EN02", "EN03", 4, 3, 2);
		Quest200 [6] = new BaseQuest ("EN04", 3, 1);
		Quest200 [7] = new BaseQuest ("IT31", "IT32", 1, 2, 2);
		Quest200 [8] = new BaseQuest ("EN03", "EN05", 4, 2, 2);
		Quest200 [9] = new BaseQuest ("EN02", "EN03", "EN06", 5, 3, 2, 3);
		Quest200 [10] = new BaseQuest ("EN06", "EN07", 2, 3, 2);
		Quest200 [11] = new BaseQuest ("IT33", "IT35", 2, 2, 2);
		Quest200 [12] = new BaseQuest ("EN01", "EN02", "EN03", "EN06", 7, 10, 5, 2, 4);
		Quest200 [13] = new BaseQuest ("EN07", 5, 1);
		Quest200 [14] = new BaseQuest ("EN08", 4, 1);
		Quest200 [15] = new BaseQuest ("EN05", "EN06", "EN07", 7, 4, 2, 3);
		Quest200 [16] = new BaseQuest ("IT31", "IT32", "IT35", 3, 5, 2, 3);
		Quest200 [17] = new BaseQuest ("IT14", "IT19", "IT30", "IT37", 7, 3, 2, 5, 4);
		Quest200 [18] = new BaseQuest ("EN07", "EN08", "EN09", 10, 7, 5, 3);
		Quest200 [19] = new BaseQuest ("EN10", "EN11", 7, 7, 2);
		Quest200 [20] = new BaseQuest ("EN08", "EN09", "EN10", 5, 7, 3, 3);
		Quest200 [21] = new BaseQuest ("EN08", "EN09", "EN10", "EN11", 2, 5, 6, 3, 4);
		
		
		for (int i =0; i<22; i++) {
			Quest200[i].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest200[i].QuestFlag = false;
			Quest200[i].QuestFlag = false;
			Quest200[i].QuestTakenFlag = false;
			
			if(i==0){
				Quest200 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
				Quest200 [i].QuestRequirement = BaseQuest.QuestType.ITEMGATHERING;
			}
			else if(i==2){
				Quest200 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
				Quest200 [i].QuestRequirement = BaseQuest.QuestType.ITEMGATHERING;
			}
			
			else if(i==4){
				Quest200 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
				Quest200 [i].QuestRequirement = BaseQuest.QuestType.ITEMGATHERING;
			}
			else if(i==7){
				Quest200 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
				Quest200 [i].QuestRequirement = BaseQuest.QuestType.ITEMGATHERING;
			}
			else if(i==11){
				Quest200 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
				Quest200 [i].QuestRequirement = BaseQuest.QuestType.ITEMGATHERING;
			}
			else if(i==16){
				Quest200 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
				Quest200 [i].QuestRequirement = BaseQuest.QuestType.ITEMGATHERING;
			}
			else if(i==17){
				Quest200 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
				Quest200 [i].QuestRequirement = BaseQuest.QuestType.ITEMGATHERING;
			}
			else{
				Quest200 [i].QuestCat = BaseQuest.QuestCategory.NONREPEATABLE;
				Quest200 [i].QuestRequirement = BaseQuest.QuestType.DEFEATENEMY;
			}
			
		}
		
		//Assigning QuestID
		
		
		Quest200 [0].QuestCode = BaseQuest.QuestID.Quest01;
		Quest200 [1].QuestCode = BaseQuest.QuestID.Quest02;
		Quest200 [2].QuestCode = BaseQuest.QuestID.Quest03;
		Quest200 [3].QuestCode = BaseQuest.QuestID.Quest04;
		Quest200 [4].QuestCode = BaseQuest.QuestID.Quest05;
		Quest200 [5].QuestCode = BaseQuest.QuestID.Quest06;
		Quest200 [6].QuestCode = BaseQuest.QuestID.Quest07;
		Quest200 [7].QuestCode = BaseQuest.QuestID.Quest08;
		Quest200 [8].QuestCode = BaseQuest.QuestID.Quest09;
		Quest200 [9].QuestCode = BaseQuest.QuestID.Quest10;
		Quest200 [10].QuestCode = BaseQuest.QuestID.Quest11;
		Quest200 [11].QuestCode = BaseQuest.QuestID.Quest12;
		Quest200 [12].QuestCode = BaseQuest.QuestID.Quest13;
		Quest200 [13].QuestCode = BaseQuest.QuestID.Quest14;
		Quest200 [14].QuestCode = BaseQuest.QuestID.Quest15;
		Quest200 [15].QuestCode = BaseQuest.QuestID.Quest16;
		Quest200 [16].QuestCode = BaseQuest.QuestID.Quest17;
		Quest200 [17].QuestCode = BaseQuest.QuestID.Quest18;
		Quest200 [18].QuestCode = BaseQuest.QuestID.Quest19;
		Quest200 [19].QuestCode = BaseQuest.QuestID.Quest20;
		Quest200 [20].QuestCode = BaseQuest.QuestID.Quest21;
		Quest200 [21].QuestCode = BaseQuest.QuestID.Quest22;
		
		//Quest Locking and Unlocking
		
		if (RelationshipLevel == 1) {
			Quest200 [0].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest200 [1].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
		}
		else if(RelationshipLevel == 2){
			Quest200 [0].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest200 [1].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest200 [2].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest200 [3].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
		}
		
		else if(RelationshipLevel == 3){
			Quest200 [2].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest200 [3].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest200 [4].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest200 [5].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest200 [6].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
		}
		
		
		else if(RelationshipLevel == 4){
			Quest200 [4].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest200 [5].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest200 [6].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest200 [7].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest200 [8].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest200 [9].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest200 [10].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			
		}
		
		else if(RelationshipLevel == 5){
			Quest200 [7].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest200 [8].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest200 [9].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest200 [10].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest200 [11].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest200 [12].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest200 [13].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest200 [14].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest200 [15].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
		}
		
		else if(RelationshipLevel == 6){
			Quest200 [11].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest200 [12].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest200 [13].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest200 [14].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest200 [15].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest200 [16].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest200 [17].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest200 [18].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest200 [19].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest200 [20].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest200 [21].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
		}
		
		//used to assign the data that will be displayed to the player
		
		Quest200 [0].QuestTitle = "Request for Plain Clothes";
		Quest200 [0].QuestDescription = "These days, it’s getting colder and colder, so I decided to make several new clothes for me and Master. Please gather 5x Plain Cloth. Thank you.";
		Quest200 [0].QuestCondition = "Hand 5x Plain Cloth to Xelvaria.";
		Quest200 [0].QuestReward = 200;
		Quest200 [0].QuestNumber = 201;
		
		Quest200 [1].QuestTitle = "Request to Defeat Slimes";
		Quest200 [1].QuestDescription = "I want to test your skill. Please defeat 6 slimes and the report the result to me. Thank you.";
		Quest200 [1].QuestCondition = "Report to Xelvaria after defeating 6 slimes.";
		Quest200 [1].QuestReward = 250;
		Quest200 [1].QuestNumber = 202;
		
		Quest200 [2].QuestTitle = "Request for Tiger Fur";
		Quest200 [2].QuestDescription = "The fur seems nice and war. Please gather 3x Tiger Fur for me. Thank you.";
		Quest200 [2].QuestCondition = ": Hand 3x Tiger Fur to Xelvaria.";
		Quest200 [2].QuestReward = 250;
		Quest200 [2].QuestNumber = 203;
		
		Quest200 [3].QuestTitle = "Request to Defeat Zombie";
		Quest200 [3].QuestDescription = "Next test is the extermination of the zombies. Please defeat 5 Zombie and report to me.";
		Quest200 [3].QuestCondition = "Report to Xelvaria after defeating 5 Zombie.";
		Quest200 [3].QuestReward = 300;
		Quest200 [3].QuestNumber = 204;
		
		Quest200 [4].QuestTitle = "Request for Decoration Materials";
		Quest200 [4].QuestDescription = "I want to create a unique decoration, so please gather 2x White Feather and 5x Broken Weapon. Thank you.";
		Quest200 [4].QuestCondition = "Hand 2x White Feather and 5x Broken Weapon to Xelvaria.";
		Quest200 [4].QuestReward = 350;
		Quest200 [4].QuestNumber = 205;
		
		Quest200 [5].QuestTitle = "Hunting Test";
		Quest200 [5].QuestDescription = "Let’s test your hunting capabilities. I want you to defeat 3 Ghost and 4 Zombie. Please report to me once you’re finished, thank you.";
		Quest200 [5].QuestCondition = "Report to Xelvaria after defeating 3 Ghost and 4 Zombie.";
		Quest200 [5].QuestReward = 400;
		Quest200 [5].QuestNumber = 206;
		
		Quest200 [6].QuestTitle = "Dangerous Beast";
		Quest200 [6].QuestDescription = "I heard there were strong beasts called Lightning Tiger. Can you defeat 3 Lightning Tiger and report to me? I want to see your progress in real battle. Thank you.";
		Quest200 [6].QuestCondition = "Report to Xelvaria after defeating 3 Lightning Tiger.";
		Quest200 [6].QuestReward = 450;
		Quest200 [6].QuestNumber = 207;
		
		Quest200 [7].QuestTitle = "Present for Master";
		Quest200 [7].QuestDescription = "I want give a unique present for my master. Can you gather 2x Ectoplasm and 1x Black Heart? I think those items will make a good present.";
		Quest200 [7].QuestCondition = "Hand 2x Ectoplasm and 1x Black Heart to Xelvaria.";
		Quest200 [7].QuestReward = 450;
		Quest200 [7].QuestNumber = 208;
		
		Quest200 [8].QuestTitle = "How Strong You Are";
		Quest200 [8].QuestDescription = "I want you to defeat 2 Mad Rider and 4 Ghost. They should provide quite a challenge for you. Please report to me once it’s completed.";
		Quest200 [8].QuestCondition = "Report to Xelvaria after defeating 2 Mad Rider and 4 Ghost.";
		Quest200 [8].QuestReward = 500;
		Quest200 [8].QuestNumber = 209;
		
		Quest200 [9].QuestTitle = "Raising the Bar";
		Quest200 [9].QuestDescription = "This time, the opponents are going to be quite a variation. Please defeat 2 Zombie Dragon, 3 Ghost and 5 Zombie.";
		Quest200 [9].QuestCondition = "Report to Xelvaria after defeating 2 Zombie Dragon, 3 Ghost and 5 Zombie.";
		Quest200 [9].QuestReward = 650;
		Quest200 [9].QuestNumber = 210;
		
		Quest200 [10].QuestTitle = "Real Power ";
		Quest200 [10].QuestDescription = "It’s time to gauge how powerful you have become. Please defeat 3 Angel and 2 Zombie Dragon. The quest is dangerous, but I promise that the reward’s going to worth it, I promise.";
		Quest200 [10].QuestCondition = "Report to Xelvaria after defeating 3 Angel and 2 Zombie Dragon.";
		Quest200 [10].QuestReward = 700;
		Quest200 [10].QuestNumber = 211;
		
		Quest200 [11].QuestTitle = "First Experiment";
		Quest200 [11].QuestDescription = "I want to try doing an experiment like what Master Igna always does. I think I need 2x Dragon Heart and 2x Lightning Gem. I hope you can gather them for me.";
		Quest200 [11].QuestCondition = "Hand 2x Dragon Heart and 2x Lightning Gem to Xelvaria.";
		Quest200 [11].QuestReward = 800;
		Quest200 [11].QuestNumber = 212;
		
		Quest200 [12].QuestTitle = "Test of Perseverance";
		Quest200 [12].QuestDescription = "This quest serves to test not only your strength, but perseverance. Please defeat 10 Zombie, 7 Slime, 5 Ghost and 2 Zombie Dragon.";
		Quest200 [12].QuestCondition = "Report to Xelvaria after defeating 10 Zombie, 7 Slime, 5 Ghost and 2 Zombie Dragon.";
		Quest200 [12].QuestReward = 850;
		Quest200 [12].QuestNumber = 213;
		
		Quest200 [13].QuestTitle = "Opposing Divine Force";
		Quest200 [13].QuestDescription = "This time, I want to you to defeat 5 Angel.  Please show me how good you can oppose the divine force.";
		Quest200 [13].QuestCondition = "Report to Xelvaria after defeating 5 Angel.";
		Quest200 [13].QuestReward = 950;
		Quest200 [13].QuestNumber = 214;
		
		Quest200 [14].QuestTitle = "Opposing Dark Force";
		Quest200 [14].QuestDescription = "The enemies come from the dark side. I want you to defeat 4 Dullahan. Show me how well you can fight against the force of darkness.";
		Quest200 [14].QuestCondition = "Report to Xelvaria after defeating 4 Dullahan.";
		Quest200 [14].QuestReward = 950;
		Quest200 [14].QuestNumber = 215;
		
		Quest200 [15].QuestTitle = "Way to Survive ";
		Quest200 [15].QuestDescription = "I want you to defeat 7 Mad Rider, 4 Zombie Dragon and 2 Angel. Please be careful.";
		Quest200 [15].QuestCondition = "Report to Xelvaria after defeating 7 Mad Rider, 4 Zombie Dragon and 2 Angel.";
		Quest200 [15].QuestReward = 950;
		Quest200 [15].QuestNumber = 216;
		
		Quest200 [16].QuestTitle = "Master’s Way";
		Quest200 [16].QuestDescription = "My master learns of me doing my own experiment. He advised me to try an unlikely combination. Can you please gather 3x Black Heart, 5x Ectoplasm and 2x Dragon Heart? I want to test imbuing the mix of two hearts with a new spirit core. ";
		Quest200 [16].QuestCondition = "Hand 3x Black Heart, 5x Ectoplasm and 2x Dragon Heart to Xelvaria.";
		Quest200 [16].QuestReward = 1200;
		Quest200 [16].QuestNumber = 217;
		
		Quest200 [17].QuestTitle = "Serum of Truth";
		Quest200 [17].QuestDescription = "I thought of an interesting combination for the new experiment. Please bring me 7x Blue Gel, 3x Liquid Poison, 5x Eye of Truth and 2x Colorful Ball. I need them to create a new type of serum, though I don’t know what the result might be.";
		Quest200 [17].QuestCondition = "Hand 7x Blue Gel, 3x Liquid Poison, 5x Eye of Truth and 2x Colorful Ball to Xelvaria.";
		Quest200 [17].QuestReward = 1000;
		Quest200 [17].QuestNumber = 218;
		
		Quest200 [18].QuestTitle = "Real Challenge";
		Quest200 [18].QuestDescription = "I want you to defeat 5 Cool Jack, 7 Dullahan and 10 Angel. This test is quite dangerous compared to the ones you’ve completed before, so please be careful.";
		Quest200 [18].QuestCondition = "Report to Xelvaria after defeating 5 Cool Jack, 7 Dullahan and 10 Angel.";
		Quest200 [18].QuestReward = 1000;
		Quest200 [18].QuestNumber =  219;
		
		Quest200 [19].QuestTitle = "Fire and Ice";
		Quest200 [19].QuestDescription = "Prove your strength by defeating 7 Scale of Ice and 7 Mad Jotun. Please be extra careful since they are quite strong.";
		Quest200 [19].QuestCondition = "Report to Xelvaria after defeating 7 Scale of Ice and 7 Mad Jotun.";
		Quest200 [19].QuestReward = 1200;
		Quest200 [19].QuestNumber = 220;
		
		Quest200 [20].QuestTitle = "Strong Adversaries";
		Quest200 [20].QuestDescription = "Please defeat 7 Cool Jack, 3 Scale of Ice and 5 Dullahan. They are top tier monsters, so please be careful.";
		Quest200 [20].QuestCondition = "Report to Xelvaria after defeating 7 Cool Jack, 3 Scale of Ice and 5 Dullahan.";
		Quest200 [20].QuestReward = 1200;
		Quest200 [20].QuestNumber = 221;
		
		Quest200 [21].QuestTitle = "The Last Test";
		Quest200 [21].QuestDescription = "This one will be quite difficult. I want you to defeat 3 Mad Jotun, 5 Cool Jack, 6 Scale of Ice and 2 Dullahan. Please keep up your good work up until now. I believe you can deliver satisfactory result.";
		Quest200 [21].QuestCondition = "Report to Xelvaria after defeating 3 Mad Jotun, 5 Cool Jack, 6 Scale of Ice and 2 Dullahan.";
		Quest200 [21].QuestReward = 1400;
		Quest200 [21].QuestNumber = 222;
	}

	public int QuestVerificator(){
		int j = 0;
		for (int i=0; i<22; i++) {
			if(Quest200[i].QuestStat == BaseQuest.QuestStatus.ONGOING){
				j = 1;
				break;
			}
		}
		return j;
	}
	
//	public int QuestCompletion(int x){
//		if (Quest200[x].QuestFlag == true) {
//			Quest200[x].QuestStat = BaseQuest.QuestStatus.COMPLETE;
//			RelationshipProgress(70);
//			return Quest200 [x].QuestReward;
//		}
//		else{
//			return 0;
//		}
//	}
}
