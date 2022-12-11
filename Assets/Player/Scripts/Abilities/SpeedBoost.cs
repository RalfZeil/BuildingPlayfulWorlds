using UnityEngine;

[CreateAssetMenu(fileName = "SpeedBoostAbility", menuName = "Abilities/SpeedBoost")]
public class SpeedBoost : Ability
{
    public override float GetModifier(Player player)
    {
        return value;
    }
}