using UnityEngine;
using System.Collections;

public class TownGUI : MonoBehaviour 
{
    void OnGUI()
    {
        if (GameStatusGUI.isOpen == false)
        {
            if (GUI.Button(new Rect(10, 70, 100, 50), "Dungeon"))
            {
                if (GameStatusGUI.isOpen == false)
                {
                    Application.LoadLevel("Dungeon");
                }
            }

            if (GUI.Button(new Rect(Screen.width / 2 + 60, 30, 100, 50), "Shop"))
            {
                if (GameStatusGUI.isOpen == false)
                {
                    Application.LoadLevel("Shop");
                }
            }

            if (GUI.Button(new Rect(Screen.width / 3, Screen.height / 2 + 10, 100, 50), "Armory"))
            {
                if (GameStatusGUI.isOpen == false)
                {
                    Application.LoadLevel("Armory");
                }
            }

            if (GUI.Button(new Rect(Screen.width * 2 / 3 + 50, Screen.height / 2 + 10, 100, 50), "Tavern"))
            {
                if (GameStatusGUI.isOpen == false)
                {
                    Application.LoadLevel("Tavern");
                }
            }
        }
    }
}
