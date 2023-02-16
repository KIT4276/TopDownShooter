using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class NPC_Patrol : BaseNPC
    {
        [SerializeField]
        private float _patrolradius;

        protected override void Awake()
        {

        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            _navMeshAgent.destination = RandomPosition();
        }

        private Vector3 RandomPosition() => new Vector3(Random.Range(0, _patrolradius), transform.position.y, Random.Range(0, _patrolradius));
    }
}
