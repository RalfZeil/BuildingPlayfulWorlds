using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public IMoveVelocity moveVelocity;

    public List<Ability> abilities = new List<Ability>();

    public int health = 5;
    public float baseSpeed = 4f;
    public float speed;
    public float damage = 1f;

    private void Start()
    {
        moveVelocity = GetComponent<IMoveVelocity>();
    }

    // Update is called once per frame
    void Update()
    {
        float modifiers = 0;

        foreach(Ability ability in abilities)
        {
            if(ability.boostType)
            modifiers = modifiers + ability.GetModifier(this);
        }

        speed = baseSpeed + modifiers;
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
