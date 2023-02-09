using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TDS
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NPC_Test : Unit
    {
        // ��� ����� - ������
        private float _distance;

        [SerializeField]
        private NavMeshAgent _navMeshAgent;
        //[SerializeField]
        //private Animator _animator;
        [SerializeField]
        private Transform _player;
        [SerializeField]
        private Transform _protectedObject;
        [SerializeField]
        private float _detectionDistance = 15f;
        [SerializeField]
        private float _attackDistance = 10f;

        private void Awake()
        {
            _navMeshAgent.enabled = true;
        }

        private void FixedUpdate()
        {
            transform.LookAt(_navMeshAgent.destination);
            _distance = Vector3.Distance(_player.position, transform.position);
            

            if (_distance >= _detectionDistance)
            {
                _navMeshAgent.destination = _protectedObject.position;
                if(_distance > _navMeshAgent.stoppingDistance)
                {
                    _actionType = ActionType.Move;
                }
                else
                {
                    _actionType = ActionType.Idle; // ------------------------������ ���� �� ��������?????????????
                }
            }
            if (_distance <= _navMeshAgent.stoppingDistance)
            {
                _actionType = ActionType.Idle;
                Debug.Log("4");
            }
            if (_distance <= _detectionDistance)
            {
                _navMeshAgent.destination = _player.position;
                _actionType = ActionType.Move;
                Debug.Log("5");
            }
            if (_distance <= _attackDistance)
            {
                Attack();
            }
        }

        private void Attack()
        {
            //todo
            _actionType = ActionType.Shooting;
        }
    }
}
