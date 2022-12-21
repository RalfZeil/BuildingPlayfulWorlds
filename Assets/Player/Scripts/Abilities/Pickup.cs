using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Ability[] abilities;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if(player != null)
        {
            EventManager<Ability[]>.RaiseEvent(EventType.ON_ABILITY_GAIN, abilities);
        }

    }
}
