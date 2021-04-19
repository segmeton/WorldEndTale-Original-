using UnityEngine;
using System.Collections;

public class BaseEquipment 
{
    private string id;
    private string name;
    private string description;
    private int buyPrice;
    private int sellPrice;
    private int str;
    private int mag;
    private int end;
    private int agi;
    private int acc;
    private bool useByCecil = false;
    private bool useByLimca = false;
    private bool useByGalard = false;
    private bool used = false;
    private int index;

    public enum EquipmentType
    {
        ACCESSORY,
        ARMOR,
        BOOTS,
        WEAPON,
    }
    private EquipmentType equipmentType;

    public BaseEquipment() { }

    public EquipmentType EquipmentTypeValue
    {
        set { equipmentType = value; }
        get { return equipmentType; }
    }

    public int Index
    {
        set { index = value; }
        get { return index; }
    }

    public string ID
    {
        set { id = value; }
        get { return id; }
    }

    public string Name
    {
        set { name = value; }
        get { return name; }
    }

    public string Description
    {
        set { description = value; }
        get { return description; }
    }

    public int BuyPrice
    {
        set { buyPrice = value; }
        get { return buyPrice; }
    }

    public int SellPrice
    {
        set { sellPrice = value; }
        get { return sellPrice; }
    }

    public int Str
    {
        set { str = value; }
        get { return str; }
    }

    public int Agi
    {
        set { agi = value; }
        get { return agi; }
    }

    public int End
    {
        set { end = value; }
        get { return end; }
    }

    public int Mag
    {
        set { mag = value; }
        get { return mag; }
    }

    public int Acc
    {
        set { acc = value; }
        get { return acc; }
    }

    public bool UseByCecil
    {
        set { useByCecil = value; }
        get { return useByCecil; }
    }

    public bool UseByLimca
    {
        set { useByLimca = value; }
        get { return useByLimca; }
    }

    public bool UseByGalard
    {
        set { useByGalard = value; }
        get { return useByGalard; }
    }

    public bool Used
    {
        set { used = value; }
        get { return used; }
    }
}
