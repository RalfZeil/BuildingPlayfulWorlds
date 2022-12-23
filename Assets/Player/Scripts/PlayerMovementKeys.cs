using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementKeys : MonoBehaviour
{
    private PlayerControlls playerControlls;


    private void Awake()
    {
        playerControlls = new PlayerControlls();

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
        Vector3 playerInput = playerControlls.Player.Move.ReadValue<Vector2>();
        GetComponent<IMoveVelocity>().SetVelocity(playerInput); 
    }
}
