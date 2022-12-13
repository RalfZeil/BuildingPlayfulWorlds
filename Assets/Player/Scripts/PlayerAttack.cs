using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private PlayerControlls playerControlls;
    private PlayerInput playerInput;

    [SerializeField]
    private GameObject attackPoint;

    [SerializeField]
    private float distanceFromPlayer = 1.5f;

    [SerializeField]
    private bool usingController = false;

    private void Awake()
    {
        playerControlls = new PlayerControlls();
        playerInput = GetComponent<PlayerInput>();
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
        Vector3 worldPosition;
        Vector3 attackDir;

        if (!usingController)
        {
            worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            attackDir = (new Vector2(worldPosition.x, worldPosition.y) - new Vector2(transform.position.x, transform.position.y)).normalized;
        }
        else
        {
            attackDir = playerControlls.Player.Look.ReadValue<Vector2>().normalized;
        }


        attackPoint.transform.SetPositionAndRotation(transform.position + attackDir * distanceFromPlayer, Quaternion.Euler(0, 0, attackDir.z));

        if (playerControlls.Player.Fire.WasPressedThisFrame())
        {
            GetComponent<IAttack>().Attack(attackDir);
            EventManager.RaiseEvent(EventType.ON_PLAYER_ATTACK);
        }
    }

    public void ChangeInputTypeToController()
    {
        Debug.Log(playerInput.currentControlScheme);
        //if(playerInput.currentControlScheme)
        usingController = true;
    }
}
