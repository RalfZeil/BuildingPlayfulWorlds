using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        EventManager<float>.AddListener(EventType.ON_TAKE_DAMAGE, SetAnimTriggerTakeDamage);
        EventManager<bool>.AddListener(EventType.ON_CHANGE_DIRECTION , SetFlipSprite);
        EventManager<bool>.AddListener(EventType.ON_WALKING, SetWalking);
        EventManager.AddListener(EventType.ON_PLAYER_DEATH, SetDead);
        EventManager.AddListener(EventType.ON_PLAYER_ATTACK, SetAnimTriggerAttack);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void SetAnimTriggerTakeDamage(float health)
    {
        animator.SetTrigger("TakeDamage");
    }

    private void SetAnimBool(string boolName, bool status)
    {
        animator.SetBool(boolName, status);
    }

    private void SetWalking(bool status)
    {
        SetAnimBool("IsRunning", status);
    }

    private void SetDead()
    {
        SetAnimBool("IsDead", true);
    }

    private void SetAnimTriggerAttack()
    {
        animator.SetTrigger("Attack");
    }

    public void SetFlipSprite(bool flip)
    {
        spriteRenderer.flipX = flip;
    }
}
