using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string boostType;
    public float value; 

    public virtual void Initialize() { }
    public abstract float GetModifier(Player player);
}
