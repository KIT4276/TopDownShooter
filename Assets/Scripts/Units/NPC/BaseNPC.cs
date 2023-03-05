using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace TDS
{
    [RequireComponent(typeof(NavMeshAgent), typeof(BaseWeapon))]
    public class BaseNPC : Unit
    {
        private bool _isAlive = true;
        protected float _distance;
        private bool _canShot = true;

        [SerializeField]
        protected NavMeshAgent _navMeshAgent;

        [Space, SerializeField]
        protected Transform _player; //------------------------------------------придётся использовать FindObject
        [SerializeField]
        protected float _detectionDistance = 15f;
        [SerializeField]
        protected float _attackDistance = 10f;
        [SerializeField]
        protected float _timeToDstruction = 6;
        [SerializeField]
        protected float _shotDlay;
        [SerializeField]
        private int _XPForKilling = 1;


        [Space, SerializeField]
        protected AISttateType _aISttateType;

        public float GetCurrentHealth() => _currentHealth;

        public float GetMaxHealth() => _unitParams._maxHealth;

        protected virtual void Awake()
            => _navMeshAgent.enabled = true;

        protected virtual void FixedUpdate()
        {
            _distance = Vector3.Distance(_player.position, transform.position);


            if (_distance <= _detectionDistance)
            {
                if (_canShot) StartCoroutine(HoldShot());
                transform.LookAt(_player);
            }
        }

        protected override void Death()
        {
            base.Death();
            StartCoroutine(DestroyNPCRoutine());
        }

        protected void Attack()
        {
            if (_isAlive)
            {
                ToShoot(_projectilesPool, _weaponTransform);
            }
        }

        protected IEnumerator HoldShot()
        {
            _canShot = false;
            yield return new WaitForSeconds(_shotDlay);
            
            Attack();
            _canShot = true;
        }

        //public void DestroyNPC() => StartCoroutine(DestroyNPCRoutine());

        private IEnumerator DestroyNPCRoutine()
        {
            _isAlive = false;
            _actionType = ActionType.Die;
            _navMeshAgent.isStopped = true;

            
            yield return new WaitForSeconds(_timeToDstruction);
            GameManager._instance.AddExperience(_XPForKilling);
            Destroy(gameObject);
        }
    }
}
