using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public IMoveVelocity moveVelocity;

    public List<Ability> abilities = new List<Ability>();

    public float baseHealth = 5;
    public float health;

    public float baseSpeed = 4f;
    public float speed;

    public float baseDamage = 1f;
    public float damage;

    private void Start()
    {
        moveVelocity = GetComponent<IMoveVelocity>();

        health = baseHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        moveVelocity.OnFixedUpdate(this);
    }

    public void GainAbility(Ability _ability)
    {
        abilities.Add(_ability);

        float speedModifiers = 0;
        float damageModifiers = 0;
        float healthModifiers = 0;

        foreach (Ability ability in abilities)
        {
            if (ability.boostType.Equals("speed"))
            {
                speedModifiers = speedModifiers + ability.value;
            }
            else if (ability.boostType.Equals("damage"))
            {
                damageModifiers = damageModifiers + ability.value;
            }
            else if (ability.boostType.Equals("health"))
            {
                healthModifiers = healthModifiers + ability.value;
            }
        }

        speed = baseSpeed + speedModifiers;
        damage = baseDamage + damageModifiers;

        EventManager<Ability>.RaiseEvent(EventType.ON_ABILITY_GAIN, _ability);
    }

    public void Damage()
    {
        health = health - 1;

        if(health <= 0)
        {
            EventManager.RaiseEvent(EventType.ON_PLAYER_DEATH);
        }

        if(health >= 0)
        {
            EventManager<float>.RaiseEvent(EventType.ON_TAKE_DAMAGE, health);
        }
        
    }
}
