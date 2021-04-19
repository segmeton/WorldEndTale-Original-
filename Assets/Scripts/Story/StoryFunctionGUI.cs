using UnityEngine;
using System.Collections;

public class StoryFunctionGUI : MonoBehaviour {
	public Texture cecilSpriteWounded;
	public Texture limcaSpriteAngry;
	public Texture cecilNormal;
	public Texture limcaNormal;
	private bool _showing;
	private string _text;
	private bool showButton = true;
	
	private string _charaname;
	private bool endScene;
	
	void Awake(){
		Dialoguer.Initialize ();
		
	}


	// Use this for initialization
	void Start () {
		Debug.Log ("Start of story");
		Dialoguer.events.onStarted += onStarted;
		Dialoguer.events.onTextPhase += onTextPhase;
		Dialoguer.events.onEnded += onEnded;

	}

	void OnGUI(){

		Texture charaTexture = new Texture();
		Texture charaTexture2 = new Texture();
		Texture charaTexture3 = new Texture();
		Texture charaTexture4 = new Texture();
		GUI.skin.button.alignment = TextAnchor.MiddleCenter;
		GUI.skin.button.fontSize = 12;
		GUI.skin.box.fontSize = 12;

		int DialogueIndex = 10;
		
		charaTexture = limcaNormal;
		charaTexture2 = cecilNormal;
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
		int positionWidth5 = standardWidth - 135;
		int positionHeight5 = standardHeight - 15;
		int positionWidth6 = standardWidth - 135;
		int positionHeight6 = standardHeight - 15;
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

		GUI.skin.box.alignment = TextAnchor.MiddleCenter;
		GUI.Box(new Rect(positionWidth5, positionHeight3 - 20, 270, 30), "It's kind of hard to say");
		GUI.Box(new Rect(positionWidth5, positionHeight3 + 30, 270, 30), "We are going to be alright, don't worry.");

		GUI.DrawTexture(new Rect(positionWidth4 + 310, positionHeight4+140, 270, 380), charaTexture2, ScaleMode.StretchToFill);
		GUI.skin.box.alignment = TextAnchor.MiddleCenter;
		GUI.Box(new Rect(positionWidth3 - 200, positionHeight3 + 120, 100, 30), "Limca");

		GUI.DrawTexture(new Rect(positionWidth4 - 360, positionHeight4+140, 270, 380), charaTexture, ScaleMode.StretchToFill);
		GUI.skin.box.alignment = TextAnchor.MiddleCenter;
		//GUI.Box(new Rect(positionWidth3 - 200, positionHeight3+ 120, 100, 30), _charaname);

		GUI.skin.box.alignment = TextAnchor.UpperLeft;
		GUI.Box(new Rect(positionWidth, positionHeight + 190, 500, 100), _text);
		if (GUI.Button (new Rect (positionWidth2 + 220, positionHeight2 + 270, 70, 30), "Next")) {
			Dialoguer.ContinueDialogue();
		}


	}

	private void onStarted(){
		Debug.Log ("End of story");
		_showing = true;
		
	}
	
	private void onEnded(){
		
		Debug.Log ("End of story");
		_showing = false;
		endScene = true;
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
