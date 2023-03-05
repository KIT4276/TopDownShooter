using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TDS
{
    [RequireComponent (typeof(UnitParams), typeof(Weapon))]
    public class PlayerInput : Unit
    {
        private PlayerControls _controls;
        
        private Vector2 _direction;

        private Vector3 _inputVector;
        private Vector3 _animationVector;
        private Vector3 _targetForLookAt;
        private int _layerMask;
        private RaycastHit _hit;
        private Ray _ray;

        [Space, SerializeField]
        private Transform _player;
        [SerializeField]
        private Text _healthText;
        [SerializeField]
        private Inventory _inventory;
        [SerializeField]
        private Camera _camera;

        private void Awake()
        {
            _controls = new PlayerControls();
            _controls.PlayerInputMapp.Attack.performed += Fire;
            
        }

        private void FixedUpdate()
        {
            _direction = _controls.PlayerInputMapp.Move.ReadValue<Vector2>();
            _movement = new Vector3(_direction.x, 0f, _direction.y).normalized;


            _healthText.text = _currentHealth.ToString();

            if (Fader.IsFading) return;
            OnMove();
            OnRotate();
        }

        private void OnMove()
        {
            transform.position += _movement * _unitParams.MoveSpeed * Time.deltaTime;
            if (_movement != new Vector3(0f, 0f, 0f))
            {
                if (GameManager.IsOnBase)
                {
                    _weaponClass.PutAwayWeapon();
                    _actionType = ActionType.Walk;
                }
                else _actionType = ActionType.Move;
            }
            else _actionType = ActionType.Idle;
        }

        private void Fire(InputAction.CallbackContext obj)
        {
            if (Fader.IsFading) return;
            ToShoot(_projectilesPool, _weaponTransform);
        }

        private void OnRotate()
        {
            _layerMask = 1 << 6;
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, 1000, _layerMask))
            {
                _targetForLookAt = new Vector3(_hit.point.x, transform.position.y, _hit.point.z);

                _inputVector = (Vector3.forward * _direction.y) + (Vector3.right * _direction.x);

                _animationVector = _player.transform.InverseTransformDirection(_inputVector);

                _animator.SetFloat("SideMove", _animationVector.x);
                _animator.SetFloat("ForvardMove", _animationVector.z);
            }

            _player.LookAt(_targetForLookAt);
        }


        protected override void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<TriggerComponent>() == null) return;
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
                    if (_currentHealth > _unitParams._maxHealth) _currentHealth = _unitParams._maxHealth;
                    Destroy(other.gameObject);
                    break;
                case TriggerType.Docs:
                    _inventory.AddDocs(other.GetComponent<Transform>().name);
                    Destroy(other.gameObject);
                    break;
                case TriggerType.Artifact:
                    GameManager._instance.AddExperience((int)other.GetComponent<TriggerComponent>().GetValue());
                    GameManager._instance.ArtifactCapture();
                    Destroy(other.gameObject);
                    break;
                case TriggerType.LeaveTheBase:
                    GameManager._instance.MovingToLocation();
                    _actionType = ActionType.Idle;
                    break;
                default:
                    break;
            }
        }

        protected override void Death()
            => base.Death();

        public void StopAnimation()
            => _animator.enabled = false; // -----------------------------todo stop animation more carefully

        public void ReternWeapon()
            => _weaponClass.ReternTearWeapon();


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
