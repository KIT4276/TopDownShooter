using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TDS
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NPC_Test : Unit
    {
        //  од врага - тупицы
        private float _distance;

        [SerializeField]
        private NavMeshAgent _navMeshAgent;
        //[SerializeField]
        //private Animator _animator;
        [SerializeField]
        private Transform _player; //------------------------------------------придЄтс€ использовать FindObject
        [SerializeField]
        private Transform _protectedObject;
        [SerializeField]
        private float _detectionDistance = 15f;
        [SerializeField]
        private float _attackDistance = 10f;
        [Space, SerializeField]
        private float _timeToDstruction = 6;

        [Space, SerializeField]
        private AISttateType _aISttateType;

        private void Awake()
        {
            _navMeshAgent.enabled = true;
        }

        private void FixedUpdate()
        {
            if (_aISttateType == AISttateType.Seek) SeekMMove();
            //Debug.Log(_currentHealth);
        }

        private void SeekMMove()
        {
            transform.LookAt(_navMeshAgent.destination);
            _distance = Vector3.Distance(_player.position, transform.position);

            // очень сомнительна€ конструкци€
            if (_distance >= _detectionDistance)
            {
                _navMeshAgent.destination = _protectedObject.position;
                if (_distance > _navMeshAgent.stoppingDistance)
                {
                    _actionType = ActionType.Move;
                }
                else
                {
                    _actionType = ActionType.Idle; // ------------------------почему сюда не попадает?????????????
                }
            }
            if (_distance <= _navMeshAgent.stoppingDistance)
            {
                _actionType = ActionType.Idle;
                //Debug.Log("4");
            }
            if (_distance <= _detectionDistance)
            {
                _navMeshAgent.destination = _player.position;
                _actionType = ActionType.Move;
                //Debug.Log("5");
            }
            if (_distance <= _attackDistance)
            {
                Attack();
            }
        }

        public void DestroyNPC() => StartCoroutine(DestroyNPCCoroutine());

        private IEnumerator DestroyNPCCoroutine()
        {
            _navMeshAgent.destination = transform.position; // --------------------------------------почему он не останавливаетс€?
            _animator.SetBool("Move", false);
            yield return new WaitForSeconds(_timeToDstruction);
            Destroy(gameObject);
        }

        private void Attack()
        {
            //todo
            _actionType = ActionType.Shooting;
        }
    }
}
