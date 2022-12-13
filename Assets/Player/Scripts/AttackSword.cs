using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class AttackSword : Weapon
{
    Vector3 attackDir;
    [SerializeField] Vector2 boxSize = new Vector2(2f, 4f);

    

    private void Awake()
    {

    }

    //public override void Attack()
    //{
    //    //Get the attack direction
    //    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    //    attackDir = (worldPosition - transform.position).normalized;



    //    Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(transform.position + attackDir * 3f, boxSize, Vector3.Angle(attackDir, transform.position));
    //    attackPoint.transform.SetPositionAndRotation(transform.position + attackDir * 3f, Quaternion.Euler(0, 0, attackDir.z));



    //    foreach (Collider2D enemy in hitEnemies)
    //    {
    //        if(enemy.GetComponent<IDamageable>() != null)
    //        {
    //            enemy.GetComponent<IDamageable>().Damage();
    //        }
    //    }

    //    animator.SetTrigger("Attack");
    //}

    public override void Attack(Vector2 direction)
    {
        
    }
}
