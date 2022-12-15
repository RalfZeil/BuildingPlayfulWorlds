using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string boostType;
    public string desc;
    public float value;
    public int rarity;

    public virtual void Initialize() { }
    public abstract float GetModifier(Player player);
}
