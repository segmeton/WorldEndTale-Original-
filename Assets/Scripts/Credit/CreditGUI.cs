using UnityEngine;
using System.Collections;

public class CreditGUI : MonoBehaviour {

    private Vector2 creditScrollPosition = Vector2.zero;

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width-140,40,100,30), "Return"))
        {
            Application.LoadLevel("MainMenu");
        }
        GUI.BeginGroup(new Rect(0, 100, Screen.width, Screen.height), "");
            showCredit();
        GUI.EndGroup();
    }

   private void showCredit()
    {
        GUI.Label(new Rect(40, 0, 100, 30), "Group Member");
        
        GUI.Label(new Rect(170, 0, 200, 30), "Stephen Perdana Hadinata");
        GUI.Label(new Rect(170, 30, 200, 30), "Albertus Agung");
        GUI.Label(new Rect(170, 60, 200, 30), "Alwin Kurniawan");

        GUI.Label(new Rect(40, 120, 100, 30), "Advisor");

        GUI.Label(new Rect(170, 120, 200, 30), "David And, S.Kom., M.Ti.");

        GUI.Label(new Rect(40, 180, 100, 30), "Image Asset by");
   
        GUI.Label(new Rect(170, 180, 200, 30), "Almost Human Ltd");
        GUI.Label(new Rect(170, 210, 200, 30), "Crisis Nacth");
        GUI.Label(new Rect(170, 240, 200, 30), "Dawnpu");
        GUI.Label(new Rect(170, 270, 200, 30), "Ed Greenwood");
        GUI.Label(new Rect(170, 300, 200, 30), "Fania Andimulia");
        GUI.Label(new Rect(170, 330, 200, 30), "Jędrzej Mróz");
        GUI.Label(new Rect(170, 360, 200, 30), "Kazuma Kaneko");
        GUI.Label(new Rect(170, 390, 200, 30), "MMrailgun");
        GUI.Label(new Rect(170, 420, 200, 30), "Paleblood");
        GUI.Label(new Rect(170, 450, 200, 30), "Yoshitaka Amano");

        GUI.Label(new Rect(400, 0, 100, 30), "Music by");

        GUI.Label(new Rect(530, 0, 300, 30), "\"Break The Sword of Justice\" by Yuki Kajiura");
        GUI.Label(new Rect(530, 30, 300, 30), "\"Fear\" by SoundTeMP");
        GUI.Label(new Rect(530, 60, 300, 30), "\"Ruthless\" by Yuki Kajiura");
        GUI.Label(new Rect(530, 90, 300, 30), "\"Theme of Aldebaran\" by SoundTeMP");
        GUI.Label(new Rect(530, 120, 300, 30), "\"Victory\" by Nobue Uematsu");
    }
}