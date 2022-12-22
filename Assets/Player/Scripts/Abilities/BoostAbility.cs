using UnityEngine;

[CreateAssetMenu(fileName = "BoostAbility", menuName = "Abilities/Boost")]
public class BoostAbility : Ability
{
    public override float GetModifier(Player player)
    {
        return value;
    }
}