//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/ActionFiles/PlayerActions.inputactions
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

public partial class @PlayerActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""PlayerActionMap"",
            ""id"": ""1408581e-bd9c-44fa-8a95-cb07ed41183f"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""6ec7298f-6c84-476c-9bd7-50e1f926f815"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Launch"",
                    ""type"": ""Button"",
                    ""id"": ""056ddbfa-3975-4db3-a528-a863519477f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7f391a3b-db24-416e-9d60-fd2323a12af6"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84aa9d53-83b8-4876-beb0-f7d2fad1abfe"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Launch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuNavigation"",
            ""id"": ""facad97d-5f77-415c-8b4b-03442e189cd9"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Value"",
                    ""id"": ""4a3dca9d-6bd3-4733-b191-2e58c43f5ca8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Value"",
                    ""id"": ""c0ef0f1f-1ec5-4acc-9eb8-a86535afc695"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""527f0b4e-f843-405b-932d-7433e9252b01"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4d69d5e2-0934-4d2a-91b5-bd1b24a46629"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d112ca3-fc2a-4053-9fc9-6613e01679b9"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcc9c4e0-cd38-48d1-9372-c44c22ace5f2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerActionMap
        m_PlayerActionMap = asset.FindActionMap("PlayerActionMap", throwIfNotFound: true);
        m_PlayerActionMap_Rotate = m_PlayerActionMap.FindAction("Rotate", throwIfNotFound: true);
        m_PlayerActionMap_Launch = m_PlayerActionMap.FindAction("Launch", throwIfNotFound: true);
        // MenuNavigation
        m_MenuNavigation = asset.FindActionMap("MenuNavigation", throwIfNotFound: true);
        m_MenuNavigation_Up = m_MenuNavigation.FindAction("Up", throwIfNotFound: true);
        m_MenuNavigation_Down = m_MenuNavigation.FindAction("Down", throwIfNotFound: true);
        m_MenuNavigation_Select = m_MenuNavigation.FindAction("Select", throwIfNotFound: true);
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

    // PlayerActionMap
    private readonly InputActionMap m_PlayerActionMap;
    private IPlayerActionMapActions m_PlayerActionMapActionsCallbackInterface;
    private readonly InputAction m_PlayerActionMap_Rotate;
    private readonly InputAction m_PlayerActionMap_Launch;
    public struct PlayerActionMapActions
    {
        private @PlayerActions m_Wrapper;
        public PlayerActionMapActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_PlayerActionMap_Rotate;
        public InputAction @Launch => m_Wrapper.m_PlayerActionMap_Launch;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerActionMapActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnRotate;
                @Launch.started -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLaunch;
                @Launch.performed -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLaunch;
                @Launch.canceled -= m_Wrapper.m_PlayerActionMapActionsCallbackInterface.OnLaunch;
            }
            m_Wrapper.m_PlayerActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Launch.started += instance.OnLaunch;
                @Launch.performed += instance.OnLaunch;
                @Launch.canceled += instance.OnLaunch;
            }
        }
    }
    public PlayerActionMapActions @PlayerActionMap => new PlayerActionMapActions(this);

    // MenuNavigation
    private readonly InputActionMap m_MenuNavigation;
    private IMenuNavigationActions m_MenuNavigationActionsCallbackInterface;
    private readonly InputAction m_MenuNavigation_Up;
    private readonly InputAction m_MenuNavigation_Down;
    private readonly InputAction m_MenuNavigation_Select;
    public struct MenuNavigationActions
    {
        private @PlayerActions m_Wrapper;
        public MenuNavigationActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_MenuNavigation_Up;
        public InputAction @Down => m_Wrapper.m_MenuNavigation_Down;
        public InputAction @Select => m_Wrapper.m_MenuNavigation_Select;
        public InputActionMap Get() { return m_Wrapper.m_MenuNavigation; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuNavigationActions set) { return set.Get(); }
        public void SetCallbacks(IMenuNavigationActions instance)
        {
            if (m_Wrapper.m_MenuNavigationActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnDown;
                @Select.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_MenuNavigationActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public MenuNavigationActions @MenuNavigation => new MenuNavigationActions(this);
    public interface IPlayerActionMapActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnLaunch(InputAction.CallbackContext context);
    }
    public interface IMenuNavigationActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}
