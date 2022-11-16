using System;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine<T> where T : IFiniteState
{
    private Dictionary<string, T> registries = new Dictionary<string, T>();

    public string CurrentStateId { get; private set; }
    
    public T CurrentState { get; private set; }
    
    public void RegisterState(string stateId, T newState, bool apply = false)
    {
        if (registries.ContainsKey(stateId))
        {
            Debug.LogWarning($"{GetType()} :: The State with ID {stateId} is going to be replaced with a new {newState.GetType()}");
        }

        registries[stateId] = newState;
        
        if (apply)
        {
            ApplyState(stateId);
        }
    }

    public void ApplyState(string stateId)
    {
        if (!registries.ContainsKey(stateId))
        {
            throw new Exception($"{GetType()} :: There's no State registered with the ID {stateId}. State couldn't be applied!");
        }

        CurrentStateId = stateId;
        CurrentState = registries[stateId];
        CurrentState.OnStateApply();
    }
}
