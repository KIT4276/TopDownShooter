using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace TDS
{
    [RequireComponent(typeof(NavMeshAgent), typeof(BaseWeapon))]
    public class BaseNPC : Unit
    {
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

        protected virtual void Awake()
        {
            _navMeshAgent.enabled = true;
        }

        protected virtual void FixedUpdate()
        {
            _distance = Vector3.Distance(_player.position, transform.position);

            if (_distance <= _detectionDistance)
            {
                if (_canShot) StartCoroutine(HoldShot());
                transform.LookAt(_player);
            }
        }

        protected void Attack()
        {
            //todo
            
            ToShoot(_projectilesPool, _weaponTransform);
            _actionType = ActionType.Shooting;
        }

        protected IEnumerator HoldShot()
        {
            _canShot = false;
            yield return new WaitForSeconds(_shotDlay);
            
            Attack();
            _canShot = true;
        }

        public void DestroyNPC() => StartCoroutine(DestroyNPCCoroutine());

        private IEnumerator DestroyNPCCoroutine()
        {
            _navMeshAgent.destination = transform.position; // --------------------------------------почему он не останавливается?
            _animator.SetBool("Move", false);
            
            yield return new WaitForSeconds(_timeToDstruction);
            GameManager._instance.AddExperience(_XPForKilling);
            Destroy(gameObject);
        }
    }
}
