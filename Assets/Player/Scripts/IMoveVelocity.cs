using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveVelocity
{
    void SetVelocity(Vector3 velocityVector);
    void OnFixedUpdate(Player player);
    void Enable();
    void Disable();
}
