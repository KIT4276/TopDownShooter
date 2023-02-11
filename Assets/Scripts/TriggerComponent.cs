using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class TriggerComponent : MonoBehaviour
    {
        private Collider _collider;

        [SerializeField]
        private float value;

        public float GetValue() => value;

        [SerializeField]
        private TriggerType triggerType;

        public TriggerType GetTriggerType() => triggerType;

        private void Start()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = true;
        }
    }
}
