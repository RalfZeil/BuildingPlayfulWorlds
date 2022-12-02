using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IDamageAble
{

    [SerializeField] private SpriteRenderer spriteRenderer;
    private FiniteStateMachine fsm;

    public bool foundPlayer;

    void Start()
    {
        SetupStateMachine();
    }

    private void SetupStateMachine()
    {
        IState idleState = new IdleState(this);
        IState followState = new FollowState(this);

        fsm = new FiniteStateMachine(idleState, followState);

        fsm.AddTransition(new Transition(idleState, followState, IsInRange));

        fsm.SwitchState(idleState);
    }

    void FixedUpdate()
    {

        Collider2D[] scan = Physics2D.OverlapCircleAll(this.transform.position, 5f);

        foreach (Collider2D col in scan)
        {
            if (col.tag == "Player")
            {
                foundPlayer = true;
                Debug.Log("In Range");
            }
        }

        fsm?.OnFixedUpdate();
    }

    public bool IsInRange()
    {
        return foundPlayer;
    }

    public void Damage()
    {
        spriteRenderer.color = new Color(1, 0, 0);
        Debug.Log("Damaged");
    }
}
