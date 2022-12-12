using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        EventManager<float>.AddListener(EventType.ON_TAKE_DAMAGE, SetAnimTriggerTakeDamage);
    }

    private void SetAnimTriggerTakeDamage(float health)
    {
        animator.SetTrigger("TakeDamage");
        Debug.Log("Animation Damage");
    }

    private void SetAnimBool(string boolName, bool status)
    {
        animator.SetBool(boolName, status);
    }
}
