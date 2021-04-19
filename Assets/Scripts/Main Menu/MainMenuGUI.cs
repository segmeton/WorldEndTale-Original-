using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour 
{
    public static bool mainMenuClicked = false;
    public static bool newGame = false;
    public static bool exit = false;
    public static bool isConfirm = false;

	void Start()
	{
		newGame = false;
		mainMenuClicked = false;
		exit = false;
		isConfirm = false;
	}

    void OnGUI()
    {
        if (isConfirm != true)
        {
            if (GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) + 50, 200, 30), "New Game"))
            {
                if (mainMenuClicked == false)
                {
                    mainMenuClicked = true;
                    newGame = true;
                    Application.LoadLevel("Town");
                }
            }

            if (GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) + 100, 200, 30), "Load Game"))
            {
                if (mainMenuClicked == false)
                {
                    mainMenuClicked = true;
                }
            }

            if (GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) + 150, 200, 30), "Credit"))
            {
                if (mainMenuClicked == false)
                {
                    mainMenuClicked = true;
                    Application.LoadLevel("Credit");
                }
            }

            if (GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) + 200, 200, 30), "Exit Game"))
            {
                if (mainMenuClicked == false)
                {
                    mainMenuClicked = true;
                    isConfirm = true;
                }
            }
        }
        else if (isConfirm == true)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 80));
            //GUI.Box(new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 40, 200, 30), "Exit Game?");
            GUI.Box(new Rect(0, 0, 200, 80),"");
            GUI.skin.GetStyle("Label").alignment = TextAnchor.UpperCenter;
            GUI.Label(new Rect(10, 10, 180, 30), "Exit Game?");
            //if (GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) + 20, 90, 30), "No"))
            if (GUI.Button(new Rect(10, 40, 80, 30), "No"))
            {
                isConfirm = false;
                mainMenuClicked = false;
            }
            //if (GUI.Button(new Rect((Screen.width / 2)+10, (Screen.height / 2) + 20, 90, 30), "Yes"))
            if (GUI.Button(new Rect(110, 40, 80, 30), "Yes"))
            {
                exit = true;
                Application.Quit();
            }
            GUI.EndGroup();
        }
        
    }
}
