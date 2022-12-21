using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State<Monster>
{
    public AttackState(Monster owner) : base(owner)
    {
    }

    public override void OnUpdate()
    {
    }

    public override void OnEnter()
    {
        Debug.Log("Entered Attack State");
        Owner.animator.Play("Attack");
    }

    public override void OnExit()
    {
    }
}
