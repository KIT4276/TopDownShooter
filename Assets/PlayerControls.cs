//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/PlayerControls.inputactions
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

namespace TDS
{
    public partial class @PlayerControls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerInputMapp"",
            ""id"": ""1e40a0be-9e58-4f77-9d54-a2a58c875592"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""25933350-a4cd-4be4-bee5-66f368684aad"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""cf0577b8-d52d-4abb-ac06-72d414aa4d0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""8521384e-34d6-4d5e-b62b-ecda13e76fba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aiming"",
                    ""type"": ""Value"",
                    ""id"": ""63e9440b-295c-4bbc-9ed6-a5b45efc7b3a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8e3fc8b7-0ac9-4e91-9394-438279e001b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""WeaponSwitch"",
                    ""type"": ""Button"",
                    ""id"": ""d2f394e1-367f-4e33-b409-d491e31b1226"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""0f876419-ffbd-49eb-8475-b7442e2ef8ea"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""179d7fe8-40f1-42c3-a20f-2fc20b3d6ab1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""176e6f33-d8da-4b3b-9ed2-ad48eeae890f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4760ee23-0e71-4f3f-a30b-5f8e24a62848"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""87647b0c-b7f3-487e-a6f5-88809635cc7d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b37927b1-ebfa-4157-84bd-68b8b2c8b3e7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d35e7e6d-9b19-4ffa-9f3a-b4f715aef591"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31c0512c-b7e2-4b65-a50b-d71b0bccc4a9"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a437ecd8-6de5-4ef5-bbe6-a0f87736ae24"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8fdd2f84-ffad-426c-9532-c5c3c2fea8e7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeaponSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PlayerInputMapp
            m_PlayerInputMapp = asset.FindActionMap("PlayerInputMapp", throwIfNotFound: true);
            m_PlayerInputMapp_Move = m_PlayerInputMapp.FindAction("Move", throwIfNotFound: true);
            m_PlayerInputMapp_Attack = m_PlayerInputMapp.FindAction("Attack", throwIfNotFound: true);
            m_PlayerInputMapp_Action = m_PlayerInputMapp.FindAction("Action", throwIfNotFound: true);
            m_PlayerInputMapp_Aiming = m_PlayerInputMapp.FindAction("Aiming", throwIfNotFound: true);
            m_PlayerInputMapp_Jump = m_PlayerInputMapp.FindAction("Jump", throwIfNotFound: true);
            m_PlayerInputMapp_WeaponSwitch = m_PlayerInputMapp.FindAction("WeaponSwitch", throwIfNotFound: true);
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

        // PlayerInputMapp
        private readonly InputActionMap m_PlayerInputMapp;
        private IPlayerInputMappActions m_PlayerInputMappActionsCallbackInterface;
        private readonly InputAction m_PlayerInputMapp_Move;
        private readonly InputAction m_PlayerInputMapp_Attack;
        private readonly InputAction m_PlayerInputMapp_Action;
        private readonly InputAction m_PlayerInputMapp_Aiming;
        private readonly InputAction m_PlayerInputMapp_Jump;
        private readonly InputAction m_PlayerInputMapp_WeaponSwitch;
        public struct PlayerInputMappActions
        {
            private @PlayerControls m_Wrapper;
            public PlayerInputMappActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_PlayerInputMapp_Move;
            public InputAction @Attack => m_Wrapper.m_PlayerInputMapp_Attack;
            public InputAction @Action => m_Wrapper.m_PlayerInputMapp_Action;
            public InputAction @Aiming => m_Wrapper.m_PlayerInputMapp_Aiming;
            public InputAction @Jump => m_Wrapper.m_PlayerInputMapp_Jump;
            public InputAction @WeaponSwitch => m_Wrapper.m_PlayerInputMapp_WeaponSwitch;
            public InputActionMap Get() { return m_Wrapper.m_PlayerInputMapp; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerInputMappActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerInputMappActions instance)
            {
                if (m_Wrapper.m_PlayerInputMappActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnMove;
                    @Attack.started -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnAttack;
                    @Attack.performed -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnAttack;
                    @Attack.canceled -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnAttack;
                    @Action.started -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnAction;
                    @Action.performed -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnAction;
                    @Action.canceled -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnAction;
                    @Aiming.started -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnAiming;
                    @Aiming.performed -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnAiming;
                    @Aiming.canceled -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnAiming;
                    @Jump.started -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnJump;
                    @WeaponSwitch.started -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnWeaponSwitch;
                    @WeaponSwitch.performed -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnWeaponSwitch;
                    @WeaponSwitch.canceled -= m_Wrapper.m_PlayerInputMappActionsCallbackInterface.OnWeaponSwitch;
                }
                m_Wrapper.m_PlayerInputMappActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Attack.started += instance.OnAttack;
                    @Attack.performed += instance.OnAttack;
                    @Attack.canceled += instance.OnAttack;
                    @Action.started += instance.OnAction;
                    @Action.performed += instance.OnAction;
                    @Action.canceled += instance.OnAction;
                    @Aiming.started += instance.OnAiming;
                    @Aiming.performed += instance.OnAiming;
                    @Aiming.canceled += instance.OnAiming;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @WeaponSwitch.started += instance.OnWeaponSwitch;
                    @WeaponSwitch.performed += instance.OnWeaponSwitch;
                    @WeaponSwitch.canceled += instance.OnWeaponSwitch;
                }
            }
        }
        public PlayerInputMappActions @PlayerInputMapp => new PlayerInputMappActions(this);
        public interface IPlayerInputMappActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
            void OnAction(InputAction.CallbackContext context);
            void OnAiming(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnWeaponSwitch(InputAction.CallbackContext context);
        }
    }
}
