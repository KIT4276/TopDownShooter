using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    [RequireComponent(typeof(UnitParams))] 
    public class Unit : MonoBehaviour
    {
        protected float _currentHealth;
        
        protected GameObject _projectile;
        protected ActionType _actionType;
        protected bool _isShotPossible;


        [SerializeField]
        protected UnitParams unitParams;
        [SerializeField]
        protected Animator _animator;
        [SerializeField]
        protected Weapon _weaponClass;

        protected void Start()
        {
            _currentHealth = unitParams._maxHealth;
        }

        protected  void Update()
        {
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            switch (_actionType)
            {
                case ActionType.Idle:
                    _animator.SetBool("Move", false);
                    break;
                case ActionType.Move:
                    _animator.SetBool("Move", true);
                    break;
                case ActionType.Shooting:
                    _animator.SetTrigger("Shoot");
                    break;
                case ActionType.Interact:
                    _animator.SetTrigger("Interact");
                    break;
                case ActionType.Die:
                    _animator.SetTrigger("Die");
                    break;
                case ActionType.HitReact:
                    _animator.SetTrigger("HitReact");
                    break;
                default:
                    break;
            }
        }

        protected void ToShoot(Transform parent, Transform weapon)
        {
            _isShotPossible = _weaponClass.GetAbilityToShoot();

            if (_isShotPossible)
            {
                OnShootAnimation();
                _projectile = Instantiate(Resources.Load<GameObject>(_weaponClass.GetProjectile()),
                    weapon.transform.position, weapon.transform.rotation, parent);
                _weaponClass.CallOnShoot();
            }
#if UNITY_EDITOR
            else
            {
                Debug.Log(" -------------- Нет патронов для стрельбы---------------");
            }
#endif
        }

        private void OnShootAnimation()
        {
            _animator.SetTrigger("Shoot");
        }

        protected void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter");

            switch (other.GetComponent<TriggerComponent>().GetTriggerType())
            {
                case TriggerType.Non:
                    break;
                case TriggerType.Ammo:
                    _weaponClass.AddAmmo(other.GetComponent<Ammo>().GetValue());
                    Destroy(other.gameObject);
                    break;
                case TriggerType.Projectile:
                    _currentHealth -= other.GetComponent<Projectile>().Damage;
                    break;
                default:
                    break;
            }
        }

        public void SetDamage(float damage)
            => _currentHealth -= damage;

        public void RestoreHealth(float restore)
        {
            _currentHealth += restore;
            if (_currentHealth > unitParams._maxHealth) _currentHealth = unitParams._maxHealth;
        }
    }
}
