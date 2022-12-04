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
    }

    // Update is called once per frame
    void Update()
    {
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
        health = baseHealth + healthModifiers;
        damage = baseDamage + damageModifiers;
    }

    private void FixedUpdate()
    {
        moveVelocity.OnFixedUpdate(this);
    }

    public void GainAbility(Ability ability)
    {
        abilities.Add(ability);
    }
}
