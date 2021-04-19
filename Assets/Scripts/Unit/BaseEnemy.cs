using UnityEngine;
using System.Collections;

public class BaseEnemy : BaseUnit 
{
    private int expDrop;
    private int goldDrop;
    private BaseElement element = new BaseElement();
    private string commonDropID;
    private string uncommonDropID;
    private string rareDropID;
    private string group;

    public int ExpDrop
    {
        set { expDrop = value; }
        get { return expDrop; }
    }

    public int GoldDrop
    {
        set { goldDrop = value; }
        get { return goldDrop; }
    }

    public BaseElement Element
    {
        set { element = value; }
        get { return element; }
    }

    public string CommonDropID
    {
        set { commonDropID = value; }
        get { return commonDropID; }
    }

    public string UncommonDropID
    {
        set { uncommonDropID = value; }
        get { return uncommonDropID; }
    }

    public string RareDropID
    {
        set { rareDropID = value; }
        get { return rareDropID; }
    }

    public string Group
    {
        set { group = value; }
        get { return group; }
    }

}
