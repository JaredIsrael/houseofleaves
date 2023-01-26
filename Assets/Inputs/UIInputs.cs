//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Inputs/UIInputs.inputactions
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

public partial class @UIInputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @UIInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UIInputs"",
    ""maps"": [
        {
            ""name"": ""Inputs"",
            ""id"": ""b5980edb-d629-4130-82e7-d5972e5d71ef"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""PassThrough"",
                    ""id"": ""059576cc-9d47-4c33-8f0c-4eccee0b497e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0e213a82-0d46-4cfe-8266-5f2ff3c990fd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a4ad51c5-a7ca-4093-a6a6-78d782d1a795"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6fe28087-d91a-4a02-9851-27fc640a87f8"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Inputs
        m_Inputs = asset.FindActionMap("Inputs", throwIfNotFound: true);
        m_Inputs_Pause = m_Inputs.FindAction("Pause", throwIfNotFound: true);
        m_Inputs_Reset = m_Inputs.FindAction("Reset", throwIfNotFound: true);
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

    // Inputs
    private readonly InputActionMap m_Inputs;
    private IInputsActions m_InputsActionsCallbackInterface;
    private readonly InputAction m_Inputs_Pause;
    private readonly InputAction m_Inputs_Reset;
    public struct InputsActions
    {
        private @UIInputs m_Wrapper;
        public InputsActions(@UIInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Inputs_Pause;
        public InputAction @Reset => m_Wrapper.m_Inputs_Reset;
        public InputActionMap Get() { return m_Wrapper.m_Inputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputsActions set) { return set.Get(); }
        public void SetCallbacks(IInputsActions instance)
        {
            if (m_Wrapper.m_InputsActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnPause;
                @Reset.started -= m_Wrapper.m_InputsActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_InputsActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_InputsActionsCallbackInterface.OnReset;
            }
            m_Wrapper.m_InputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
            }
        }
    }
    public InputsActions @Inputs => new InputsActions(this);
    public interface IInputsActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
    }
}