using System;
using UnityEngine;

[RequireComponent(typeof(AbstractNPCBehaviour))]
public class InputListenerBehaviour : AbstractNPCBehaviour
{
    [SerializeField] private InputManager inputManager;
    protected override void OnSetup()
    {
        if (Owner is IInputListener inputListener)
        {
            inputManager.SetListener(inputListener);
            return;
        }

        throw new Exception($"The NPC {Owner.name} is not an Input Listener!");
    }
}
