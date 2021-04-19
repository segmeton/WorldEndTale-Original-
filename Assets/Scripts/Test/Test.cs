using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Test : MonoBehaviour {

    List<BaseWeapon> testInventory = new List<BaseWeapon>();
  
	// Use this for initialization
	void Awake () {
        BaseWeapon a = new BaseWeapon("WP01");
        BaseWeapon b = new BaseWeapon("WP02");
        testInventory.Add(a);
        a = new BaseWeapon("WP01");
        testInventory.Add(a);
        a = new BaseWeapon("WP01");
        testInventory.Add(a);
        testInventory[0].Name = "best";
        testInventory[1].Name = "good";
        testInventory[2].Name = "bad";
        //BaseCharacter Cecil = new Limca();
        //Debug.Log("Name : "+Cecil.Name);
        //Debug.Log("HP : "+Cecil.Hp);
        //if(Cecil.CharacterUnitName == BaseCharacter.CharacterUnit.LIMCA)
        //{
        //    Debug.Log("I'm really Limca");
        //}
        //else
        //{
        //    Debug.Log("I'm not actually Limca");
        //}
	}
	
	// Update is called once per frame
	void OnGUI () {
        int length = testInventory.Count;
        for (int i = 0; i < length; i++)
        {
            // Debug.Log("name : " + a.Name);
            GUI.Label(new Rect(10, 10 + 50 * i, 100, 20), "name : " + testInventory[i].Name);
            GUI.Label(new Rect(10, 30 + 50 * i, 100, 20), "name : " + testInventory[i].Index);
        }
        //string testrandom = (char) Random.Range(0,26) + Random.Range(0,100);
        //int testrandom = Random.Range(0, 10000);
        //GUI.Label(new Rect(10, 10 + 20 * i, 100, 20), "name : " + testrandom);
	}
}
