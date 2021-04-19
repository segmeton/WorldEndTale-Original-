using UnityEngine;
using System.Collections;

public class BaseElement
{
    public enum Element
    {
        WATER,
        FIRE,
        WIND,
        ELECTRIC,
        EARTH,
        DARK,
        LIGHT,
        NEUTRAL
    }
    private Element elementType;

    public Element ElementType
    {
        set { elementType = value; }
        get { return elementType; }
    }
}
