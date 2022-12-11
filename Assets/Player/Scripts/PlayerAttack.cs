using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerControlls playerControlls;

    private void Awake()
    {
        playerControlls = new PlayerControlls();
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
        if (playerControlls.Player.Fire.IsPressed())
        {
            GetComponent<IAttack>().Attack();
        }
    }
}
