using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State<Monster>
{
    public DeadState(Monster owner) : base(owner)
    {
    }

    public virtual void OnUpdate()
    {
    }

    public virtual void OnEnter()
    {
    }

    public virtual void OnExit()
    {
    }
}
