using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine
{
    private List<Transition> allTransitions = new List<Transition>();
    private List<Transition> activeTransitions = new List<Transition>();

    private Dictionary<Type, IState> stateCollection = new Dictionary<Type, IState>();
    private IState currentState;

    //Creates the machine and stores all given states
    public FiniteStateMachine(params IState[] states)
    {
        for(int i = 0; i < states.Length; i++)
        {
            stateCollection.Add(states[i].GetType(), states[i]);
        }
    }

    //Update current state
    public void OnFixedUpdate()
    {
        foreach(Transition transition in activeTransitions)
        {
            if (transition.Evalutate())
            {
                SwitchState(transition.toState);
                return;
            }
        }

        currentState?.OnUpdate();
    }

    //Switches state with given state Type
    public void SwitchState(Type stateType)
    {
        if (stateCollection.ContainsKey(stateType))
        {
            currentState?.OnExit();
            currentState = stateCollection[stateType];
            currentState?.OnEnter();
        }
    }

    //Switches state with given state object
    public void SwitchState(IState newState)
    {
        currentState?.OnExit();
        currentState = newState;
        activeTransitions = allTransitions.FindAll(x => x.fromState == currentState || x.fromState == null);
        currentState?.OnEnter();
    }

    public void AddState(IState state)
    {
        stateCollection.Add(state.GetType(), state);
    }

    public void AddTransition(Transition transition)
    {
        allTransitions.Add(transition);
    }
}
