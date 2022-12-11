using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class FollowState : State<Monster>
{
    GameObject player;
    readonly float speed = 1f;

    public FollowState(Monster owner) : base(owner)
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void OnEnter()
    {
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
        var step = speed * Time.deltaTime;
        Owner.transform.position = Vector3.MoveTowards(Owner.transform.position, player.transform.position, step);
    }
}
