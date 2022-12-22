using UnityEngine;

public class FollowState : State<Monster>
{
    Player player;
    readonly float speed = 1f;

    public FollowState(Monster owner) : base(owner)
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    public override void OnEnter()
    {
        Owner.animator.Play("Walking");
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
        var step = speed * Time.deltaTime;
        Owner.transform.position = Vector3.MoveTowards(Owner.transform.position, player.transform.position, step);

        if(player.transform.position.x < Owner.transform.position.x)
        {
            Owner.spriteRenderer.flipX = true;
        }
        else
        {
            Owner.spriteRenderer.flipX = false;  
        }
    }
}
