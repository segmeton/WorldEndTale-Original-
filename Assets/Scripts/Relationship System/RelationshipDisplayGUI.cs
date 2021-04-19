using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RelationshipDisplayGUI : MonoBehaviour {
	public Texture cecilSprite;
	public Texture limcaSprite;
	public Texture galardSprite;
	public Texture ignaSprite;
	public Texture xelvariaSprite;
	public Texture feilongSprite;
	public static int previousLevel;
	public static IgnaRelationship IR;
	public static XelvariaRelationship XLR;
	public static FeiLongRelationship FLR;
	public static int IgnaQuestIndex;
	public static int XelvariaQuestIndex;
	public static int FeiLongQuestIndex;
	public static bool isInventoryCheckedOnce;
	public static bool isIgnaRelationshipCheckedOnce;
	public static bool isXelvariaRelationshipCheckedOnce;
	public static bool isFeiLongRelationshipCheckedOnce;
	public static bool isQuestCompleted;
	public static bool isRewardGiven;
	private List<Item> miscList;
	//Item itemTest = new Item();
	private Item itemTest;
	int own1 = 10;
	int own2 = 7;
	// Use this for initialization
	void Start () {
		miscList = GameInformation.miscInventory;

		Debug.Log ("Start of story");
		Dialoguer.events.onStarted += onStarted;
		Dialoguer.events.onTextPhase += onTextPhase;
		Dialoguer.events.onEnded += onEnded;

		if (isIgnaRelationshipCheckedOnce == false && isXelvariaRelationshipCheckedOnce == false && isFeiLongRelationshipCheckedOnce == false) {
			IR = new IgnaRelationship();
			XLR = new XelvariaRelationship();
			FLR = new FeiLongRelationship();
		}
//		int c1 = 0;
//		string word1 = "IT";
//		string word2 = "";
//		int numb = 14;
//		int numb2 = 0;
//		//		word2 = numb.ToString ();
//		//		word2 = word1+word2;
//		//		numb = numb + 7;
//		//		Debug.Log (word2);
//		//		Debug.Log (numb);
//		if (repeat == 0) {
//			for (c1 = 0; c1< 25; c1++) {
//				numb2 = numb + c1;
//				word2 = numb2.ToString ();
//				word2 = word1 + word2;
//				itemTest.ID = word2;
//				itemTest.Amount = 10;
//				miscList.Add (itemTest);
//				//miscList[0].ID = word2;
//				//				Debug.Log(miscList[c1].ID);
//				//				Debug.Log(miscList[c1].Amount);
//			}
//			repeat = 1;
//		}

		int c1 = 0;
		string word1 = "IT";
		string word2 = "";
		int number = 14;
		int number2 = 0;
		for (c1 = 0; c1 < 25; c1++) {
			number2 = number + c1;
			word2 = number2.ToString();
			word2 = word1 + word2;
			itemTest = new Item(word2);
			itemTest.Amount = 10;
			miscList.Add(itemTest);
		}

		for (int count= 0; count < miscList.Count; count++) {
			Debug.Log("ID: " + miscList[count].ID);
			Debug.Log("Amount: " + miscList[count].Amount);
		}


	}

	private bool _showing;
	private string _text;
	private bool showButton = true;
	
	private string _charaname;
	private bool endScene;
	
	void Awake(){
		Dialoguer.Initialize ();
		
	}

	public enum State
	{
		Main,
		Igna,
		Xelvaria,
		FeiLong,
		
		IgnaQuest,
		XelvariaQuest,
		FeiLongQuest,
		
		IgnaQuestDisplay,
		XelvariaQuestDisplay,
		FeiLongQuestDisplay,
		
		IgnaQuestOption,
		XelvariaQuestOption,
		FeiLongQuestOption,
		
		IgnaQuestReport,
		XelvariaQuestReport,
		FeiLongQuestReport,
		
		QuestConfirmationIgna,
		QuestConfirmationXelvaria,
		QuestConfirmationFeiLong,
		
		IgnaGift,
		XelvariaGift,
		FeiLongGift,
		
		EventIgna,
		EventXelvaria,
		EventFeiLong,

		IgnaGiftResponse,
		XelvariaGiftResponse,
		FeiLongGiftResponse
	}

	// Update is called once per frame
	public int x;
	public int y;
	public int Nposition;
	public int Dposition;
	public int Sposition;
	public int Nposition2;
	public int Dposition2;
	public int Sposition2;
	public State currentstate = State.Main;
	public float barDisplay; //current progress
	public Vector2 pos = new Vector2(20,40);
	public Vector2 size = new Vector2(300,50);
	public Texture2D emptyTex;
	public Texture2D fullTex;
	public int number = 11;
	public string target = "EN01";
	public int number2 = 0;
	public string target2 = "EN02";
	public int number3 = 0;
	public string target3 = "EN03";
	public int number4 = 0;
	public string target4 = "EN04";
	public int gold;
	public int marker;
	public GUIStyle style;
	public int validate;
	public int index1;
	public int index2;
	public int index3;
	public int index4;
	private List<Dictionary<string, string>> itemDrop = new List<Dictionary<string, string>>();
	public static List<Item> miscDrop = new List<Item>();
	public int repeat = 0;
	public int repeat2 = 0;

	void OnGUI() {

		Texture charaTexture = new Texture();
		Texture charaTexture2 = new Texture();


		//OnGUI function
		GUI.skin.button.alignment = TextAnchor.MiddleCenter;
		int reward = 0;
		isRewardGiven = false;
		GameInformation.isTavernAccessed = true;
		GUI.skin.button.fontSize = 12;
		GUI.skin.box.fontSize = 12;

		if (currentstate == State.Main) {
			GUI.skin.box.alignment = TextAnchor.MiddleCenter;
			//Default state
			int standardWidth = Screen.width / 2;
			int standardHeight = Screen.height / 2;
			int positionHeight = standardHeight - 160;
			int positionWidth = standardWidth - 135;
			int positionWidth2 = standardWidth - 85;
			GUI.Box (new Rect (positionWidth, positionHeight, 270, 40), "Choose the people you want to meet.");

			if (GUI.Button (new Rect (positionWidth2, positionHeight + 70, 170, 40), "Talk with Igna.")) {
				if (isIgnaRelationshipCheckedOnce == false) {
					isIgnaRelationshipCheckedOnce = true;
				}
				currentstate = State.IgnaGift;
			}

			if (GUI.Button (new Rect (positionWidth2, positionHeight + 140, 170, 40), "Talk with Xelvaria")) {
				if (isIgnaRelationshipCheckedOnce == false) {
					isXelvariaRelationshipCheckedOnce = true;
				}

				currentstate = State.Xelvaria;

				//currentstate = State.EventXelvaria;
			}

			if (GUI.Button (new Rect (positionWidth2, positionHeight+210, 170, 40), "Talk with Fei Long")) {
				if(isIgnaRelationshipCheckedOnce == false){
					isFeiLongRelationshipCheckedOnce = true;
				}
				currentstate = State.FeiLong;
			}

			if (GUI.Button (new Rect (positionWidth2, positionHeight + 280, 170, 40), "Quit Tavern.")) {
				Application.LoadLevel ("Town");
			}
		} else if (currentstate == State.Igna) {
			//Igna state. Has to go through this before taking or reporting quest or giving a gift to Igna.
			int standardWidth = Screen.width / 2;
			int standardHeight = Screen.height / 2;
			int positionHeight = standardHeight - 160;
			int positionWidth = standardWidth - 135;
			int positionWidth2 = standardWidth - 85;
			GUI.Box (new Rect (positionWidth, positionHeight, 270, 40), "What do you want to do.");
			GUILayout.Space (50);
			if (GUI.Button (new Rect (positionWidth2, positionHeight + 70, 170, 40), "Give Igna a gift.")) {
				currentstate = State.IgnaGift;
			}
			if (GUI.Button (new Rect (positionWidth2, positionHeight + 140, 170, 40), "Take or report a quest.")) {
				currentstate = State.IgnaQuestOption;
			}
			if (GUI.Button (new Rect (positionWidth2, positionHeight + 210, 170, 40), "Cancel.")) {
				currentstate = State.Main;
			}
		} else if (currentstate == State.Xelvaria) {
			//Xelvaria state. Has to go through this before taking or reporting quest or giving a gift to Xelvaria.
			int standardWidth = Screen.width / 2;
			int standardHeight = Screen.height / 2;
			int positionHeight = standardHeight - 160;
			int positionWidth = standardWidth - 135;
			int positionWidth2 = standardWidth - 85;
			GUI.Box (new Rect (positionWidth, positionHeight, 270, 40), "What do you want to do.");
			if (GUI.Button (new Rect (positionWidth2, positionHeight + 70, 170, 40), "Give Xelvaria a gift.")) {
				currentstate = State.XelvariaGift;
			}
			if (GUI.Button (new Rect (positionWidth2, positionHeight + 140, 170, 40), "Take or report a quest.")) {
				currentstate = State.XelvariaQuestOption;
			}
			if (GUI.Button (new Rect (positionWidth2, positionHeight + 210, 170, 40), "Cancel.")) {
				currentstate = State.Main;
			}
		
		} else if (currentstate == State.FeiLong) {
			//Fei Long state. Has to go through this before taking or reporting quest or giving a gift to Fei Long.
			int standardWidth = Screen.width / 2;
			int standardHeight = Screen.height / 2;
			int positionHeight = standardHeight - 160;
			int positionWidth = standardWidth - 135;
			int positionWidth2 = standardWidth - 85;
			FLR.RelationshipLevel = 6;
			GUI.Box (new Rect (positionWidth, positionHeight, 270, 40), "What do you want to do.");
			if (GUI.Button (new Rect (positionWidth2, positionHeight + 70, 170, 40), "Give Fei Long a gift.")) {
				currentstate = State.FeiLongGift;
			}
			if (GUI.Button (new Rect (positionWidth2, positionHeight + 140, 170, 40), "Take or report a quest.")) {
				currentstate = State.FeiLongQuestOption;
			}
			if (GUI.Button (new Rect (positionWidth2, positionHeight + 210, 170, 40), "Cancel.")) {
				currentstate = State.Main;
			}
		
		} else if (currentstate == State.IgnaQuestOption) {
			//Entering Igna quest option. It's here that you can take or report quest.
			int standardWidth = Screen.width / 2;
			int standardHeight = Screen.height / 2;
			int positionHeight = standardHeight - 160;
			int positionWidth = standardWidth - 135;
			int positionWidth2 = standardWidth - 85;
			GUI.Box (new Rect (positionWidth, positionHeight, 270, 40), "Do you want to report or take the quest?");

			if (GUI.Button (new Rect (positionWidth2, positionHeight + 70, 170, 40), "Report a quest completion.")) {
				currentstate = State.IgnaQuestReport;
			}
			if (GUI.Button (new Rect (positionWidth2, positionHeight + 140, 170, 40), "Take a quest.")) {
				currentstate = State.IgnaQuest;
			}
			if (GUI.Button (new Rect (positionWidth2, positionHeight + 210, 170, 40), "Cancel.")) {
				currentstate = State.Igna;
			}
		
		} else if (currentstate == State.XelvariaQuestOption) {
			int standardWidth = Screen.width / 2;
			int standardHeight = Screen.height / 2;
			int positionHeight = standardHeight - 160;
			int positionWidth = standardWidth - 135;
			int positionWidth2 = standardWidth - 85;
			GUI.Box (new Rect (positionWidth, positionHeight, 270, 40), "Do you want to report or take the quest?");
			if (GUI.Button (new Rect (positionWidth2, positionHeight + 70, 170, 40), "Report a quest completion.")) {
				currentstate = State.XelvariaQuestReport;
			}
			if (GUI.Button (new Rect (positionWidth2, positionHeight + 140, 170, 40), "Take a quest.")) {
				currentstate = State.XelvariaQuest;
			}
			if (GUI.Button (new Rect (positionWidth2, positionHeight + 210, 170, 40), "Cancel.")) {
				currentstate = State.Xelvaria;
			}
		
		} else if (currentstate == State.FeiLongQuestOption) {
			int standardWidth = Screen.width / 2;
			int standardHeight = Screen.height / 2;
			int positionHeight = standardHeight - 160;
			int positionWidth = standardWidth - 135;
			int positionWidth2 = standardWidth - 85;
			GUI.Box (new Rect (positionWidth, positionHeight, 270, 40), "Do you want to report or take the quest?");
			if (GUI.Button (new Rect (positionWidth2, positionHeight + 70, 170, 40), "Report a quest completion.")) {
				currentstate = State.FeiLongQuestReport;
			}
			if (GUI.Button (new Rect (positionWidth2, positionHeight + 140, 170, 40), "Take a quest.")) {
				currentstate = State.FeiLongQuest;
			} 
			if (GUI.Button (new Rect (positionWidth2, positionHeight + 210, 170, 40), "Cancel.")) {
				currentstate = State.FeiLong;
			}
		
		} else if (currentstate == State.IgnaQuest) {
			IR.RelationshipLevel = 3;
			int i = 0;
			int i2 = 0;
			int i3 = 0;
			int standardHeight = Screen.height / 2;
			int positionHeight = standardHeight - 170;
			int standardWidth = Screen.width / 2;
			int positionWidth = standardWidth - 135;
			int positionWidth2 = standardWidth - 120;
			GUI.Box (new Rect (positionWidth, positionHeight, 270, 40), "Select one of the quest you want to do.");
			GUILayout.Space (50);
			//The functions below is the if functions to set the index & placement of the quests(their height positions). i is the basis of the index & position.
			// Also used for checking which quest(using i as the basis for quest index) to be displayed based on relationship level.
			if (IR.RelationshipLevel == 1) {
				i = 0;
				i3 = i;
				i2 = 2;
			} else if (IR.RelationshipLevel == 2) {
				i = 2;
				i3 = i;
				i2 = 4;
			} else if (IR.RelationshipLevel == 3) {
				i = 4;
				i3 = i;
				i2 = 7;
			} else if (IR.RelationshipLevel == 4) {
				i = 7;
				i3 = i;
				i2 = 11;
			} else if (IR.RelationshipLevel == 5) {
				i = 11;
				i3 = i;
				i2 = 16;
			} else if (IR.RelationshipLevel == 6) {
				i = 16;
				i3 = i;
				i2 = 22;
			}

			for (int i4 = i; i4 <i2; i4++) {
				//Displaying the quest using i4 as the index
				if (i4 == i3) {
					Sposition = i4;
					if (GUI.Button (new Rect (positionWidth2, positionHeight + 50, 240, 35), "Quest - " + IR.Quest100 [i4].QuestNumber + "\nQuest Type: " + IR.Quest100 [i4].QuestCat)) {
						IgnaQuestIndex = i4;
						//checking whether the quest is ongoing or not or if another quest is taken from this character
						for (int n=0; n<22; n++) {
							if (n < 21) {
								if (IR.Quest100 [n].QuestChecker () == 0) {
									validate = 0;
									break;	
								}
							} else if (n == 21) {
								if (IR.Quest100 [n].QuestChecker () == 0) {
									validate = 0;
									break;	
								} else if (IR.Quest100 [n].QuestChecker () == 1) {
									validate = IR.Quest100 [IgnaQuestIndex].QuestChecker ();
									break;	
								}
							}
						}
						currentstate = State.QuestConfirmationIgna;
					}
				} else if (i4 != i3) {
					Dposition = i4 - Sposition;
					Nposition = Dposition * 50;
					if (GUI.Button (new Rect (positionWidth2, positionHeight + Nposition + 50, 240, 35), "Quest - " + IR.Quest100 [i4].QuestNumber + "\nQuest Type: " + IR.Quest100 [i4].QuestCat)) {
							IgnaQuestIndex = i4;
							//checking whether the quest is ongoing or not or if another quest is taken from this character
							for (int n=0; n<22; n++) {
							if (n < 21) {
								if (IR.Quest100 [n].QuestChecker () == 0) {
									validate = 0;
									break;	
								}
							} else if (n == 21) {
								if (IR.Quest100 [n].QuestChecker () == 0) {
									validate = 0;
									break;	
								} else if (IR.Quest100 [n].QuestChecker () == 1) {
										validate = IR.Quest100 [IgnaQuestIndex].QuestChecker ();
										break;	
								}
							}
						}
						currentstate = State.QuestConfirmationIgna;
					}
				}
			}
		} else if (currentstate == State.XelvariaQuest) {
			XLR.RelationshipLevel = 2;
			int i = 0;
			int i2 = 0;
			int i3 = 0;
			int standardHeight = Screen.height / 2;
			int positionHeight = standardHeight - 170;
			int standardWidth = Screen.width / 2;
			int positionWidth = standardWidth - 135;
			int positionWidth2 = standardWidth - 120;
			//Width/2 - widthbox/2
			GUI.Box (new Rect (positionWidth, positionHeight, 270, 40), "Select one of the quest you want to do.");
			GUILayout.Space (50);
			//The functions below is the if functions to set the index & placement of the quests(their height positions). i is the basis of the index & position.
			// Also used for checking which quest(using i as the basis for quest index) to be displayed based on relationship level.
			if (XLR.RelationshipLevel == 1) {
				i = 0;
				i3 = i;
				i2 = 2;
			} else if (XLR.RelationshipLevel == 2) {
				i = 2;
				i3 = i;
				i2 = 4;
			} else if (XLR.RelationshipLevel == 3) {
				i = 4;
				i3 = i;
				i2 = 7;
			} else if (XLR.RelationshipLevel == 4) {
				i = 7;
				i3 = i;
				i2 = 11;
			} else if (XLR.RelationshipLevel == 5) {
				i = 11;
				i3 = i;
				i2 = 16;
			} else if (XLR.RelationshipLevel == 6) {
				i = 16;
				i3 = i;
				i2 = 22;
			}
			for (int i4 = i; i4 <i2; i4++) {
				//Displaying the quest using i4 as the index
				if (i4 == i3) {
					Sposition = i4;
					if (GUI.Button (new Rect (positionWidth2, positionHeight + 50, 240, 35), "Quest - " + XLR.Quest200 [i4].QuestNumber + "\nQuest Type: " + XLR.Quest200 [i4].QuestCat)) {
						XelvariaQuestIndex = i4;
						//checking whether the quest is ongoing or not or if another quest is taken from this character
						for (int n=0; n<22; n++) {
							if (n < 21) {
								if (XLR.Quest200 [n].QuestChecker () == 0) {
									validate = 0;
									break;	
								}
							} else if (n == 21) {
								if (XLR.Quest200 [n].QuestChecker () == 0) {
									validate = 0;
									break;	
								} else if (XLR.Quest200 [n].QuestChecker () == 1) {
									validate = XLR.Quest200 [XelvariaQuestIndex].QuestChecker ();
									break;
								}
							}
						}
						currentstate = State.QuestConfirmationXelvaria;
					}
				} else if (i4 != i3) {
					Dposition = i4 - Sposition;
					Nposition = Dposition * 50;
					if (GUI.Button (new Rect (positionWidth2, positionHeight + Nposition + 50, 240, 35), "Quest - " + XLR.Quest200 [i4].QuestNumber + "\nQuest Type: " + XLR.Quest200 [i4].QuestCat)) {
						XelvariaQuestIndex = i4;
						//checking whether the quest is ongoing or not or if another quest is taken from this character
						for (int n=0; n<22; n++) {
							if (n < 21) {
								if (XLR.Quest200 [n].QuestChecker () == 0) {
									validate = 0;
									break;
								}
							} else if (n == 21) {
								if (XLR.Quest200 [n].QuestChecker () == 0) {
									validate = 0;
									break;
								} else if (XLR.Quest200 [n].QuestChecker () == 1) {
									validate = XLR.Quest200 [XelvariaQuestIndex].QuestChecker ();
									break;
								}
							}
						}
						currentstate = State.QuestConfirmationXelvaria;
					}
				}
			}
		} else if (currentstate == State.FeiLongQuest) {
			FLR.RelationshipLevel = 6;
			int i = 0;
			int i2 = 0;
			int i3 = 0;
			int standardHeight = Screen.height / 2;
			int positionHeight = standardHeight - 170;
			int standardWidth = Screen.width / 2;
			int positionWidth = standardWidth - 135;
			int positionWidth2 = standardWidth - 120;
			GUI.Box (new Rect (positionWidth, positionHeight, 270, 40), "Select one of the quest you want to do.");
			GUILayout.Space (50);
			//The functions below is the if functions to set the index & placement of the quests(their height positions). i is the basis of the index & position.
			// Also used for checking which quest(using i as the basis for quest index) to be displayed based on relationship level.
			if (FLR.RelationshipLevel == 1) {
				i = 0;
				i3 = i;
				i2 = 2;
			} else if (FLR.RelationshipLevel == 2) {
				i = 2;
				i3 = i;
				i2 = 4;
			} else if (FLR.RelationshipLevel == 3) {
				i = 4;
				i3 = i;
				i2 = 7;
			} else if (FLR.RelationshipLevel == 4) {
				i = 7;
				i3 = i;
				i2 = 11;
			} else if (FLR.RelationshipLevel == 5) {
				i = 11;
				i3 = i;
				i2 = 16;
			} else if (FLR.RelationshipLevel == 6) {
				i = 16;
				i3 = i;
				i2 = 22;
			}
			for (int i4 = i; i4 <i2; i4++) {
				//Displaying the quest using i4 as the index
				if (i4 == i3) {
					Sposition = i4;
					if (GUI.Button (new Rect (positionWidth2, positionHeight + 50, 240, 40), "Quest - " + FLR.Quest300 [i4].QuestNumber + "\nQuest Type: " + FLR.Quest300 [i4].QuestCat)) {
						FeiLongQuestIndex = i4;
						//checking whether the quest is ongoing or not
						for (int n=0; n<22; n++) {
							if (n < 21) {
								if (FLR.Quest300 [n].QuestChecker () == 0) {
										validate = 0;
										break;
								}
							} else if (n == 21) {
								if (FLR.Quest300 [n].QuestChecker () == 0) {
									validate = 0;
									break;	
								} else if (FLR.Quest300 [n].QuestChecker () == 1) {
									validate = FLR.Quest300 [FeiLongQuestIndex].QuestChecker ();
									break;	
								}
							}
	
						}
						currentstate = State.QuestConfirmationFeiLong;
					}
				} else if (i4 != i3) {
					Dposition = i4 - Sposition;
					Nposition = Dposition * 50;
					if (GUI.Button (new Rect (positionWidth2, positionHeight + Nposition + 50, 240, 40), "Quest - " + FLR.Quest300 [i4].QuestNumber + "\nQuest Type: " + FLR.Quest300 [i4].QuestCat)) {
						FeiLongQuestIndex = i4;
						//checking whether the quest is ongoing or not or if another quest is taken from this character
						for (int n=0; n<22; n++) {
							if (n < 21) {
								if (FLR.Quest300 [n].QuestChecker () == 0) {
									validate = 0;
									break;	
								}
							} else if (n == 21) {
								if (FLR.Quest300 [n].QuestChecker () == 0) {
									validate = 0;
									break;	
								} else if (FLR.Quest300 [n].QuestChecker () == 1) {
									validate = FLR.Quest300 [FeiLongQuestIndex].QuestChecker ();
									break;	
								}
							}
						}
						currentstate = State.QuestConfirmationFeiLong;
					}
				}
			}
		} else if (currentstate == State.QuestConfirmationIgna) {
			if (validate == 1) {
				//If the validate is 1 you can take the quest.
				int standardHeight = Screen.height / 2;
				int positionHeight = standardHeight - 170;
				int standardWidth = Screen.width / 2;
				int positionWidth = standardWidth - 135;
				int positionWidth2 = standardWidth - 150;
				GUI.Box (new Rect (positionWidth, positionHeight, 270, 40), IR.Quest100 [IgnaQuestIndex].QuestTitle);
				GUI.skin.box.wordWrap = true;
				GUI.Box (new Rect (positionWidth2, positionHeight + 50, 300, 200), IR.Quest100 [IgnaQuestIndex].QuestDescription);
//				Debug.Log(IgnaQuestIndex);
				if (GUI.Button (new Rect (positionWidth2, positionHeight + 260, 120, 50), "Take this quest.")) {
					IR.Quest100 [IgnaQuestIndex].QuestTakenFlag = true;
					IR.Quest100 [IgnaQuestIndex].QuestStat = BaseQuest.QuestStatus.ONGOING;
					currentstate = State.Igna;
				}
				if (GUI.Button (new Rect (positionWidth2 + 180, positionHeight + 260, 120, 50), "Cancel.")) {
					currentstate = State.Igna;
				}
			} else if (validate == 0) {
				//If the validate is 0(means the quest has already been taken or you have taken another quest from the same character),
				//a warning is shown, and you can't take the quest until you clear the current one
				int standardWidth = Screen.width / 2;
				int standardHeight = Screen.height / 2;
				int positionWidth2 = standardWidth - 150;
				int positionWidth3 = standardWidth - 60;
				int positionHeight = standardHeight - 170;
				GUI.skin.box.wordWrap = true;
				GUI.skin.box.alignment = TextAnchor.MiddleCenter;
				GUI.Box (new Rect (positionWidth2, positionHeight + 50, 300, 200), "Please complete the quest you are currently taking first.");
				if (GUI.Button (new Rect (positionWidth3, positionHeight + 280, 120, 50), "Go back.")) {
					currentstate = State.Igna;
				}
			}
		} else if (currentstate == State.QuestConfirmationXelvaria) {
			if (validate == 1) {
				int standardHeight = Screen.height / 2;
				int positionHeight = standardHeight - 170;
				int standardWidth = Screen.width / 2;
				int positionWidth = standardWidth - 135;
				int positionWidth2 = standardWidth - 150;
				GUI.Box (new Rect (positionWidth, positionHeight, 270, 40), XLR.Quest200 [XelvariaQuestIndex].QuestTitle);
				GUI.skin.box.wordWrap = true;
				GUI.Box (new Rect (positionWidth2, positionHeight + 50, 300, 200), XLR.Quest200 [XelvariaQuestIndex].QuestDescription);
				if (GUI.Button (new Rect (positionWidth2, positionHeight + 260, 120, 50), "Take this quest.")) {
					XLR.Quest200 [XelvariaQuestIndex].QuestTakenFlag = true;
					XLR.Quest200 [XelvariaQuestIndex].QuestStat = BaseQuest.QuestStatus.ONGOING;
					currentstate = State.Xelvaria;
				}
				if (GUI.Button (new Rect (positionWidth2 + 180, positionHeight + 260, 120, 50), "Cancel.")) {
					currentstate = State.Xelvaria;
				}
			} else if (validate == 0) {
				int standardWidth = Screen.width / 2;
				int standardHeight = Screen.height / 2;
				int positionWidth2 = standardWidth - 150;
				int positionWidth3 = standardWidth - 60;
				int positionHeight = standardHeight - 170;
				GUI.skin.box.wordWrap = true;
				GUI.skin.box.alignment = TextAnchor.MiddleCenter;
				GUI.Box (new Rect (positionWidth2, positionHeight + 50, 300, 200), "Please complete the quest you are currently taking first.");
				if (GUI.Button (new Rect (positionWidth3, positionHeight + 280, 120, 50), "Go back.")) {
						currentstate = State.Xelvaria;
				}
			}
		} else if (currentstate == State.QuestConfirmationFeiLong) {
			if (validate == 1) {
				int standardHeight = Screen.height / 2;
				int positionHeight = standardHeight - 170;
				int standardWidth = Screen.width / 2;
				int positionWidth = standardWidth - 135;
				int positionWidth2 = standardWidth - 150;
				GUI.Box (new Rect (positionWidth, positionHeight, 270, 40), FLR.Quest300 [FeiLongQuestIndex].QuestTitle);
				GUI.skin.box.wordWrap = true;
				GUI.Box (new Rect (positionWidth2, positionHeight + 50, 300, 200), FLR.Quest300 [FeiLongQuestIndex].QuestDescription);
				if (GUI.Button (new Rect (positionWidth2, positionHeight + 260, 120, 50), "Take this quest.")) {
					FLR.Quest300 [FeiLongQuestIndex].QuestTakenFlag = true;
					FLR.Quest300 [FeiLongQuestIndex].QuestStat = BaseQuest.QuestStatus.ONGOING;
					currentstate = State.FeiLong;
				}
				if (GUI.Button (new Rect (positionWidth2 + 180, positionHeight + 260, 120, 50), "Cancel.")) {
					currentstate = State.FeiLong;
				}
			} else if (validate == 0) {
				int standardWidth = Screen.width / 2;
				int standardHeight = Screen.height / 2;
				int positionWidth2 = standardWidth - 150;
				int positionWidth3 = standardWidth - 60;
				int positionHeight = standardHeight - 170;
				GUI.skin.box.wordWrap = true;
				GUI.skin.box.alignment = TextAnchor.MiddleCenter;
				GUI.Box (new Rect (positionWidth2, positionHeight + 50, 300, 200), "Please complete the quest you are currently taking first.");
				if (GUI.Button (new Rect (positionWidth3, positionHeight + 280, 120, 50), "Go back.")) {
					currentstate = State.FeiLong;
				}
			}
		} else if (currentstate == State.IgnaQuestReport) {
			isQuestCompleted = false;
			for (int i = 0; i< 22; i++) {
				//Check the number of target for the quest
				int z = IR.Quest100 [i].QuestChecker ();
				if (z == 1) {
					//Target is one item/enemy
					x = i;
					z = 0;
					y = IR.Quest100 [x].QuestProcessing ();
					if (y == 1) {
						for (int a = 0; a < GameInformation.miscInventory.Count; a++) {
							//checking the quest's completion and giving reward. The quest type is item gathering, so check the inventory.
							if (GameInformation.miscInventory [a].ID == IR.Quest100 [x].QuestTarget) {
								IR.Quest100 [x].QuestConditionCheck1 (GameInformation.miscInventory [a].ID, GameInformation.miscInventory [a].Amount);
								reward = IR.Quest100 [x].QuestRewardExecutor ();
								if (reward != 0) {
									GameInformation.miscInventory [a].Amount = GameInformation.miscInventory [a].Amount - IR.Quest100 [x].TargetFlag;
									isRewardGiven = true;
									GameInformation.Gold += reward;
								}
								break;
							}
						}
					} else if (y == 2) {
						//Quest target is 2.
						index1 = 0;
						index2 = 0;
						for (int a = 0; a < GameInformation.miscInventory.Count; a++) {
							if (index2 == 0) {
								//Checking 2nd quest target.
								for (int b = 0; b < GameInformation.miscInventory.Count; b++) {
									if (GameInformation.miscInventory [b].ID == IR.Quest100 [x].QuestTarget2) {
										index2 = b;
										break;
									}
								}
							}
							//Cheking 1st quest target
							if (GameInformation.miscInventory [a].ID == IR.Quest100 [x].QuestTarget) {
								index1 = a;
								break;
							}
						}
						IR.Quest100 [x].QuestConditionCheck2 (GameInformation.miscInventory [index1].ID, GameInformation.miscInventory [index2].ID, GameInformation.miscInventory [index1].Amount, GameInformation.miscInventory [index2].Amount);
						reward = IR.Quest100 [x].QuestRewardExecutor ();
						if (reward != 0) {
							GameInformation.miscInventory [index1].Amount = GameInformation.miscInventory [index1].Amount - IR.Quest100 [x].TargetFlag;
							GameInformation.miscInventory [index2].Amount = GameInformation.miscInventory [index2].Amount - IR.Quest100 [x].TargetFlag2;
							isRewardGiven = true;
							GameInformation.Gold += reward;
						}
					} else if (y == 3) {
						index1 = 0;
						index2 = 0;
						index3 = 0;
						//Quest target is 3.
						for (int a = 0; a < GameInformation.miscInventory.Count; a++) {
							if (index2 == 0) {
								for (int b = 0; b < GameInformation.miscInventory.Count; b++) {
									if (index3 == 0) {
										//Checking the 3rd quest target
										for (int c = 0; c < GameInformation.miscInventory.Count; c++) {
											if (GameInformation.miscInventory [c].ID == IR.Quest100 [x].QuestTarget3) {
												index3 = c;
												break;
											}
										}
									}
									//Checking the 2nd quest target
									if (GameInformation.miscInventory [b].ID == IR.Quest100 [x].QuestTarget2) {
										index2 = b;
										break;
									}
								}
							}
							//Checking the 1st quest target
							if (GameInformation.miscInventory [a].ID == IR.Quest100 [x].QuestTarget) {
								index1 = a;
								break;
							}
						}
						IR.Quest100 [x].QuestConditionCheck3 (GameInformation.miscInventory [index1].ID, GameInformation.miscInventory [index2].ID, GameInformation.miscInventory [index3].ID, GameInformation.miscInventory [index1].Amount, GameInformation.miscInventory [index2].Amount, GameInformation.miscInventory [index3].Amount);
						reward = IR.Quest100 [x].QuestRewardExecutor ();
						if (reward != 0) {
							GameInformation.miscInventory [index1].Amount = GameInformation.miscInventory [index1].Amount - IR.Quest100 [x].TargetFlag;
							GameInformation.miscInventory [index2].Amount = GameInformation.miscInventory [index2].Amount - IR.Quest100 [x].TargetFlag2;
							GameInformation.miscInventory [index3].Amount = GameInformation.miscInventory [index3].Amount - IR.Quest100 [x].TargetFlag3;
							isRewardGiven = true;
							GameInformation.Gold += reward;
						}
					} else if (y == 4) {
						index1 = 0;
						index2 = 0;
						index3 = 0;
						index4 = 0;
						//Quest target is 4.
						for (int a = 0; a < GameInformation.miscInventory.Count; a++) {
							if (index2 == 0) {
								for (int b = 0; b < GameInformation.miscInventory.Count; b++) {
									if (index3 == 0) {
										for (int c = 0; c < GameInformation.miscInventory.Count; c++) {
											if (index4 == 0) {
												for (int d = 0; d < GameInformation.miscInventory.Count; d++) {
													//Checking the 4th quest target
													if (GameInformation.miscInventory [d].ID == IR.Quest100 [x].QuestTarget4) {
														index4 = d;
														break;
													}
												}
											}
											//Checking the 3rd quest target
											if (GameInformation.miscInventory [c].ID == IR.Quest100 [x].QuestTarget3) {
												index3 = c;
												break;
											}
										}
									}
									//Checking the 2nd quest target
									if (GameInformation.miscInventory [b].ID == IR.Quest100 [x].QuestTarget2) {
										index2 = b;
										break;
									}
								}
							}
							//Checking the 1st quest target
							if (GameInformation.miscInventory [a].ID == IR.Quest100 [x].QuestTarget) {
								index1 = a;
								break;
							}
						}
						IR.Quest100 [x].QuestConditionCheck4 (GameInformation.miscInventory [index1].ID, GameInformation.miscInventory [index2].ID, GameInformation.miscInventory [index3].ID, GameInformation.miscInventory [index4].ID, GameInformation.miscInventory [index1].Amount, GameInformation.miscInventory [index2].Amount, GameInformation.miscInventory [index3].Amount, GameInformation.miscInventory [index4].Amount);
						reward = IR.Quest100 [x].QuestRewardExecutor ();
						if (reward != 0 && isRewardGiven == false) {
							GameInformation.miscInventory [index1].Amount = GameInformation.miscInventory [index1].Amount - IR.Quest100 [x].TargetFlag;
							GameInformation.miscInventory [index2].Amount = GameInformation.miscInventory [index2].Amount - IR.Quest100 [x].TargetFlag2;
							GameInformation.miscInventory [index3].Amount = GameInformation.miscInventory [index3].Amount - IR.Quest100 [x].TargetFlag3;
							GameInformation.miscInventory [index4].Amount = GameInformation.miscInventory [index4].Amount - IR.Quest100 [x].TargetFlag4;
							isRewardGiven = true;
							GameInformation.Gold += reward;
							reward = 0;
							IR.Quest100 [x].QuestDeactivator (isRewardGiven);
						}
					}
					break;
				}
			}
			int standardHeight = Screen.height / 2;
			int positionHeight = standardHeight - 170;
			int standardWidth = Screen.width / 2;
			int positionWidth = standardWidth - 100;
			int positionWidth2 = standardWidth - 150;
			int positionWidth3 = standardWidth - 85;
			if (isRewardGiven == false) {
				//The quest is not cleared and the reward is not given.
				GUI.skin.label.wordWrap = true;
				GUI.Box (new Rect (positionWidth2, positionHeight, 300, 200), "");
				GUI.Label (new Rect (positionWidth, positionHeight + 70, 200, 200), "The quest is not yet completed.");
				GUI.Label (new Rect (positionWidth, positionHeight + 85, 200, 200), "Please complete the quest first.");
				if (GUI.Button (new Rect (positionWidth3, positionHeight + 230, 170, 40), "Cancel.")) {
					currentstate = State.IgnaQuestOption;
				}
			} else if (isRewardGiven == true) {
				//The quest is cleared and the reward is given.
				GUI.skin.label.wordWrap = true;
				GUI.skin.label.alignment = TextAnchor.UpperCenter;
				GUI.Box (new Rect (positionWidth2, positionHeight, 300, 200), "");
				GUI.Label (new Rect (positionWidth, positionHeight + 20, 200, 270), "Congratulations for completing the quest!");
				GUI.Label (new Rect (positionWidth, positionHeight + 55, 200, 200), "Please accept the reward!");
				GUI.Label (new Rect (positionWidth, positionHeight + 80, 200, 200), "Reward: " + reward + " Gold.");
				GUI.Label (new Rect (positionWidth, positionHeight + 105, 200, 200), "Current Gold: " + GameInformation.Gold + " Gold.");
				isRewardGiven = false;
				reward = 0;
				if (GUI.Button (new Rect (positionWidth3, positionHeight + 230, 170, 40), "Cancel.")) {
					currentstate = State.IgnaQuestOption;
				}
			}
		} else if (currentstate == State.XelvariaQuestReport) {
			isQuestCompleted = false;
			int OnGoingQuest = XLR.QuestVerificator ();
			if (OnGoingQuest == 1) {
				for (int i = 0; i< 22; i++) {
					int z = XLR.Quest200 [i].QuestChecker ();
					if (z == 1) {
						x = i;
						z = 0;
						y = XLR.Quest200 [x].QuestProcessing ();
						if (y == 1) {
							//For Xelvaria there are two type of quests, item gathering and enemy hunting. 
							//Igna is only item gathering & Fei Long is only enemy hunting.
							//First check the quest type
							if (XLR.Quest200 [x].QuestRequirement == BaseQuest.QuestType.ITEMGATHERING) {
								Debug.Log("Item Gathering");
								for (int a = 0; a < miscList.Count; a++) {
									if (miscList [a].ID == XLR.Quest200 [x].QuestTarget) {
										XLR.Quest200 [x].QuestConditionCheck1 (miscList [a].ID, miscList [a].Amount);
										reward = XLR.Quest200 [x].QuestRewardExecutor ();
										if (reward != 0) {
											miscList [a].Amount = miscList [a].Amount - XLR.Quest200 [x].TargetFlag;
											isRewardGiven = true;
											GameInformation.Gold += reward;
										}
										break;
									}
								}
							} else if (XLR.Quest200 [x].QuestRequirement == BaseQuest.QuestType.DEFEATENEMY) {
								string check;
								for (int b = 0; b< GameInformation.enemyTable.Count; b++) {
									GameInformation.enemyTable [b].TryGetValue ("ID", out check);
									if (check == XLR.Quest200 [x].QuestTarget) {
										XLR.Quest200 [x].QuestConditionCheck1 (check, GameInformation.enemyFlag [b]);
										reward = XLR.Quest200 [x].QuestRewardExecutor ();
										if (reward != 0) {
											GameInformation.enemyFlag [b] = GameInformation.enemyFlag [b] - XLR.Quest200 [x].TargetFlag;
											isRewardGiven = true;
											GameInformation.Gold += reward;
										}
										break;
									}
								}
							}
						} else if (y == 2) {

							if (XLR.Quest200 [x].QuestRequirement == BaseQuest.QuestType.ITEMGATHERING) {
								index1 = - 1;
								index2 = - 1;
								for (int a = 0; a < miscList.Count; a++) {
									if (index2 == -1) {
										for (int b = 0; b < miscList.Count; b++) {
											if (miscList [b].ID == XLR.Quest200 [x].QuestTarget2) {
												index2 = b;
							
												break;
											}
										}
									}
									if (miscList [a].ID == XLR.Quest200 [x].QuestTarget) {
										index1 = a;
										break;
									}
								}
								Debug.Log ("Index 1: " + index1);
								Debug.Log ("Index 2: " + index2);
								XLR.Quest200 [x].QuestConditionCheck2 (miscList [index1].ID, miscList [index2].ID, miscList [index1].Amount, miscList [index2].Amount);
//								Debug.Log("Function Accessed");
								reward = XLR.Quest200 [x].QuestRewardExecutor ();
								if (reward != 0) {
//									Debug.Log("Function Accessed Again");
									miscList [index1].Amount = miscList [index1].Amount - XLR.Quest200 [x].TargetFlag;
									miscList [index2].Amount = miscList [index2].Amount - XLR.Quest200 [x].TargetFlag2;
									isRewardGiven = true;
									GameInformation.Gold += reward;
								}
							} else if (XLR.Quest200 [x].QuestRequirement == BaseQuest.QuestType.DEFEATENEMY) {
								string check = "";
								string check2 = "";
								int index1 = 0;
								int index2 = 0;
								bool val = false;
								for (int b = 0; b < GameInformation.enemyTable.Count; b++) {
									if (val == false) {
										for (int c= 0; c < GameInformation.enemyTable.Count; c++) {
											GameInformation.enemyTable [c].TryGetValue ("ID", out check2);
											if (check2 == XLR.Quest200 [x].QuestTarget2) {
												val = true;
												index2 = c;
												break;
											}
										}
									}
									GameInformation.enemyTable [b].TryGetValue ("ID", out check);
									if (check == XLR.Quest200 [x].QuestTarget) {
										index1 = b;
										XLR.Quest200 [x].QuestConditionCheck2 (check, check2, GameInformation.enemyFlag [index1], GameInformation.enemyFlag [index2]);
										reward = XLR.Quest200 [x].QuestRewardExecutor ();
										if (reward != 0) {
											GameInformation.enemyFlag [index1] = GameInformation.enemyFlag [index1] - XLR.Quest200 [x].TargetFlag;
											GameInformation.enemyFlag [index2] = GameInformation.enemyFlag [index2] - XLR.Quest200 [x].TargetFlag2;
											isRewardGiven = true;
											GameInformation.Gold += reward;
										}
										break;
									}
								}
							}
						} else if (y == 3) {
							if (XLR.Quest200 [x].QuestRequirement == BaseQuest.QuestType.ITEMGATHERING) {
								index1 = 0;
								index2 = -1;
								index3 = -1;
								for (int a = 0; a < miscList.Count; a++) {
									if (index2 == -1) {
										for (int b = 0; b < miscList.Count; b++) {
											if (index3 == -1) {
												for (int c = 0; c < miscList.Count; c++) {
													if (miscList [c].ID == XLR.Quest200 [x].QuestTarget3) {
														index3 = c;
														break;
													}
												}
											}
											if (miscList [b].ID == XLR.Quest200 [x].QuestTarget2) {
												index2 = b;
												break;
											}
										}
									}
									if (miscList [a].ID == XLR.Quest200 [x].QuestTarget) {
										index1 = a;
										break;
									}
								}
								XLR.Quest200 [x].QuestConditionCheck3 (miscList [index1].ID, miscList [index2].ID, miscList [index3].ID, miscList [index1].Amount, miscList [index2].Amount, miscList [index3].Amount);
								reward = XLR.Quest200 [x].QuestRewardExecutor ();
								if (reward != 0) {
									miscList [index1].Amount = miscList [index1].Amount - XLR.Quest200 [x].TargetFlag;
									miscList [index2].Amount = miscList [index2].Amount - XLR.Quest200 [x].TargetFlag2;
									miscList [index3].Amount = miscList [index3].Amount - XLR.Quest200 [x].TargetFlag3;
									isRewardGiven = true;
									GameInformation.Gold += reward;
								}
							} else if (XLR.Quest200 [x].QuestRequirement == BaseQuest.QuestType.DEFEATENEMY) {
								string check = "";
								string check2 = "";
								string check3 = "";
								int index1 = 0;
								int index2 = 0;
								int index3 = 0;
								bool val = false;
								bool val2 = false;
								for (int b = 0; b< GameInformation.enemyTable.Count; b++) {
									if (val == false) {
										for (int c= 0; c< GameInformation.enemyTable.Count; c++) {
											if (val2 == false) {
												for (int d = 0; d< GameInformation.enemyTable.Count; d++) {
													GameInformation.enemyTable [d].TryGetValue ("ID", out check3);
													if (check3 == XLR.Quest200 [x].QuestTarget3) {
														val2 = true;
														index3 = d;
														break;
													}
												}
											}
											GameInformation.enemyTable [c].TryGetValue ("ID", out check2);
											if (check2 == XLR.Quest200 [x].QuestTarget2) {
												val = true;
												index2 = c;
												break;
											}
										}
									}
									GameInformation.enemyTable [b].TryGetValue ("ID", out check);
									if (check == XLR.Quest200 [x].QuestTarget) {
										index1 = b;
										XLR.Quest200 [x].QuestConditionCheck3 (check, check2, check3, GameInformation.enemyFlag [index1], GameInformation.enemyFlag [index2], GameInformation.enemyFlag [index3]);
										reward = XLR.Quest200 [x].QuestRewardExecutor ();
										if (reward != 0) {
											GameInformation.enemyFlag [index1] = GameInformation.enemyFlag [index1] - XLR.Quest200 [x].TargetFlag;
											GameInformation.enemyFlag [index2] = GameInformation.enemyFlag [index2] - XLR.Quest200 [x].TargetFlag2;
											GameInformation.enemyFlag [index3] = GameInformation.enemyFlag [index3] - XLR.Quest200 [x].TargetFlag3;
											isRewardGiven = true;
											GameInformation.Gold += reward;
										}
										break;
									}
								}
							}
						} else if (y == 4) {
							if (XLR.Quest200 [x].QuestRequirement == BaseQuest.QuestType.ITEMGATHERING) {
								index1 = 0;
								index2 = -1;
								index3 = -1;
								index4 = -1;
								for (int a = 0; a < miscList.Count; a++) {
									if (index2 == 0) {
										for (int b = 0; b < miscList.Count; b++) {
											if (index3 == 0) {
												for (int c = 0; c < miscList.Count; c++) {
													if (index4 == 0) {
														for (int d = 0; d < miscList.Count; d++) {
															if (miscList [d].ID == XLR.Quest200 [x].QuestTarget4) {
																index4 = d;
																break;
															}
														}
													}
													if (miscList [c].ID == XLR.Quest200 [x].QuestTarget3) {
														index3 = c;
														break;
													}
												}
											}
											if (miscList [b].ID == XLR.Quest200 [x].QuestTarget2) {
												index2 = b;
												break;
											}
										}
									}
									if (miscList [a].ID == XLR.Quest200 [x].QuestTarget) {
										index1 = a;
										break;
									}
								}

								XLR.Quest200 [x].QuestConditionCheck4 (miscList [index1].ID, miscList [index2].ID, miscList [index3].ID, miscList [index4].ID, miscList [index1].Amount, miscList [index2].Amount, miscList [index3].Amount, miscList [index4].Amount);
								reward = XLR.Quest200 [x].QuestRewardExecutor ();
								if (reward != 0) {
									miscList [index1].Amount = miscList [index1].Amount - XLR.Quest200 [x].TargetFlag;
									miscList [index2].Amount = miscList [index2].Amount - XLR.Quest200 [x].TargetFlag2;
									miscList [index3].Amount = miscList [index3].Amount - XLR.Quest200 [x].TargetFlag3;
									miscList [index4].Amount = miscList [index4].Amount - XLR.Quest200 [x].TargetFlag4;
									isRewardGiven = true;
									GameInformation.Gold += reward;
								}
							} else if (XLR.Quest200 [x].QuestRequirement == BaseQuest.QuestType.DEFEATENEMY) {
								string check = "";
								string check2 = "";
								string check3 = "";
								string check4 = "";
								int index1 = 0;
								int index2 = 0;
								int index3 = 0;
								int index4 = 0;
								bool val = false;
								bool val2 = false;
								bool val3 = false;
								for (int b = 0; b< GameInformation.enemyTable.Count; b++) {
									if (val == false) {
										for (int c= 0; c< GameInformation.enemyTable.Count; c++) {
											if (val2 == false) {
												for (int d = 0; d < GameInformation.enemyTable.Count; d++) {
													if (val3 == false) {
														for (int e = 0; e < GameInformation.enemyTable.Count; e++) {
															GameInformation.enemyTable [e].TryGetValue ("ID", out check4);
															if (check4 == XLR.Quest200 [x].QuestTarget4) {
																val3 = true;
																index4 = e;
																break;
															}
														}
													}
													GameInformation.enemyTable [d].TryGetValue ("ID", out check3);
													if (check3 == XLR.Quest200 [x].QuestTarget3) {
														val2 = true;
														index3 = d;
														break;
													}
												}
											}
											GameInformation.enemyTable [c].TryGetValue ("ID", out check2);
											if (check2 == XLR.Quest200 [x].QuestTarget2) {
												val = true;
												index2 = c;
												break;
											}
										}
									}
									GameInformation.enemyTable [b].TryGetValue ("ID", out check);
									if (check == XLR.Quest200 [x].QuestTarget) {
										index1 = b;
										XLR.Quest200 [x].QuestConditionCheck4 (check, check2, check3, check4, GameInformation.enemyFlag [index1], GameInformation.enemyFlag [index2], GameInformation.enemyFlag [index3], GameInformation.enemyFlag [index4]);
										reward = XLR.Quest200 [x].QuestRewardExecutor ();
										if (reward != 0) {
											GameInformation.enemyFlag [index1] = GameInformation.enemyFlag [index1] - XLR.Quest200 [x].TargetFlag;
											GameInformation.enemyFlag [index2] = GameInformation.enemyFlag [index2] - XLR.Quest200 [x].TargetFlag2;
											GameInformation.enemyFlag [index3] = GameInformation.enemyFlag [index3] - XLR.Quest200 [x].TargetFlag3;
											GameInformation.enemyFlag [index4] = GameInformation.enemyFlag [index4] - XLR.Quest200 [x].TargetFlag4;
											isRewardGiven = true;
											GameInformation.Gold += reward;
										}
										break;
									}
								}
							}
						}
					}
				}
			} else if (OnGoingQuest == 0) {
				isRewardGiven = false;
			}
			int standardHeight = Screen.height / 2;
			int positionHeight = standardHeight - 170;
			int standardWidth = Screen.width / 2;
			int positionWidth = standardWidth - 100;
			int positionWidth2 = standardWidth - 150;
			int positionWidth3 = standardWidth - 85;

			if (isRewardGiven == false && OnGoingQuest == 1) {
				GUI.skin.label.wordWrap = true;
				GUI.Box (new Rect (positionWidth2, positionHeight, 300, 200), "");
				GUI.Label (new Rect (positionWidth, positionHeight + 70, 200, 200), "The quest is not yet completed.");
				GUI.Label (new Rect (positionWidth, positionHeight + 85, 200, 200), "Please complete the quest first.");
				if (GUI.Button (new Rect (positionWidth3, positionHeight + 230, 170, 40), "Cancel.")) {
						currentstate = State.XelvariaQuestOption;
				}
			} else if (isRewardGiven == false && OnGoingQuest == 0) {
				GUI.skin.label.wordWrap = true;
				GUI.Box (new Rect (positionWidth2, positionHeight, 300, 200), "");
				GUI.Label (new Rect (positionWidth, positionHeight + 70, 200, 200), "You have not taken any quest.");
				GUI.Label (new Rect (positionWidth, positionHeight + 85, 200, 200), "Please take one of the quest first.");
				if (GUI.Button (new Rect (positionWidth3, positionHeight + 230, 170, 40), "Cancel.")) {
						currentstate = State.XelvariaQuestOption;
				}
			} else if (isRewardGiven == true) {
				GUI.skin.label.wordWrap = true;
				GUI.skin.label.alignment = TextAnchor.UpperCenter;
				GUI.Box (new Rect (positionWidth2, positionHeight, 300, 200), "");
				GUI.Label (new Rect (positionWidth, positionHeight + 20, 200, 270), "Congratulations for completing the quest!");
				GUI.Label (new Rect (positionWidth, positionHeight + 55, 200, 200), "Please accept the reward!");
				GUI.Label (new Rect (positionWidth, positionHeight + 80, 200, 200), "Reward: " + reward + " Gold.");
				GUI.Label (new Rect (positionWidth, positionHeight + 105, 200, 200), "Current Gold: " + GameInformation.Gold + " Gold.");
				isRewardGiven = false;
				reward = 0;
				if (GUI.Button (new Rect (positionWidth3, positionHeight + 230, 170, 40), "Cancel.")) {
					currentstate = State.XelvariaQuestOption;
				}
	
			}

//			if(repeat2 == 0){
//				for(int c2= 0; c2< miscList.Count; c2++){
//					Debug.Log(miscList[c2].Amount);
//				}
//
//			}
//			int standardHeight = Screen.height / 2;
//			int positionHeight = standardHeight - 170;
//			int standardWidth = Screen.width / 2;
//			int positionWidth = standardWidth - 100;
//			int positionWidth2 = standardWidth - 150;
//			int positionWidth3 = standardWidth - 85;
//
//			GUI.skin.label.wordWrap = true;
//			GUI.skin.label.alignment = TextAnchor.UpperCenter;
//			GUI.Box (new Rect (positionWidth2, positionHeight, 300, 200), "");
//			GUI.Label (new Rect (positionWidth, positionHeight + 20, 200, 270), "Congratulations for completing the quest!");
//			GUI.Label (new Rect (positionWidth, positionHeight + 55, 200, 200), "Please accept the reward!");
//			GUI.Label (new Rect (positionWidth, positionHeight + 80, 200, 200), "Reward: " + "500" + " Gold.");
//			GUI.Label (new Rect (positionWidth, positionHeight + 105, 200, 200), "Current Gold: " + "4750" + " Gold.");
//			GUI.Label (new Rect (positionWidth, positionHeight + 130, 200, 200), "Current Relationship Level: 2");
//			if (GUI.Button (new Rect (positionWidth3, positionHeight + 230, 170, 40), "Ok.")) {
//				currentstate = State.EventXelvaria;
//			}
		} else if (currentstate == State.FeiLongQuestReport) {
			isQuestCompleted = false;
			for (int i = 0; i< 22; i++) {
				int z = FLR.Quest300 [i].QuestChecker ();
				if (z == 1) {
					x = i;
					z = 0;
					y = FLR.Quest300 [x].QuestProcessing ();
					if (y == 1) {
						string check;
						for (int b = 0; b< GameInformation.enemyTable.Count; b++) {
							//Checking the enemy's ID and the number defeated
							GameInformation.enemyTable [b].TryGetValue ("ID", out check);
							if (check == FLR.Quest300 [x].QuestTarget) {
								FLR.Quest300 [x].QuestConditionCheck1 (check, GameInformation.enemyFlag [b]);
								reward = FLR.Quest300 [x].QuestRewardExecutor ();
								if (reward != 0) {
									//Reset the number of enemy defeated after quest is completed
									GameInformation.enemyFlag [b] = GameInformation.enemyFlag [b] - FLR.Quest300 [x].TargetFlag;
									isRewardGiven = true;
									GameInformation.Gold += reward;
								}
								break;
							}
						}
					} else if (y == 2) {
						string check = "";
						string check2 = "";
						int index1 = 0;
						int index2 = 0;
						bool val = false;
						for (int b = 0; b < GameInformation.enemyTable.Count; b++) {
							if (val == false) {
								for (int c= 0; c < GameInformation.enemyTable.Count; c++) {
									GameInformation.enemyTable [c].TryGetValue ("ID", out check2);
									if (check2 == FLR.Quest300 [x].QuestTarget2) {
										val = true;
										index2 = c;
										break;
									}
								}
							}
							GameInformation.enemyTable [b].TryGetValue ("ID", out check);
							if (check == FLR.Quest300 [x].QuestTarget) {
								index1 = b;
								FLR.Quest300 [x].QuestConditionCheck2 (check, check2, GameInformation.enemyFlag [index1], GameInformation.enemyFlag [index2]);
								reward = FLR.Quest300 [x].QuestRewardExecutor ();
								if (reward != 0) {
									GameInformation.enemyFlag [index1] = GameInformation.enemyFlag [index1] - FLR.Quest300 [x].TargetFlag;
									GameInformation.enemyFlag [index2] = GameInformation.enemyFlag [index2] - FLR.Quest300 [x].TargetFlag2;
									isRewardGiven = true;
									GameInformation.Gold += reward;
								}
								break;
							}
						}
					} else if (y == 3) {
						string check = "";
						string check2 = "";
						string check3 = "";
						int index1 = 0;
						int index2 = 0;
						int index3 = 0;
						bool val = false;
						bool val2 = false;
						for (int b = 0; b< GameInformation.enemyTable.Count; b++) {
							if (val == false) {
								for (int c= 0; c< GameInformation.enemyTable.Count; c++) {
									if (val2 == false) {
										for (int d = 0; d< GameInformation.enemyTable.Count; d++) {
											GameInformation.enemyTable [d].TryGetValue ("ID", out check3);
											if (check3 == FLR.Quest300 [x].QuestTarget3) {
												val2 = true;
												index3 = d;
												break;
											}
										}
									}
									GameInformation.enemyTable [c].TryGetValue ("ID", out check2);
									if (check2 == FLR.Quest300 [x].QuestTarget2) {
										val = true;
										index2 = c;
										break;
									}
								}
							}
							GameInformation.enemyTable [b].TryGetValue ("ID", out check);
							if (check == FLR.Quest300 [x].QuestTarget) {
								index1 = b;
								FLR.Quest300 [x].QuestConditionCheck3 (check, check2, check3, GameInformation.enemyFlag [index1], GameInformation.enemyFlag [index2], GameInformation.enemyFlag [index3]);
								reward = FLR.Quest300 [x].QuestRewardExecutor ();
								if (reward != 0) {
									GameInformation.enemyFlag [index1] = GameInformation.enemyFlag [index1] - FLR.Quest300 [x].TargetFlag;
									GameInformation.enemyFlag [index2] = GameInformation.enemyFlag [index2] - FLR.Quest300 [x].TargetFlag2;
									GameInformation.enemyFlag [index3] = GameInformation.enemyFlag [index3] - FLR.Quest300 [x].TargetFlag3;
									isRewardGiven = true;
									GameInformation.Gold += reward;
								}
								break;
							}
						}
					} else if (y == 4) {
						string check = "";
						string check2 = "";
						string check3 = "";
						string check4 = "";
						int index1 = 0;
						int index2 = 0;
						int index3 = 0;
						int index4 = 0;
						bool val = false;
						bool val2 = false;
						bool val3 = false;
						for (int b = 0; b< GameInformation.enemyTable.Count; b++) {
							if (val == false) {
								for (int c= 0; c< GameInformation.enemyTable.Count; c++) {
									if (val2 == false) {
										for (int d = 0; d < GameInformation.enemyTable.Count; d++) {
											if (val3 == false) {
												for (int e = 0; e < GameInformation.enemyTable.Count; e++) {
													GameInformation.enemyTable [e].TryGetValue ("ID", out check4);
													if (check4 == FLR.Quest300 [x].QuestTarget4) {
														val3 = true;
														index4 = e;
														break;
													}
	
												}
											}
											GameInformation.enemyTable [d].TryGetValue ("ID", out check3);
											if (check3 == FLR.Quest300 [x].QuestTarget3) {
												val2 = true;
												index3 = d;
												break;
											}
										}
									}
									GameInformation.enemyTable [c].TryGetValue ("ID", out check2);
									if (check2 == FLR.Quest300 [x].QuestTarget2) {
										val = true;
										index2 = c;
										break;
									}
								}
							}
							GameInformation.enemyTable [b].TryGetValue ("ID", out check);
							if (check == FLR.Quest300 [x].QuestTarget) {
								index1 = b;
								FLR.Quest300 [x].QuestConditionCheck4 (check, check2, check3, check4, GameInformation.enemyFlag [index1], GameInformation.enemyFlag [index2], GameInformation.enemyFlag [index3], GameInformation.enemyFlag [index4]);
								reward = FLR.Quest300 [x].QuestRewardExecutor ();
								if (reward != 0) {
									GameInformation.enemyFlag [index1] = GameInformation.enemyFlag [index1] - FLR.Quest300 [x].TargetFlag;
									GameInformation.enemyFlag [index2] = GameInformation.enemyFlag [index2] - FLR.Quest300 [x].TargetFlag2;
									GameInformation.enemyFlag [index3] = GameInformation.enemyFlag [index3] - FLR.Quest300 [x].TargetFlag3;
									GameInformation.enemyFlag [index4] = GameInformation.enemyFlag [index4] - FLR.Quest300 [x].TargetFlag4;
									isRewardGiven = true;
									GameInformation.Gold += reward;
								}
								break;
							}
						}
					}
		
//					if(FLR.QuestCompletion (x)!= 0){
//						gold = gold + FLR.QuestCompletion (x);
//						if(y==1){
//							number = number - FLR.Quest300[x].TargetFlag;
//						}
//						else if(y==2){
//							number = number - FLR.Quest300[x].TargetFlag;
//							number2 = number2 - FLR.Quest300[x].TargetFlag2;
//						}
//						else if(y==3){
//							number = number - FLR.Quest300[x].TargetFlag;
//							number2 = number2 - FLR.Quest300[x].TargetFlag2;
//							number3 = number3 - FLR.Quest300[x].TargetFlag3;
//						}
//						else if(y==4){
//							number = number - FLR.Quest300[x].TargetFlag;
//							number2 = number2 - FLR.Quest300[x].TargetFlag2;
//							number3 = number3 - FLR.Quest300[x].TargetFlag3;
//							number4 = number4 - FLR.Quest300[x].TargetFlag4;
//						}
//					}
		
//					Debug.Log(gold);
//					Debug.Log(number);
					break;
				}
			}

			int standardHeight = Screen.height / 2;
			int positionHeight = standardHeight - 170;
			int standardWidth = Screen.width / 2;
			int positionWidth = standardWidth - 100;
			int positionWidth2 = standardWidth - 150;
			int positionWidth3 = standardWidth - 85;

			if (isRewardGiven == false) {
				GUI.skin.label.wordWrap = true;
				GUI.Box (new Rect (positionWidth2, positionHeight, 300, 200), "");
				GUI.Label (new Rect (positionWidth, positionHeight + 70, 200, 200), "The quest is not yet completed.");
				GUI.Label (new Rect (positionWidth, positionHeight + 85, 200, 200), "Please complete the quest first.");
				if (GUI.Button (new Rect (positionWidth3, positionHeight + 230, 170, 40), "Cancel.")) {
					currentstate = State.FeiLongQuestOption;
				}
			} else if (isRewardGiven == true) {
				GUI.skin.label.wordWrap = true;
				GUI.skin.label.alignment = TextAnchor.UpperCenter;
				GUI.Box (new Rect (positionWidth2, positionHeight, 300, 200), "");
				GUI.Label (new Rect (positionWidth, positionHeight + 20, 200, 270), "Congratulations for completing the quest!");
				GUI.Label (new Rect (positionWidth, positionHeight + 55, 200, 200), "Please accept the reward!");
				GUI.Label (new Rect (positionWidth, positionHeight + 80, 200, 200), "Reward: " + reward + " Gold.");
				GUI.Label (new Rect (positionWidth, positionHeight + 105, 200, 200), "Current Gold: " + GameInformation.Gold + " Gold.");
				isRewardGiven = false;
				reward = 0;
				if (GUI.Button (new Rect (positionWidth3, positionHeight + 230, 170, 40), "Cancel.")) {
					currentstate = State.FeiLongQuestOption;
				}
	
			}
		} else if (currentstate == State.IgnaGift) {
			int standardHeight = Screen.height / 2;
			int standardWidth = Screen.width / 2;
			int positionHeight = standardHeight - 20;
			int positionWidth = standardWidth - 180;
			int positionHeight2 = standardHeight - 170;
			int positionWidth2 = standardWidth - 200;
			int positionHeight3 = standardHeight - 30;
			int positionWidth3 = standardWidth - 120;
			int positionWidth4 = standardWidth - 85;
			GUI.Box (new Rect (positionWidth, positionHeight - 240, 360, 40), "Please select the gift you want to give.");
			GUI.Box (new Rect (positionWidth2, positionHeight2 - 30, 400, 340), "");
			if(GUI.Button (new Rect (positionWidth3, positionHeight3 - 90, 240, 60), "Grimoire"+"Owned = " + own1)){
				own1 = own1 - 1;
			}
			if(GUI.Button (new Rect (positionWidth3, positionHeight3 + 10, 240, 60), "Necronomicon\n"+"Owned = " + own2)){
				own2 = own2 -1;
			}
			GUI.Button(new Rect (positionWidth4, positionHeight + 230, 170, 40), "Cancel.");
//			for (int i = 0; i < GameInformation.giftInventory.Count; i++) {
//				GUI.Label (new Rect (20, i * 80 + 20, 200, 20), GameInformation.giftInventory [i].Name);
//				GUI.Label (new Rect (240, i * 80 + 50, 100, 20), "Owned : " + GameInformation.giftInventory [i].Amount);
//				GUI.Label (new Rect (20, i * 80 + 70 + 40, 500, 20), GameInformation.giftInventory [i].Description);
//			}
		} else if (currentstate == State.XelvariaGift) {

			//GUI.Box (new Rect (250, 30, 270, 40), "Please select the gift you want to give.");
			//for (int a = 0; a < GameInformation.giftInventory.Count; a++) {

			int standardHeight = Screen.height / 2;
			int standardWidth = Screen.width / 2;
			int positionHeight = standardHeight - 20;
			int positionWidth = standardWidth - 180;
			int positionHeight2 = standardHeight - 170;
			int positionWidth2 = standardWidth - 200;
			int positionHeight3 = standardHeight - 30;
			int positionWidth3 = standardWidth - 120;
			int positionWidth4 = standardWidth - 85;
			GUI.Box (new Rect (positionWidth, positionHeight - 240, 360, 40), "Please select the gift you want to give.");
			GUI.Box (new Rect (positionWidth2, positionHeight2 - 30, 400, 340), "");
			if(GUI.Button (new Rect (positionWidth3, positionHeight3 - 90, 240, 60), "Pack of Sweet\n"+"Owned = " + own1)){
				own1 = own1 - 1;
			}
			if(GUI.Button (new Rect (positionWidth3, positionHeight3 + 10, 240, 60), "Candy Bucket\n"+"Owned = " + own2)){
				own2 = own2 -1;
			}
			GUI.Button(new Rect (positionWidth4, positionHeight + 230, 170, 40), "Cancel.");
//			for (int i = 0; i < GameInformation.giftInventory.Count; i++) {
//				GUI.Label (new Rect (20, i * 80 + 20, 200, 20), GameInformation.giftInventory [i].Name);
//				GUI.Label (new Rect (240, i * 80 + 50, 100, 20), "Owned : " + GameInformation.giftInventory [i].Amount);
//				GUI.Label (new Rect (20, i * 80 + 70 + 40, 500, 20), GameInformation.giftInventory [i].Description);
//			}
		} else if (currentstate == State.FeiLongGift) {
			GUI.Box (new Rect (250, 30, 270, 40), "Please select the gift you want to give.");
			for (int a = 0; a < GameInformation.giftInventory.Count; a++) {
			}
		} else if (currentstate == State.IgnaGiftResponse) {

		}else if (currentstate == State.XelvariaGiftResponse) {
			
		}else if (currentstate == State.FeiLongGiftResponse) {
			
		}
		else if (currentstate == State.EventIgna) {

		}else if (currentstate == State.EventXelvaria) {
			int DialogueIndex = 0;
			if(XLR.RelationshipLevel == 1){
				DialogueIndex = 6;
			}
			else if(XLR.RelationshipLevel == 2){
				DialogueIndex = 0;
			}

			charaTexture = limcaSprite;
			charaTexture2 = xelvariaSprite;
			GUI.skin.box.alignment = TextAnchor.UpperLeft;
			GUI.skin.box.fontSize = 15;
			int standardHeight = Screen.height / 2;
			int positionHeight = standardHeight - 50;
			int positionHeight2 = standardHeight - 15;
			int positionHeight3 = standardHeight - 15;
			int standardWidth = Screen.width / 2;
			int positionWidth = standardWidth - 250;
			int positionWidth2 = standardWidth - 35;
			int positionWidth3 = standardWidth - 50;
			int positionWidth4 = standardWidth - 100;
			int positionHeight4 = standardHeight - 190;
			if (showButton)
			{
				Dialoguer.StartDialogue(DialogueIndex);
				//this.enabled = false;
				showButton = false;
				int i;
				int x;
				endScene = false;
			}
			if (endScene)
			{
				//GUI.Box(new Rect(10, 70, 200, 150), "Congrats");
				
			}
			
			if (!_showing)
			{
				return;
			}

			if (_charaname != "") {
				if(_charaname == "Xelvaria"){
					GUI.DrawTexture(new Rect(positionWidth4 + 300, positionHeight4+140, 230, 380), charaTexture2, ScaleMode.StretchToFill);
					GUI.skin.box.alignment = TextAnchor.MiddleCenter;
					GUI.Box(new Rect(positionWidth3 + 200, positionHeight3 + 120, 100, 30), _charaname);

				}
				else if(_charaname == "Limca"){
					GUI.DrawTexture(new Rect(positionWidth4 - 300, positionHeight4+140, 200, 380), charaTexture, ScaleMode.StretchToFill);
					GUI.skin.box.alignment = TextAnchor.MiddleCenter;
					GUI.Box(new Rect(positionWidth3 - 200, positionHeight3+ 120, 100, 30), _charaname);
				}
				GUI.skin.box.alignment = TextAnchor.UpperLeft;
			}
			GUI.Box(new Rect(positionWidth, positionHeight + 190, 500, 100), _text);
			if (GUI.Button (new Rect (positionWidth2 + 220, positionHeight2 + 270, 70, 30), "Next")) {
				Dialoguer.ContinueDialogue();
			}
		
		}else if (currentstate == State.EventFeiLong) {


		}
	}
	
	void Update() {
		//for this example, the bar display is linked to the current time,
		//however you would set this value based on your desired display
		//eg, the loading progress, the player's health, or whatever.
		//barDisplay = Time.time*0.05f;
		//        barDisplay = MyControlScript.staticHealth;
	}

	private void onStarted(){
		Debug.Log ("End of story");
		_showing = true;
		
	}
	
	private void onEnded(){
		
		Debug.Log ("End of story");
		_showing = false;
		endScene = true;
		currentstate = State.Main;
		//Dialoguer.EndDialogue();
		
	}
	
	private void onTextPhase(DialoguerTextData data){
		
		_text = data.text;
		_charaname = data.name;
		
	}
	
	private void DialoguerCallBack(){
		
		this.enabled = true;
	}


}
