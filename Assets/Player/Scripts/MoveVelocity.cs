using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocity : MonoBehaviour, IMoveVelocity
{
    private Vector3 velocityVector;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Enable()
    {
        this.enabled = true;
    }

    public void Disable()
    {
        this.enabled = false;
    }

    public void SetVelocity(Vector3 velocityVector)
    {
        this.velocityVector =  velocityVector;

        //Raise event for changing direction for character
        if(velocityVector.x > 0)
        {
            EventManager<bool>.RaiseEvent(EventType.ON_CHANGE_DIRECTION, false);

            EventManager<bool>.RaiseEvent(EventType.ON_WALKING, true);
        }
        else if(velocityVector.x < 0)
        {
            EventManager<bool>.RaiseEvent(EventType.ON_CHANGE_DIRECTION, true);

            EventManager<bool>.RaiseEvent(EventType.ON_WALKING, true);
        }
        else if(velocityVector.y < 0 || velocityVector.y > 0)
        {
            EventManager<bool>.RaiseEvent(EventType.ON_WALKING, true);
        }
        else
        {
            EventManager<bool>.RaiseEvent(EventType.ON_WALKING, false);
        }
    }

    public void OnFixedUpdate(Player player)
    {
        rb.velocity = velocityVector * player.GetSpeed();
    }
}
