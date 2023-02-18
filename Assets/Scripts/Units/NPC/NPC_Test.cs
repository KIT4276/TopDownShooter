using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TDS
{
    
    public class NPC_Test : BaseNPC
    {
        // ��� ����� - ������
        

        [SerializeField]
        private Transform _protectedObject;

        protected override void FixedUpdate()
        {
            // todo start base FixedUpdate 
            if (_aISttateType == AISttateType.Seek) SeekMMove();  // � ����������� if  ������
            //Debug.Log(_currentHealth);
        }

        private void SeekMMove()
        {
            
            //_distance = Vector3.Distance(_player.position, transform.position);

            // ����� ������������ �����������
            if (_distance > _detectionDistance)
            {
                _navMeshAgent.destination = _protectedObject.position;

                if (_distance > _navMeshAgent.stoppingDistance)
                {
                    _actionType = ActionType.Move;
                }
                else
                {
                    _actionType = ActionType.Idle; // ------------------------������ ���� �� ��������?????????????
                }
            }
            else 
            {
                _navMeshAgent.destination = _player.position;

                _actionType = ActionType.Move;
                //Debug.Log("5");
                
                if (_distance <= _attackDistance)
                {
                    Attack();
                }
                if (_distance <= _navMeshAgent.stoppingDistance)
                {
                    _actionType = ActionType.Idle;
                    //Debug.Log("4");
                }
            }
        }

        //public void DestroyNPC() => StartCoroutine(DestroyNPCCoroutine());

        //private IEnumerator DestroyNPCCoroutine()
        //{
        //    _navMeshAgent.destination = transform.position; // --------------------------------------������ �� �� ���������������?
        //    _animator.SetBool("Move", false);
        //    yield return new WaitForSeconds(_timeToDstruction);
        //    Destroy(gameObject);
        //}

        
    }
}
