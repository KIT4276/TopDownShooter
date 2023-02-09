using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    [RequireComponent(typeof(UnitParams))] 
    public class Unit : MonoBehaviour
    {
        private float _maxHealth;

        protected float _currentHealth;
        
        protected GameObject _projectile;
        protected ActionType _actionType;


        [SerializeField]
        protected UnitParams unitParams;
        [SerializeField]
        protected Animator _animator;

        protected void Start()
        {
            _maxHealth = unitParams.MaxHealth;
            _currentHealth = _maxHealth;
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
            OnShootAnimation();
            string path = "Prefabs/“earProjectile";// ÔÓÍ‡ Ú‡Í
            _projectile = Instantiate(Resources.Load<GameObject>(path), weapon.transform.position, weapon.transform.rotation, parent);
        }

        //protected void OnMoveAnimation()
        //{
        //    if() _animator.SetBool("Moving", true);
            
        //}

        //public void StopMoving()
        //{
        //    _animator.SetBool("Moving", false);
            
        //}

        private void OnShootAnimation()
        {
            _animator.SetTrigger("Shoot");
        }

        public void SetDamage(float damage)
            => _currentHealth -= damage;

        public void RestoreHealth(float restore)
        {
            _currentHealth += restore;
            if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;
        }
    }
}
