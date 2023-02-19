using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class NPC_Patrol : BaseNPC
    {
        private Vector3 _startPosition;

        [SerializeField]
        private float _patrolradius = 8;
        [SerializeField]
        private float _changeDirectionTime = 4;

        protected override void Awake()
        {
            _startPosition = transform.position;
            _actionType = ActionType.Move;
            StartCoroutine(ChangeDirection());
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        private Vector3 RandomPosition()
        {
            return new Vector3
            (Random.Range(_startPosition.x, _startPosition.x + _patrolradius), _startPosition.y, 
            Random.Range(_startPosition.z, _startPosition.z + _patrolradius));
        }
        private IEnumerator ChangeDirection()
        {
            while (true)
            {
                yield return new WaitForSeconds(_changeDirectionTime);
                _navMeshAgent.destination = RandomPosition();
            }
        }
    }
}
