using System.Collections;
using UnityEngine;

public class AttackRecoverState : State<Monster>
{
    private float recoverTime = 1.5f;
    private float timeRemaining;
    private bool timerIsRunning = false;

    public AttackRecoverState(Monster owner) : base(owner)
    {
    }

    public override void OnEnter()
    {
        timeRemaining = recoverTime;
        timerIsRunning = true;
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
        if (timerIsRunning)
        {
            if(timeRemaining > 0f)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Owner.isRecovering = false;
            }
        }
    }
}
