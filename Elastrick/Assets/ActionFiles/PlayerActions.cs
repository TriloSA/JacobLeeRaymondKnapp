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
            ""name"": ""Player1Actions"",
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
                },
                {
                    ""name"": ""UsePowerUp"",
                    ""type"": ""Button"",
                    ""id"": ""4da91bc9-3171-4835-8755-dbe1f2250606"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotatePowerUp"",
                    ""type"": ""Value"",
                    ""id"": ""5dad930e-9925-419c-9681-8aa609214886"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
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
                },
                {
                    ""name"": """",
                    ""id"": ""a0bd1215-780b-4be2-ac63-88b35c8dfb9b"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UsePowerUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b1ccd08-4d08-4948-ad63-30ffe58e9535"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotatePowerUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuNavigation"",
            ""id"": ""fafe1c70-b167-4f1c-bf2a-08286c6f7077"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Value"",
                    ""id"": ""578d4c50-c767-4bcf-815c-db01dd88225e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Value"",
                    ""id"": ""f4e4b482-0418-46ce-a238-8853703ce81e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""7e51fbf1-bff3-46f8-8626-2798c3f02048"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b3a81560-421c-455c-aa52-16e6fc00e3a7"",
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
                    ""id"": ""2f42677b-aaa7-4e44-ade8-82da49745991"",
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
                    ""id"": ""3c740c55-b8e8-4583-a0b9-b1ada1c84a22"",
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
        // Player1Actions
        m_Player1Actions = asset.FindActionMap("Player1Actions", throwIfNotFound: true);
        m_Player1Actions_Rotate = m_Player1Actions.FindAction("Rotate", throwIfNotFound: true);
        m_Player1Actions_Launch = m_Player1Actions.FindAction("Launch", throwIfNotFound: true);
        m_Player1Actions_UsePowerUp = m_Player1Actions.FindAction("UsePowerUp", throwIfNotFound: true);
        m_Player1Actions_RotatePowerUp = m_Player1Actions.FindAction("RotatePowerUp", throwIfNotFound: true);
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

    // Player1Actions
    private readonly InputActionMap m_Player1Actions;
    private IPlayer1ActionsActions m_Player1ActionsActionsCallbackInterface;
    private readonly InputAction m_Player1Actions_Rotate;
    private readonly InputAction m_Player1Actions_Launch;
    private readonly InputAction m_Player1Actions_UsePowerUp;
    private readonly InputAction m_Player1Actions_RotatePowerUp;
    public struct Player1ActionsActions
    {
        private @PlayerActions m_Wrapper;
        public Player1ActionsActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_Player1Actions_Rotate;
        public InputAction @Launch => m_Wrapper.m_Player1Actions_Launch;
        public InputAction @UsePowerUp => m_Wrapper.m_Player1Actions_UsePowerUp;
        public InputAction @RotatePowerUp => m_Wrapper.m_Player1Actions_RotatePowerUp;
        public InputActionMap Get() { return m_Wrapper.m_Player1Actions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1ActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1ActionsActions instance)
        {
            if (m_Wrapper.m_Player1ActionsActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_Player1ActionsActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_Player1ActionsActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_Player1ActionsActionsCallbackInterface.OnRotate;
                @Launch.started -= m_Wrapper.m_Player1ActionsActionsCallbackInterface.OnLaunch;
                @Launch.performed -= m_Wrapper.m_Player1ActionsActionsCallbackInterface.OnLaunch;
                @Launch.canceled -= m_Wrapper.m_Player1ActionsActionsCallbackInterface.OnLaunch;
                @UsePowerUp.started -= m_Wrapper.m_Player1ActionsActionsCallbackInterface.OnUsePowerUp;
                @UsePowerUp.performed -= m_Wrapper.m_Player1ActionsActionsCallbackInterface.OnUsePowerUp;
                @UsePowerUp.canceled -= m_Wrapper.m_Player1ActionsActionsCallbackInterface.OnUsePowerUp;
                @RotatePowerUp.started -= m_Wrapper.m_Player1ActionsActionsCallbackInterface.OnRotatePowerUp;
                @RotatePowerUp.performed -= m_Wrapper.m_Player1ActionsActionsCallbackInterface.OnRotatePowerUp;
                @RotatePowerUp.canceled -= m_Wrapper.m_Player1ActionsActionsCallbackInterface.OnRotatePowerUp;
            }
            m_Wrapper.m_Player1ActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Launch.started += instance.OnLaunch;
                @Launch.performed += instance.OnLaunch;
                @Launch.canceled += instance.OnLaunch;
                @UsePowerUp.started += instance.OnUsePowerUp;
                @UsePowerUp.performed += instance.OnUsePowerUp;
                @UsePowerUp.canceled += instance.OnUsePowerUp;
                @RotatePowerUp.started += instance.OnRotatePowerUp;
                @RotatePowerUp.performed += instance.OnRotatePowerUp;
                @RotatePowerUp.canceled += instance.OnRotatePowerUp;
            }
        }
    }
    public Player1ActionsActions @Player1Actions => new Player1ActionsActions(this);

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
    public interface IPlayer1ActionsActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnLaunch(InputAction.CallbackContext context);
        void OnUsePowerUp(InputAction.CallbackContext context);
        void OnRotatePowerUp(InputAction.CallbackContext context);
    }
    public interface IMenuNavigationActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}
