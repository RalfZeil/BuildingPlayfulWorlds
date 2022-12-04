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
    }

    public void OnFixedUpdate(Player player)
    {
        rb.velocity = velocityVector * player.speed;
    }
}
