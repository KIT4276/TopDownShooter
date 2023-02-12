using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class TriggerComponent : MonoBehaviour
    {
        private Collider _collider;

        [SerializeField]
        private float _value;
        [SerializeField]
        private TriggerType triggerType;

        public float GetValue() => _value;
        

        public TriggerType GetTriggerType() => triggerType;

        private void Start()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = true;
        }
    }
}
