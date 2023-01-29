using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TDS
{
    [RequireComponent (typeof(UnitParams))]
    public class PlayerInput : Unit
    {
        private PlayerControls _controls;
        private Vector2 _direction;

        private void Awake()
        {
            _controls = new PlayerControls();
        }

        private void Update()
        {
            _direction = _controls.PlayerInputMapp.Move.ReadValue<Vector2>();
            _movement = new Vector3(_direction.x, 0f, _direction.y);
        }

        private void OnEnable()
           => _controls.PlayerInputMapp.Enable();

        private void OnDisable()
            => _controls.PlayerInputMapp.Disable();

        private void OnDestroy()
        {
            _controls.Dispose();
        }
    }
}
