using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Ability pickupAbility;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player != null)
        {
            player?.GainAbility(Instantiate(pickupAbility));
            Destroy(gameObject);
        }

    }
}
