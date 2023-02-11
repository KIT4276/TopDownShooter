using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class TriggerComponent : MonoBehaviour
    {
        [SerializeField]
        private TriggerType triggerType;

        public TriggerType GetTriggerType() => triggerType;

    }
}
