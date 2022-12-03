using UnityEngine;

[CreateAssetMenu(fileName = "SpeedBoostAbility", menuName = "Abilities/SpeedBoost")]
public class SpeedBoost : Ability
{
    public float AddedSpeed = 3f;
    public override void OnUpdate(Player player)
    {

    }
}