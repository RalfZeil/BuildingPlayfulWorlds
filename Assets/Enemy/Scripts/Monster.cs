using UnityEngine;

public class Monster : MonoBehaviour, IDamageable
{
    private FiniteStateMachine fsm;
    
    [SerializeField]
    private float lookRange;
    [SerializeField]
    private float attackRange;

    private float maxHealth = 100;
    private float currentHealth;
    private bool isDead = false;

    public Animator animator;

    void Start()
    {
        SetupStateMachine();
        animator = GetComponentInChildren<Animator>();
        
        currentHealth = maxHealth;
    }

    private void SetupStateMachine()
    {
        IState idleState = new IdleState(this);
        IState followState = new FollowState(this);
        IState deadState = new DeadState(this);
        IState attackState = new AttackState(this);

        fsm = new FiniteStateMachine(idleState, followState);

        fsm.AddTransition(new Transition(idleState, followState, IsInFollowRange));
        fsm.AddTransition(new Transition(followState, attackState, IsInAttackRange));
        fsm.AddTransition(new Transition(attackState, followState, IsNotInAttackRange));
        fsm.AddTransition(new Transition(followState, idleState, IsNotInFollowRange));

        fsm.AddTransition(new Transition(idleState, deadState, IsDead));
        fsm.AddTransition(new Transition(followState, deadState, IsDead));
        fsm.AddTransition(new Transition(attackState, deadState, IsDead));

        fsm.SwitchState(idleState);
    }

    void FixedUpdate()
    {
        fsm?.OnFixedUpdate();
    }

    public bool IsInFollowRange()
    {
        bool foundPlayer = false;

        Collider2D[] scan = Physics2D.OverlapCircleAll(this.transform.position, lookRange);

        foreach (Collider2D col in scan)
        {
            if (col.tag == "Player")
            {
                foundPlayer = true;
            }
        }

        return foundPlayer;
    }

    public bool IsInAttackRange()
    {
        bool inAttackRange = false;

        Collider2D[] scan = Physics2D.OverlapCircleAll(this.transform.position, attackRange);

        foreach (Collider2D col in scan)
        {
            if (col.tag == "Player")
            {
                inAttackRange = true;
            }
        }

        return inAttackRange;
    }

    public bool IsNotInAttackRange()
    {
        return !IsInAttackRange();
    }

    public bool IsNotInFollowRange()
    {
        return !IsInFollowRange();
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void Damage(float damage)
    {
        currentHealth = currentHealth - damage;

        if(currentHealth < 0)
        {
            isDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            player?.Damage();
        }
    }
}
