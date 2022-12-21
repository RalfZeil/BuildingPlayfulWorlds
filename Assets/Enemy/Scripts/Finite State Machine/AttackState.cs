using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State<Monster>
{
    public AttackState(Monster owner) : base(owner)
    {
    }

    public virtual void OnUpdate()
    {
    }

    public virtual void OnEnter()
    {
        Owner.animator.Play("Attack");
    }

    public virtual void OnExit()
    {
    }
}
