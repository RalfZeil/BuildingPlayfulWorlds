using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public List<Ability> abilities = new List<Ability>();

    public float speed = 4f;


    // Update is called once per frame
    void Update()
    {
        foreach(Ability ability in abilities)
        {
            ability.OnUpdate(this);
        }
    }

    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void GainAbility()
    {

    }
}
