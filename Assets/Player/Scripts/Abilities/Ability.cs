using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public virtual void Initialize() { }
    public abstract void OnUpdate(Player player);
}
