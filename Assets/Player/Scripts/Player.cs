using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    private IMoveVelocity moveVelocity;

    private List<Ability> abilities = new List<Ability>();

    [SerializeField]
    private float baseMaxHealth = 5;
    private float maxHealth;
    private float currentHealth;

    [SerializeField]
    private float baseSpeed = 4f;
    private float speed;

    [SerializeField]
    private float baseDamage = 1f;
    private float damage;

    private void Start()
    {
        EventManager<Ability>.AddListener(EventType.ON_GIVE_ABILITY, GainAbility);
        moveVelocity = GetComponent<IMoveVelocity>();

        maxHealth = baseMaxHealth;
        currentHealth = maxHealth;
        speed = baseSpeed;
        damage = baseDamage;
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
                currentHealth = currentHealth + ability.value;
                EventManager<float>.RaiseEvent(EventType.ON_HEALTH_GAIN, currentHealth/maxHealth);
                break;
            case "damage":
                damage = damage + ability.value;
                break;
        }

    }

    public void Damage()
    {
        currentHealth = currentHealth - 1;

        Debug.Log(currentHealth);

        if(currentHealth <= 0)
        {
            EventManager.RaiseEvent(EventType.ON_PLAYER_DEATH);
        }

        if(currentHealth >= 0)
        {
            EventManager<float>.RaiseEvent(EventType.ON_TAKE_DAMAGE, currentHealth/maxHealth);
        }
        
    }

    public float GetBaseSpeed()
    {
        return speed;
    }
}
