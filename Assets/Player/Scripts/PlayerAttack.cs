using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private PlayerControlls playerControlls;

    [SerializeField]
    private GameObject attackPoint;

    [SerializeField]
    private float distanceFromPlayer = 1.5f;

    private Animator animator;

    private void Awake()
    {
        playerControlls = new PlayerControlls();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        playerControlls?.Player.Enable();
    }

    private void OnDisable()
    {
        playerControlls?.Player.Disable();
    }

    private void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 attackDir = (new Vector2(worldPosition.x, worldPosition.y) - new Vector2(transform.position.x, transform.position.y)).normalized;

        attackPoint.transform.SetPositionAndRotation(transform.position + attackDir * distanceFromPlayer, Quaternion.Euler(0, 0, attackDir.z));

        if (playerControlls.Player.Fire.WasPressedThisFrame())
        {
            GetComponent<IAttack>().Attack(attackDir);
            EventManager.RaiseEvent(EventType.ON_PLAYER_ATTACK);
        }
    }
}
