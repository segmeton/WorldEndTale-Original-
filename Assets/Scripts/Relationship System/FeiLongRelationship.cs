using UnityEngine;
using System.Collections;

public class FeiLongRelationship : BaseRelationship {
	public int QuestOpen;
	
	public BaseQuest[] Quest300  = new BaseQuest[22];

	
	public void QuestAssigner(){
		
	}
	
	public FeiLongRelationship(){
		RelationshipLevel = 0;
		RelationshipPoint = 0;
		PrefGiftID = "IT43";
		PrefGiftID2 = "IT44";
		Quest300 [0] = new BaseQuest ("EN01", 5, 1);
		Quest300 [1] = new BaseQuest ("EN02", 2, 1);
		Quest300 [2] = new BaseQuest ("EN01", "EN02", 6, 3, 2);
		Quest300 [3] = new BaseQuest ("EN03", 1, 1);
		Quest300 [4] = new BaseQuest ("EN01", "EN03", 4, 2, 2);
		Quest300 [5] = new BaseQuest ("EN04", 1, 1);
		Quest300 [6] = new BaseQuest ("EN02", "EN03", 6, 4, 2);
		Quest300 [7] = new BaseQuest ("EN05", 1, 1);
		Quest300 [8] = new BaseQuest ("EN03", "EN04", 4, 3, 2);
		Quest300 [9] = new BaseQuest ("EN01", "EN02", "EN03", 7, 5, 2, 3);
		Quest300 [10] = new BaseQuest ("EN03", "EN04", 5, 5, 2);
		Quest300 [11] = new BaseQuest ("EN06", 2, 1);
		Quest300 [12] = new BaseQuest ("EN03", "EN04", "EN05", 7, 5, 2, 3);
		Quest300 [13] = new BaseQuest ("EN07", 2, 1);
		Quest300 [14] = new BaseQuest ("EN01", "EN03", "EN04", "EN05", 5, 7, 5, 4, 4);
		Quest300 [15] = new BaseQuest ("EN10", 2, 1);
		Quest300 [16] = new BaseQuest ("EN09", 2, 1);
		Quest300 [17] = new BaseQuest ("EN08", 2, 1);
		Quest300 [18] = new BaseQuest ("EN11", 2, 1);
		Quest300 [19] = new BaseQuest ("EN08", "EN09", 5, 5, 2);
		Quest300 [20] = new BaseQuest ("EN08", "EN10", 5, 5, 2);
		Quest300 [21] = new BaseQuest ("EN08", "EN09", "EN10", "EN11", 4, 4, 4, 2, 4);
		
		
		for (int i =0; i<22; i++) {
			Quest300[i].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest300[i].QuestFlag = false;
			Quest300[i].QuestFlag = false;
			Quest300[i].QuestTakenFlag = false;
			Quest300 [i].QuestRequirement = BaseQuest.QuestType.DEFEATENEMY;
			if(i==0){
				Quest300 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
			}
			else if(i==2){
				Quest300 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
			}
			
			else if(i==4){
				Quest300 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
			}
			else if(i==7){
				Quest300 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
			}
			else if(i==11){
				Quest300 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
			}
			else if(i==16){
				Quest300 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
			}
			else if(i==17){
				Quest300 [i].QuestCat = BaseQuest.QuestCategory.REPEATABLE;
			}
			else{
				Quest300 [i].QuestCat = BaseQuest.QuestCategory.NONREPEATABLE;
			}
			
		}
		
		//Assigning QuestID
		
		
		Quest300 [0].QuestCode = BaseQuest.QuestID.Quest01;
		Quest300 [1].QuestCode = BaseQuest.QuestID.Quest02;
		Quest300 [2].QuestCode = BaseQuest.QuestID.Quest03;
		Quest300 [3].QuestCode = BaseQuest.QuestID.Quest04;
		Quest300 [4].QuestCode = BaseQuest.QuestID.Quest05;
		Quest300 [5].QuestCode = BaseQuest.QuestID.Quest06;
		Quest300 [6].QuestCode = BaseQuest.QuestID.Quest07;
		Quest300 [7].QuestCode = BaseQuest.QuestID.Quest08;
		Quest300 [8].QuestCode = BaseQuest.QuestID.Quest09;
		Quest300 [9].QuestCode = BaseQuest.QuestID.Quest10;
		Quest300 [10].QuestCode = BaseQuest.QuestID.Quest11;
		Quest300 [11].QuestCode = BaseQuest.QuestID.Quest12;
		Quest300 [12].QuestCode = BaseQuest.QuestID.Quest13;
		Quest300 [13].QuestCode = BaseQuest.QuestID.Quest14;
		Quest300 [14].QuestCode = BaseQuest.QuestID.Quest15;
		Quest300 [15].QuestCode = BaseQuest.QuestID.Quest16;
		Quest300 [16].QuestCode = BaseQuest.QuestID.Quest17;
		Quest300 [17].QuestCode = BaseQuest.QuestID.Quest18;
		Quest300 [18].QuestCode = BaseQuest.QuestID.Quest19;
		Quest300 [19].QuestCode = BaseQuest.QuestID.Quest20;
		Quest300 [20].QuestCode = BaseQuest.QuestID.Quest21;
		Quest300 [21].QuestCode = BaseQuest.QuestID.Quest22;
		
		//Quest Locking and Unlocking
		
		if (RelationshipLevel == 1) {
			Quest300 [0].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest300 [1].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
		}
		else if(RelationshipLevel == 2){
			Quest300 [0].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest300 [1].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest300 [2].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest300 [3].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
		}
		
		else if(RelationshipLevel == 3){
			Quest300 [2].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest300 [3].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest300 [4].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest300 [5].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest300 [6].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
		}
		
		
		else if(RelationshipLevel == 4){
			Quest300 [4].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest300 [5].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest300 [6].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest300 [7].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest300 [8].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest300 [9].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest300 [10].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			
		}
		
		else if(RelationshipLevel == 5){
			Quest300 [7].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest300 [8].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest300 [9].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest300 [10].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest300 [11].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest300 [12].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest300 [13].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest300 [14].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest300 [15].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
		}
		
		else if(RelationshipLevel == 6){
			Quest300 [11].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest300 [12].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest300 [13].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest300 [14].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest300 [15].QuestStat = BaseQuest.QuestStatus.LOCKED;
			Quest300 [16].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest300 [17].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest300 [18].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest300 [19].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest300 [20].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
			Quest300 [21].QuestStat = BaseQuest.QuestStatus.NOTTAKEN;
		}
		
		//used to assign the data that will be displayed to the player
		
		Quest300 [0].QuestTitle = "Show Me How Strong You Are";
		Quest300 [0].QuestDescription = "I want you to show me how powerful you are. Please defeat 5 Slime and then report to me.";
		Quest300 [0].QuestCondition = "Report to Fei Long after defeating 5 Slime.";
		Quest300 [0].QuestReward = 200;
		Quest300 [0].QuestNumber = 301;
		
		Quest300 [1].QuestTitle = "A Simple Test";
		Quest300 [1].QuestDescription = "This time, I want you to defeat 2 Zombies. They are not that strong, but be careful nevertheless.";
		Quest300 [1].QuestCondition = "Report to Fei Long after defeating 2 Zombies.";
		Quest300 [1].QuestReward = 250;
		Quest300 [1].QuestNumber = 302;
		
		Quest300 [2].QuestTitle = "Monster Extermination";
		Quest300 [2].QuestDescription = "Please defeat 3 Zombie and 6 Slime. It’s good to keep yourself in shape. ";
		Quest300 [2].QuestCondition = "Report to Fei Long after defeating defeat 3 Zombie and 6 Slime.";
		Quest300 [2].QuestReward = 200;
		Quest300 [2].QuestNumber = 303;
		
		Quest300 [3].QuestTitle = "Another Test";
		Quest300 [3].QuestDescription = "Just like before, I want you to defeat several monsters to prove your strength. Please defeat 1 Ghost.  It’s quite strong so be careful.";
		Quest300 [3].QuestCondition = "Report to Fei Long after defeating 1 Ghost.";
		Quest300 [3].QuestReward = 300;
		Quest300 [3].QuestNumber = 304;
		
		Quest300 [4].QuestTitle = "Practicing Your Skill";
		Quest300 [4].QuestDescription = "Please defeat 2 Ghost and 4 Slime. It will be a challenge for you.";
		Quest300 [4].QuestCondition = "Report to Fei Long after defeating defeat 2 Ghost and 4 Slime.";
		Quest300 [4].QuestReward = 350;
		Quest300 [4].QuestNumber = 305;
		
		Quest300 [5].QuestTitle = "Lightning Tiger";
		Quest300 [5].QuestDescription = "I heard rumors that there were a strong beast made of lightning. Please defeat 1 Lightning Tiger and report to me. From what I’ve heard, this beast is ferocious, so be on guard.";
		Quest300 [5].QuestCondition = "Report to Fei Long after defeating 1 Lightning Tiger.";
		Quest300 [5].QuestReward = 300;
		Quest300 [5].QuestNumber = 306;
		
		Quest300 [6].QuestTitle = "Hunting Time";
		Quest300 [6].QuestDescription = "Please defeat 4 Ghost and 6 Zombie. They are multiplying in quite a short time, so we need to decrease the number.";
		Quest300 [6].QuestCondition = "Report to Fei Long after defeating 4 Ghost and 6 Zombie.";
		Quest300 [6].QuestReward = 350;
		Quest300 [6].QuestNumber = 307;
		
		Quest300 [7].QuestTitle = "Figure of Myth";
		Quest300 [7].QuestDescription = "There’s a myth regarding a mad monster riding on a horse. Can you defeat 1 Mad Rider? If it’s as strong as the myth said, then it will be a good battle experience for you.";
		Quest300 [7].QuestCondition = "Report to Fei Long after defeating defeat 1 Mad Rider.";
		Quest300 [7].QuestReward = 400;
		Quest300 [7].QuestNumber = 308;
		
		Quest300 [8].QuestTitle = "A Tougher Challenge";
		Quest300 [8].QuestDescription = "Please defeat 3 Lightning Tiger and 4 Zombie. You have always done a good job in finishing my challenge up until now, so you’ll be fine.";
		Quest300 [8].QuestCondition = "Report to Fei Long after defeating 3 Lightning Tiger and 4 Zombie.";
		Quest300 [8].QuestReward = 400;
		Quest300 [8].QuestNumber = 309;
		
		Quest300 [9].QuestTitle = "Great Hunt";
		Quest300 [9].QuestDescription = "Please defeat 2 Ghost, 5 Zombie and 7 Slime. They might not be that strong, but be on guard or you might regret it.";
		Quest300 [9].QuestCondition = "Report to Fei Long after defeating 2 Ghost, 5 Zombie and 7 Slime.";
		Quest300 [9].QuestReward = 450;
		Quest300 [9].QuestNumber = 310;
		
		Quest300 [10].QuestTitle = "A Troublesome Combination";
		Quest300 [10].QuestDescription = "Please defeat 5 Lightning Tiger and 5 Ghost. Together, they should provide more than a challenge.";
		Quest300 [10].QuestCondition = "Report to Fei Long after defeating 5 Lightning Tiger and 5 Ghost.";
		Quest300 [10].QuestReward = 500;
		Quest300 [10].QuestNumber = 311;
		
		Quest300 [11].QuestTitle = "Rotten Beast";
		Quest300 [11].QuestDescription = "Please defeat 2 Zombie Dragon. Be careful, you might want to defeat them quickly because of their stench. Some people said their stench alone could kill.";
		Quest300 [11].QuestCondition = "Report to Fei Long after defeating defeat 2 Zombie Dragon.";
		Quest300 [11].QuestReward = 500;
		Quest300 [11].QuestNumber = 312;
		
		Quest300 [12].QuestTitle = "Challenge Again ";
		Quest300 [12].QuestDescription = "Please defeat 2 Mad Rider, 5 Lightning Tiger and 7 Ghost. Fighting enemies of different types will be a good way to gain more experience.";
		Quest300 [12].QuestCondition = "Report to Fei Long after defeating 2 Mad Rider, 5 Lightning Tiger and 7 Ghost.";
		Quest300 [12].QuestReward = 750;
		Quest300 [12].QuestNumber = 313;
		
		Quest300 [13].QuestTitle = "Fighting Greater Foes ";
		Quest300 [13].QuestDescription = "Please defeat 2 Angel and report the result to me. This type is kind of different from the other types of monster but please remain cautious.";
		Quest300 [13].QuestCondition = "Report to Fei Long after defeating 2 Angel.";
		Quest300 [13].QuestReward = 700;
		Quest300 [13].QuestNumber = 314;
		
		Quest300 [14].QuestTitle = "Wave of Enemies";
		Quest300 [14].QuestDescription = "Please defeat 5 Slime, 5 Lightning Tiger, 7 Ghost and 4 Mad Rider. Remember what you’ve learnt so far and you will be able to complete this task.";
		Quest300 [14].QuestCondition = "Report to Fei Long after defeating 5 Slime, 5 Lightning Tiger, 7 Ghost and 4 Mad Rider.";
		Quest300 [14].QuestReward = 800;
		Quest300 [14].QuestNumber = 315;
		
		Quest300 [15].QuestTitle = "Icy Cold";
		Quest300 [15].QuestDescription = "Please defeat 2 Scale of Ice. Remember to watch out for their water based attacks.";
		Quest300 [15].QuestCondition = "Report to Fei Long after defeating 2 Scale of Ice.";
		Quest300 [15].QuestReward = 700;
		Quest300 [15].QuestNumber = 316;
		
		Quest300 [16].QuestTitle = "New Enemy";
		Quest300 [16].QuestDescription = "Please defeat 2 Cool Jack. They may not look dangerous, but don’t be fooled.";
		Quest300 [16].QuestCondition = "Report to Fei Long after defeating defeat 2 Cool Jack.";
		Quest300 [16].QuestReward = 700;
		Quest300 [16].QuestNumber = 317;
		
		Quest300 [17].QuestTitle = "Headless Monster";
		Quest300 [17].QuestDescription = "Please defeat 2 Dullahan. They are quite famous, so please don’t underestimate the danger.";
		Quest300 [17].QuestCondition = "Report to Fei Long after defeating defeat 2 Dullahan.";
		Quest300 [17].QuestReward = 700;
		Quest300 [17].QuestNumber = 318;
		
		Quest300 [18].QuestTitle = "Gigantic Foe ";
		Quest300 [18].QuestDescription = "Please defeat 2 Mad Jotun. I heard they are quite dangerous, so please stay on alert.";
		Quest300 [18].QuestCondition = "Report to Fei Long after defeating 2 Mad Jotun.";
		Quest300 [18].QuestReward = 850;
		Quest300 [18].QuestNumber = 319;
		
		Quest300 [19].QuestTitle = "Dangerous Combination";
		Quest300 [19].QuestDescription = "Please defeat 5 Dullahan and 5 Cool Jack. It might be quite a challenge but you will be able to complete it.";
		Quest300 [19].QuestCondition = "Report to Fei Long after defeating 5 Dullahan and 5 Cool Jack.";
		Quest300 [19].QuestReward = 1000;
		Quest300 [19].QuestNumber = 320;
		
		Quest300 [20].QuestTitle = "Another Dangerous Combination";
		Quest300 [20].QuestDescription = "Please defeat 5 Scale of Ice and 5 Dullahan. You will be okay if you give it your best shot.";
		Quest300 [20].QuestCondition = "Report to Fei Long after defeating 5 Scale of Ice and 5 Dullahan.";
		Quest300 [20].QuestReward = 1000;
		Quest300 [20].QuestNumber = 321;
		
		Quest300 [21].QuestTitle = "Last Challenge";
		Quest300 [21].QuestDescription = "This time will be quite difficult. Please defeat 2 Mad Jotun, 4 Scale of Ice, 4 Dullahan and 4 Cool Jack. I believe you can overcome this trial.";
		Quest300 [21].QuestCondition = "Report to Fei Long after defeating 2 Mad Jotun, 4 Scale of Ice, 4 Dullahan and 4 Cool Jack.";
		Quest300 [21].QuestReward = 1500;
		Quest300 [21].QuestNumber = 322;
	}
	
	

	
}
