using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TDS
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NPC_Test : MonoBehaviour
    {
        // Код врага - тупицы
        private float _distance;

        [SerializeField]
        private NavMeshAgent _navMeshAgent;
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private Transform _player;
        [SerializeField]
        private float _detectionDistance = 20f;
        [SerializeField]
        private float _stopDistance = 5f;
        [SerializeField]
        private float _attackDistance = 8f;

        private void Update()
        {
            transform.LookAt(_player.position);
            _distance = Vector3.Distance(_player.position, transform.position);

            if (_distance > _detectionDistance || _distance <= _stopDistance)
            {
                _navMeshAgent.enabled = false;
                _animator.SetBool("Moving", false);
            }
            if (_distance <= _detectionDistance)
            {
                _navMeshAgent.enabled = true;
                _navMeshAgent.destination = _player.position;
                _animator.SetBool("Moving", true);
            }
            if (_distance <= _attackDistance)
            {
                _animator.SetTrigger("Shoot");
            }
        }
    }
}
