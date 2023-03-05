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
        protected bool _isShotPossible = true;
        protected TriggerType _triggerType;
        protected Vector3 _moveDirection;
        protected Vector3 _movement;


        [SerializeField]
        protected UnitParams _unitParams;
        [SerializeField]
        protected Animator _animator;
        [SerializeField]
        protected BaseWeapon _weaponClass; 
        [SerializeField]
        protected Transform _weaponTransform;
        [SerializeField]
        protected Transform _projectilesPool; // Пока нужно для контроля, потом убрать


        protected void Start()
        {
            _currentHealth = _unitParams._maxHealth;
        }

        protected  void Update()
        {
            UpdateAnimation();
        }

        protected void UpdateAnimation()
        {
            switch (_actionType)
            {
                case ActionType.Idle:
                    _animator.SetBool("Move", false);
                    _animator.SetBool("Walk", false);
                    break;
                case ActionType.Move:
                    _animator.SetBool("Move", true);
                    break;
                //case ActionType.Shooting:
                //    _animator.SetTrigger("Shoot");
                    //break;
                //case ActionType.Interact:
                //    _animator.SetTrigger("Interact");
                //    break;
                case ActionType.Die:
                    _animator.SetBool("Move", false);
                    _animator.SetTrigger("Die");
                    break;
                //case ActionType.HitReact:
                //    _animator.SetTrigger("HitReact");
                    //break;
                case ActionType.Walk:
                    _animator.SetBool("Walk", true);
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
                //OnShootAnimation();
                _projectile = Instantiate(Resources.Load<GameObject>(_weaponClass.GetProjectile()),
                    weapon.transform.position, weapon.transform.rotation, parent);
                _weaponClass.CallOnShoot();
                _projectile.GetComponent<Projectile>().SideType = _unitParams._sideType;
            }
#if UNITY_EDITOR
            else
            {
                Debug.Log(" -------------- Нет патронов для стрельбы---------------");
            }
#endif
        }


        protected virtual void OnTriggerEnter(Collider other)
        {
            //Debug.Log("OnTriggerEnter");
            if (other.GetComponent<TriggerComponent>() == null) return;

            _triggerType = other.GetComponent<TriggerComponent>().GetTriggerType();

            if(_triggerType == TriggerType.Projectile)
            {
                if (other.GetComponent<Projectile>().SideType != _unitParams._sideType)
                {
                    SetDamage(other.GetComponent<Projectile>().Damage);
                    Destroy(other.gameObject);
                }
            }
        }

        public void SetDamage(float damage)
        {
            _currentHealth -= damage;
            _animator.SetTrigger("HitReact");
            if (_currentHealth <= 0) Death();
        }

        protected virtual void Death()
            => _animator.SetTrigger("Die");

        //public void OnDestroyNPC()
        //{
        //    if (GetComponent<BaseNPC>()!= null) Destroy(gameObject);
        //}

        public void RestoreHealth(float restore)
        {
            _currentHealth += restore;
            if (_currentHealth > _unitParams._maxHealth) _currentHealth = _unitParams._maxHealth;
        }
    }
}
