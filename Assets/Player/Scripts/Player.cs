using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    private IMoveVelocity moveVelocity;

    private List<Ability> abilities = new List<Ability>();

    public float baseMaxHealth = 5;
    public float maxHealth;
    public float currentHealth;

    public float baseSpeed = 4f;
    public float speed;

    public float baseDamage = 1f;
    public float damage;

    private void Start()
    {
        EventManager<Ability>.AddListener(EventType.ON_GIVE_ABILITY, GainAbility);
        moveVelocity = GetComponent<IMoveVelocity>();

        maxHealth = baseMaxHealth;
    }

    private void FixedUpdate()
    {
        moveVelocity.OnFixedUpdate(this);
    }

    private void GainAbility(Ability ability)
    {
        abilities.Add(ability);

        switch (ability.boostType)
        {
            case "speed":
                speed = speed + ability.value;
                break;
            case "health":
                maxHealth = maxHealth + ability.value;
                break;
            case "damage":
                damage = damage + ability.value;
                break;
        }

    }

    public void Damage()
    {
        maxHealth = maxHealth - 1;

        if(maxHealth <= 0)
        {
            EventManager.RaiseEvent(EventType.ON_PLAYER_DEATH);
        }

        if(maxHealth >= 0)
        {
            EventManager<float>.RaiseEvent(EventType.ON_TAKE_DAMAGE, maxHealth);
        }
        
    }
}
