using UnityEngine;

public class AttackSword : Weapon
{
    private Vector3 attackDir;
    [SerializeField] float attackSize = 0.5f;

    public override void Attack(Vector2 direction)
    {
        Vector3 dir = direction;

        attackDir = dir;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position + dir, attackSize);

        foreach (Collider2D collider in colliders)
        {
            collider.TryGetComponent(out IDamageable Idamageable);
            Idamageable?.Damage();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position + attackDir, attackSize);
    }
}
