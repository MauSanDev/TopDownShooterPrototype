//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/InputController.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputController : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputController"",
    ""maps"": [
        {
            ""name"": ""MainPlayer"",
            ""id"": ""cb80330d-4249-4a3e-8c87-3b945d2b815c"",
            ""actions"": [
                {
                    ""name"": ""Shot"",
                    ""type"": ""Button"",
                    ""id"": ""a2665270-3789-4d0c-8cf8-de4b29fc88ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ecd7788c-370c-495f-9e5b-714060ea5250"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""aefc3678-9781-40e3-8bd5-6a6e2350c24a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b6439a21-4aca-4c12-9a03-e1b8218deffa"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Shot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""16ca32bb-b7e8-4841-97ec-15b3492078ac"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""67dbedb7-6eb5-4c46-94e5-c9ee805f91a5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""38840958-3289-4309-8796-dd79c3a94d8b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d639419c-003e-4b0b-8f65-2abe62a8697f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b33ed7da-9fae-46ee-8363-f04c2cb9fecb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8ca7e3b3-db01-43c1-b5bd-d6fc15d1853f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // MainPlayer
        m_MainPlayer = asset.FindActionMap("MainPlayer", throwIfNotFound: true);
        m_MainPlayer_Shot = m_MainPlayer.FindAction("Shot", throwIfNotFound: true);
        m_MainPlayer_Movement = m_MainPlayer.FindAction("Movement", throwIfNotFound: true);
        m_MainPlayer_Roll = m_MainPlayer.FindAction("Roll", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // MainPlayer
    private readonly InputActionMap m_MainPlayer;
    private IMainPlayerActions m_MainPlayerActionsCallbackInterface;
    private readonly InputAction m_MainPlayer_Shot;
    private readonly InputAction m_MainPlayer_Movement;
    private readonly InputAction m_MainPlayer_Roll;
    public struct MainPlayerActions
    {
        private @InputController m_Wrapper;
        public MainPlayerActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shot => m_Wrapper.m_MainPlayer_Shot;
        public InputAction @Movement => m_Wrapper.m_MainPlayer_Movement;
        public InputAction @Roll => m_Wrapper.m_MainPlayer_Roll;
        public InputActionMap Get() { return m_Wrapper.m_MainPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainPlayerActions set) { return set.Get(); }
        public void SetCallbacks(IMainPlayerActions instance)
        {
            if (m_Wrapper.m_MainPlayerActionsCallbackInterface != null)
            {
                @Shot.started -= m_Wrapper.m_MainPlayerActionsCallbackInterface.OnShot;
                @Shot.performed -= m_Wrapper.m_MainPlayerActionsCallbackInterface.OnShot;
                @Shot.canceled -= m_Wrapper.m_MainPlayerActionsCallbackInterface.OnShot;
                @Movement.started -= m_Wrapper.m_MainPlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MainPlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MainPlayerActionsCallbackInterface.OnMovement;
                @Roll.started -= m_Wrapper.m_MainPlayerActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_MainPlayerActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_MainPlayerActionsCallbackInterface.OnRoll;
            }
            m_Wrapper.m_MainPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shot.started += instance.OnShot;
                @Shot.performed += instance.OnShot;
                @Shot.canceled += instance.OnShot;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
            }
        }
    }
    public MainPlayerActions @MainPlayer => new MainPlayerActions(this);
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    public interface IMainPlayerActions
    {
        void OnShot(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
    }
}
