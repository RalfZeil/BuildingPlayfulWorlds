using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State<Monster>
{
    public DeadState(Monster owner) : base(owner)
    {
    }

    public override void OnUpdate()
    {
    }

    public override void OnEnter()
    {
        Owner.animator.Play("Death");
        Owner.GetComponent<Monster>().enabled = false;
        Owner.GetComponent<BoxCollider2D>().enabled = false;
    }

    public override void OnExit()
    {
    }
}
