using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class IdleState : State<Monster>
{
    public IdleState(Monster owner) : base(owner)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("On Enter Idle");
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
    }
}
