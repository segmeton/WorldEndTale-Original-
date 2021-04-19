using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public AudioSource battleBGM;
    public AudioSource dungeonBGM;
    public AudioSource fanfareBGM;
    //private AudioSource battleBGM;

    void Awake()
    {
        //dungeonBGMObject.audio.playOnAwake = true;
    }
	// Use this for initialization
	void Start () 
    {
        //battleBGMObject = GameObject.Find("BattleBGM");
        //dungeonBGMObject = GameObject.Find("DungeonBGM");
        //battleBGM = (AudioSource)battleBGMObject.GetComponent<AudioSource>();      
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (EncounterManager.isBattle == false)
        {
            if (dungeonBGM.isPlaying != true)
            {
                battleBGM.Stop();
                dungeonBGM.PlayDelayed(0);
            }   
        }
        else if (EncounterManager.isBattle == true)
        {
            if (battleBGM.isPlaying != true)
            {
                dungeonBGM.Stop();
                battleBGM.PlayDelayed(0);
            }
        }


        //if (EncounterManager.isBattle == false)
        //{
        //    battleBGMObject.audio.Stop();
        //    dungeonBGMObject.audio.PlayDelayed(0);
        //}
        //else if (EncounterManager.isBattle == true)
        //{
        //    dungeonBGMObject.audio.Stop();
        //    battleBGMObject.audio.PlayDelayed(0);
        //}
	}
}
