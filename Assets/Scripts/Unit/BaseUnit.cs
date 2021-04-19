using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseUnit
{
    private string id;
	private string name;
	private string description;

	private int lv;
	private int hp;
    private int currentHp;
	private int mp;
    private int currentMp;
	private int str;
	private int end;
	private int agi;
	private int mag;
	private int acc;

    //private BaseAbility attack = new Attack();

	private List<BaseAbility> abilityList = new List<BaseAbility>();
    //private BaseAbility choosenAbility = new BaseAbility[4];

    public string ID
    {
        set { id = value; }
        get { return id; }
    }
	public string Name
	{
		set{name = value;}
		get{return name;}
	}

	public string Description
	{
		set{description = value;}
		get{return description;}
	}

	public int Lv
	{
		set{lv = value;}
		get{return lv;}
	}

	public int Hp
	{
		set{hp = value;}
		get{return hp;}
	}

    public int CurrentHp
    {
        set { currentHp = value; }
        get { return currentHp; }
    }

	public int Mp
	{
		set{mp = value;}
		get{return mp;}
	}

    public int CurrentMp
    {
        set { currentMp = value; }
        get { return currentMp; }
    }

	public int Str
	{
		set{str = value;}
		get{return str;}
	}

	public int Agi
	{
		set{agi = value;}
		get{return agi;}
	}

	public int End
	{
		set{end = value;}
		get{return end;}
	}

	public int Mag
	{
		set{mag = value;}
		get{return mag;}
	}

	public int Acc
	{
		set{acc = value;}
		get{return acc;}
	}

	public List<BaseAbility> AbilityList
	{
        set { abilityList = value; }
        get { return abilityList; }
	}
}
