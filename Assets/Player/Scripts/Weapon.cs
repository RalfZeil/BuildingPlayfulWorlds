using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IAttack
{
    public abstract void Attack(Vector2 direction);
}
