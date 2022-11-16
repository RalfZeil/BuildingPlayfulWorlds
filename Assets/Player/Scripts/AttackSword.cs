using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSword : MonoBehaviour, IAttack
{
    private enum State
    {
        Normal,
        Attacking
    }

    private State state;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void SetStateAttacking()
    {
        state = State.Attacking;
        GetComponent<IMoveVelocity>().Disable();
    }

    private void SetStateNormal()
    {
        state = State.Normal;
        GetComponent<IMoveVelocity>().Enable();
    }

    public void Attack()
    {
        SetStateAttacking();
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 attackDir = (worldPosition - transform.position).normalized;
    }
}
