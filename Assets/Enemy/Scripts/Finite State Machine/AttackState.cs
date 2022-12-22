using UnityEngine;

public class AttackState : State<Monster>
{
    private Player player;

    private float attackDuration = 0.25f;

    private float attackSize = 0.5f;

    public AttackState(Monster owner) : base(owner)
    {
        player = GameObject.FindObjectOfType<Player>();
    }

    public override void OnEnter()
    {
        Owner.animator.Play("Attack");

        attackDuration = 0.25f;
    }

    public override void OnUpdate()
    {
        if (attackDuration > 0)
        {
            attackDuration = attackDuration - Time.deltaTime;
        }
        else
        {
            Vector3 dir = (player.transform.position - Owner.transform.position).normalized;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(Owner.transform.position + dir, attackSize);

            foreach (Collider2D collider in colliders)
            {
                collider.TryGetComponent(out Player player);
                player?.Damage();
            }

            Owner.isRecovering = true;
        }
    }

    public override void OnExit()
    {
        
    }
}
