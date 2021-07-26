using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum UnitType
{
    Normal,
    Boss
}

public delegate void OnDeath();
public class Unit
{
    public readonly UnitType Type;
    public readonly string Name;
    public event OnDeath OnDeath;
    
    public void Die()
    {
        OnDeath?.Invoke();
    }

    public Unit()
    {
        Type = UnitType.Normal;
        Name = "sampleUnit";
    }
    public Unit(UnitType type, string name)
    {
        Type = type;
        Name = name;
    }
}
