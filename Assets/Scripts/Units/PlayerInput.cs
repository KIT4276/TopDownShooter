using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace TDS
{
    [RequireComponent (typeof(UnitParams), typeof(Weapon))]
    public class PlayerInput : Unit
    {
        private PlayerControls _controls;
        private Camera _camera;
        private Vector2 _direction;
        private Vector3 _screenMousePosition;
        private Vector3 _worldMmousePosition;
        private Vector3 _targetForLookAt;
        //private Vector3 _movement;

        
        [SerializeField]
        private Text _healthText;
        [SerializeField]
        private Inventory _inventory;

        private void Awake()
        {
            _controls = new PlayerControls();
            _controls.PlayerInputMapp.Attack.performed += Fire;
            _camera = Camera.main;
        }


        private void FixedUpdate()
        {
            _direction = _controls.PlayerInputMapp.Move.ReadValue<Vector2>();
            _movement = new Vector3(_direction.x, 0f, _direction.y).normalized;

            //var norm = _targetForLookAt.normalized;

            //_moveDirection = new Vector3(_movement.x - norm.x, 0f, _movement.y - norm.z);// тут исправить
            //_moveDirection = _movement - norm;


            OnMove();
            OnRotate();
            _healthText.text = _currentHealth.ToString();
        }

        private void OnMove()
        {
            transform.position += _movement * unitParams.MoveSpeed * Time.deltaTime;
            if (_movement != new Vector3(0f, 0f, 0f)) _actionType = ActionType.Move;
            else _actionType = ActionType.Idle;
        }

        private void Fire(InputAction.CallbackContext obj)
        {
            ToShoot(_projectilesPool, _weaponTransform);
        }

        private void OnRotate()
        {
            _screenMousePosition = _controls.PlayerInputMapp.Aiming.ReadValue<Vector2>();
            _worldMmousePosition = _camera.ScreenToWorldPoint(new Vector3(_screenMousePosition.x, _screenMousePosition.y, _camera.transform.position.y));
            _targetForLookAt = new Vector3(_worldMmousePosition.x, transform.position.y, _worldMmousePosition.z);

            transform.LookAt(_targetForLookAt);
        }

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            switch (_triggerType)
            {
                case TriggerType.Ammo:
                    _weaponClass.AddAmmo(other.GetComponent<TriggerComponent>().GetValue(), 
                        other.GetComponent<TriggerComponent>().GetProjectileType());
                    Destroy(other.gameObject);
                    break;
                case TriggerType.AidKit:
                    _currentHealth += other.GetComponent<TriggerComponent>().GetValue();
                    if (_currentHealth > unitParams._maxHealth) _currentHealth = unitParams._maxHealth;
                    Destroy(other.gameObject);
                    break;
                case TriggerType.Docs:
                    _inventory.AddDocs(other.GetComponent<Transform>().name);
                    Destroy(other.gameObject);
                    break;
                case TriggerType.Artifact:
                    GameManager.self.AddExperience((int)other.GetComponent<TriggerComponent>().GetValue());
                    GameManager.self.ArtifactCapture();
                    Destroy(other.gameObject);
                    break;
                default:
                    break;
            }
        }

        //public Vector3 GetTargetForLookAt() => _targetForLookAt;

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
