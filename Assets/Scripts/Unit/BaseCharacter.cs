using UnityEngine;
using System.Collections;

public class BaseCharacter : BaseUnit
{
	private int currentXp;
	private int xpToLvUp;
    private int baseHp;
    private int baseMp;
	private int baseStr;
	private int baseEnd;
	private int baseAgi;
	private int baseMag;
	private int baseAcc;
    private int hpGrowth;
    private int mpGrowth;
    private int strGrowth;
    private int endGrowth;
    private int agiGrowth;
    private int magGrowth;
    private int accGrowth;
    private BaseWeapon weapon = new BaseWeapon();
    private BaseArmor armor = new BaseArmor();
    private BaseBoots boots = new BaseBoots();
    private BaseAccessory accessory = new BaseAccessory();
    private BaseAbility[] chosenAbility = new BaseAbility[4];
    private int bonusStr = 0;
    private int bonusMag = 0;
    private int bonusEnd = 0;
    private int bonusAcc = 0;
    private int bonusAgi = 0;

    public enum CharacterUnit
	{
		CECIL,
		LIMCA,
		GALARD
	}
	private CharacterUnit characterUnitName;

    public BaseWeapon Weapon
    {
        set { weapon = value; }
        get { return weapon; }
    }

    public BaseArmor Armor
    {
        set { armor = value; }
        get { return armor; }
    }
    public BaseBoots Boots
    {
        set { boots = value; }
        get { return boots; }

    }
    public BaseAccessory Accessory
    {
        set { accessory = value; }
        get { return accessory; }
    }

	public int CurrentXp
	{
		set{currentXp = value;}
		get{return currentXp;}
	}

	public int BaseHp
	{
		set{baseHp = value;}
		get{return baseHp;}
	}

	public int BaseMp
	{
		set{baseMp = value;}
		get{return baseMp;}
	}

	public int XpToLvUp
	{
		set{xpToLvUp = value;}
		get{return xpToLvUp;}
	}

    public int BaseStr
    {
        set { baseStr = value; }
        get { return baseStr; }
    }

    public int BaseAgi
    {
        set { baseAgi = value; }
        get { return baseAgi; }
    }

    public int BaseEnd
    {
        set { baseEnd = value; }
        get { return baseEnd; }
    }
        public int BaseMag
	{
		set{baseMag = value;}
		get{return baseMag;}
	}

    public int BaseAcc
	{
		set{baseAcc = value;}
		get{return baseAcc;}
	}

	public CharacterUnit CharacterUnitName
	{
		set{characterUnitName = value;}
		get{return characterUnitName;}
	}

    public int HpGrowth
    {
        set { hpGrowth = value; }
        get { return hpGrowth; }
    }

    public int MpGrowth
    {
        set { mpGrowth = value; }
        get { return mpGrowth; }
    }

    public int StrGrowth
    {
        set { strGrowth = value; }
        get { return strGrowth; }
    }

    public int AgiGrowth
    {
        set { agiGrowth = value; }
        get { return agiGrowth; }
    }

    public int EndGrowth
    {
        set { endGrowth = value; }
        get { return endGrowth; }
    }

    public int MagGrowth
    {
        set { magGrowth = value; }
        get { return magGrowth; }
    }

    public int AccGrowth
    {
        set { accGrowth = value; }
        get { return accGrowth; }
    }

    public BaseAbility[] ChosenAbility
    {
        set { chosenAbility = value; }
        get { return chosenAbility; }
    }

    public int BonusStr
    {
        set { bonusStr = value; }
        get { return bonusStr; }
    }

    public int BonusMag
    {
        set { bonusMag = value; }
        get { return bonusMag; }
    }

    public int BonusEnd
    {
        set { bonusEnd = value; }
        get { return bonusEnd; }
    }

    public int BonusAgi
    {
        set { bonusAgi = value; }
        get { return bonusAgi; }
    }

    public int BonusAcc
    {
        set { bonusAcc = value; }
        get { return bonusAcc; }
    }

    public void CalculateBonus()
    {
        bonusStr = 0;
        bonusMag = 0;
        bonusEnd = 0;
        bonusAcc = 0;
        bonusAgi = 0;
        if (weapon != null)
        {
            bonusStr += weapon.Str;
            bonusMag += weapon.Mag;
            bonusEnd += weapon.End;
            bonusAcc += weapon.Acc;
            bonusAgi += weapon.Agi;
        }
        if (armor != null)
        {
            bonusStr += armor.Str;
            bonusMag += armor.Mag;
            bonusEnd += armor.End;
            bonusAcc += armor.Acc;
            bonusAgi += armor.Agi;
        }
        if (accessory != null)
        {
            bonusStr += accessory.Str;
            bonusMag += accessory.Mag;
            bonusEnd += accessory.End;
            bonusAcc += accessory.Acc;
            bonusAgi += accessory.Agi;
        }
        if (boots != null)
        {
            bonusStr += boots.Str;
            bonusMag += boots.Mag;
            bonusEnd += boots.End;
            bonusAcc += boots.Acc;
            bonusAgi += boots.Agi;
        }
        Str = baseStr + (Lv - 1) * strGrowth + bonusStr;
        Agi = baseAgi + (Lv - 1) * agiGrowth + bonusAgi;
        End = baseEnd + (Lv - 1) * endGrowth + bonusEnd;
        Mag = baseMag + (Lv - 1) * magGrowth + bonusMag;
        Acc = baseAcc + (Lv - 1) * accGrowth + bonusAcc;
    }
}
