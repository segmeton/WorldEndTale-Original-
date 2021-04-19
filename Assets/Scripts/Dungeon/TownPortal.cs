using UnityEngine;
using System.Collections;

public class TownPortal : MonoBehaviour
{
    public static bool inPortal = false;

    void OnTriggerEnter2D(Collider2D player)
    {
        inPortal = true;
    }

    void OnGUI()
    {
        if(inPortal == true)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 80));
                GUI.Box(new Rect(0, 0, 200, 80), "");
                GUI.color = new Color(1, 1, 1, 1);
                GUI.skin.GetStyle("Label").alignment = TextAnchor.UpperCenter;
                GUI.Label(new Rect(10, 10, 180, 30), "Return to Town?");
                if (GUI.Button(new Rect(10, 40, 80, 30), "No"))
                {
                    inPortal = false;
                }
                if (GUI.Button(new Rect(110, 40, 80, 30), "Yes"))
                {
                    inPortal = false;
                    Application.LoadLevel("Town");
                }
            GUI.EndGroup();
        }
    }
}
