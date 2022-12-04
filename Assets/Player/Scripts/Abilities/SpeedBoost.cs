using UnityEngine;

[CreateAssetMenu(fileName = "SpeedBoostAbility", menuName = "Abilities/SpeedBoost")]
public class SpeedBoost : Ability
{
    public string boostType = "speed";
    public float AddedSpeed = 3f;

    public override float GetModifier(Player player)
    {
        return AddedSpeed;
    }
}