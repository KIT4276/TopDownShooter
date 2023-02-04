using System;
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
        private Camera _camera;
        private Vector2 _direction;
        private Vector3 _screenMousePosition;
        private Vector3 _worldMmousePosition;
        private Vector3 _targetForLookAt;

        [SerializeField]
        private Transform _weapon; // Пока так
        [SerializeField]
        private Transform _projectilesPool; // Пока нужно для контроля, потом убрать

        private void Awake()
        {
            _controls = new PlayerControls();
            _controls.PlayerInputMapp.Attack.performed += Fire;
            _camera = Camera.main;
        }

        private void Fire(InputAction.CallbackContext obj)
        {
            ToShoot(_projectilesPool, _weapon);
        }

        private void Update()
        {
            _direction = _controls.PlayerInputMapp.Move.ReadValue<Vector2>();
            _movement = new Vector3(_direction.x, 0f, _direction.y);

            OnRotate();
        }

        private void OnRotate()
        {
            _screenMousePosition = _controls.PlayerInputMapp.Aiming.ReadValue<Vector2>();
            _worldMmousePosition = _camera.ScreenToWorldPoint(new Vector3(_screenMousePosition.x, _screenMousePosition.y, _camera.transform.position.y));
            _targetForLookAt = new Vector3(_worldMmousePosition.x, transform.position.y, _worldMmousePosition.z);
            
            transform.LookAt(_targetForLookAt);
        }


        private void OnEnable()
           => _controls.PlayerInputMapp.Enable();

        private void OnDisable()
            => _controls.PlayerInputMapp.Disable();

        private void OnDestroy()
        {
            _controls.PlayerInputMapp.Attack.performed -= Fire;
            _controls.Dispose();
        }
    }
}
