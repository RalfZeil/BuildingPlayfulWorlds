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

        EventManager.AddListener(EventType.ON_PLAYER_DEATH, OnDisable);
    }

    private void OnEnable()
    {
        playerControlls?.Player.Enable();
    }

    private void OnDisable()
    {
        playerControlls?.Player.Disable();
        EventManager.RemoveListener(EventType.ON_PLAYER_DEATH, OnDisable);
    }

    private void Update()
    {
        Vector3 worldPosition;
        Vector3 attackDir;

        if (!usingController)
        {
            attackPoint.SetActive(true);

            worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            attackDir = (new Vector2(worldPosition.x, worldPosition.y) - new Vector2(transform.position.x, transform.position.y)).normalized;
        }
        else
        {
            attackDir = playerControlls.Player.Look.ReadValue<Vector2>().normalized;

            if(attackDir == new Vector3(0, 0, 0))
            {
                attackPoint.SetActive(false);
            }
            else
            {
                attackPoint.SetActive(true);
            }
        }

        //Set position and rotation of the attackpoint
        attackPoint.transform.position = (transform.position + attackDir * distanceFromPlayer);
        float rot_z = Mathf.Atan2(attackDir.y, attackDir.x) * Mathf.Rad2Deg;
        attackPoint.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        if (playerControlls.Player.Fire.WasPressedThisFrame())
        {
            GetComponent<IAttack>().Attack(attackDir);
            EventManager.RaiseEvent(EventType.ON_PLAYER_ATTACK);
        }
    }

    public void ChangeInputTypeToController()
    {
        if(playerInput?.currentControlScheme == "Gamepad")
        {
            usingController = true;
        }
        else
        {
            usingController = false;
        }
    }
}
