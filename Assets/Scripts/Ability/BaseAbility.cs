using UnityEngine;
using System.Collections;

public class BaseAbility
{
    private string id;
	private string name;
	private string description;
    private int basePower;
    private int mpCost;
    private bool isUnlocked = false;
    private bool isAdded = false;
    private BaseElement element = new BaseElement();
    
    public enum Target
    {
        SINGLE,
        ALL
    }
    private Target targetEnemy;

    public enum Type
    {
        PHYSICAL,
        MAGICAL
    }
    private Type skillType;

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

    public int BasePower
    {
        set { basePower = value; }
        get { return basePower; }
    }

    public int MpCost
    {
        set { mpCost = value; }
        get { return mpCost; }
    }

    public bool IsUnlocked
    {
        set { isUnlocked = value; }
        get { return isUnlocked; }
    }

    public bool IsAdded
    {
        set { isAdded = value; }
        get { return isAdded; }
    }

    public BaseElement Element
    {
        set { element = value; }
        get { return element; }
    }

    public Target TargetEnemy
    {
        set { targetEnemy = value; }
        get { return targetEnemy; }
    }

    public Type SkillType
    {
        set { skillType = value; }
        get { return skillType; }
    }
}
