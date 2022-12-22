using UnityEngine;

public class Monster : MonoBehaviour, IDamageable
{
    private FiniteStateMachine fsm;

    [SerializeField]
    private GameObject pickupPrefab;
    [SerializeField]
    private ParticleSystem hitParticle;
    
    [SerializeField]
    private float lookRange;
    [SerializeField]
    private float attackRange;

    private float maxHealth = 100;
    private float currentHealth;
    private bool isDead = false;

    public bool isRecovering = false;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

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
        IState attackRecoverState = new AttackRecoverState(this);


        fsm = new FiniteStateMachine(idleState, followState, deadState, attackRecoverState, attackState);

        fsm.AddTransition(new Transition(idleState, followState, IsInFollowRange));
        fsm.AddTransition(new Transition(followState, attackState, IsInAttackRange));
        fsm.AddTransition(new Transition(followState, idleState, IsNotInFollowRange));
        fsm.AddTransition(new Transition(attackState, attackRecoverState, IsRecovering));
        fsm.AddTransition(new Transition(attackRecoverState, idleState, IsNotRecovering));

        fsm.AddTransition(new Transition(idleState, deadState, IsDead));
        fsm.AddTransition(new Transition(followState, deadState, IsDead));
        fsm.AddTransition(new Transition(attackState, deadState, IsDead));
        fsm.AddTransition(new Transition(attackRecoverState, deadState, IsDead));

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

    public bool IsRecovering()
    {
        return isRecovering;
    }

    public bool IsNotRecovering()
    {
        return !isRecovering;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void Damage(float damage)
    {
        currentHealth = currentHealth - damage;
        hitParticle.Play();

        if(currentHealth < 0)
        {
            isDead = true;

            RollForPickup();
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

    private void RollForPickup()
    {
        if(true)
        {
            Instantiate(pickupPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }
}
