using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class UnitParams : MonoBehaviour
    {
        [Range(0f, 10f)]
        public float MoveSpeed = 1f;
        public SideType _sideType;
        public float _maxHealth = 20f;
        public float _stopDistance = 1;
        public float _rotateSpeed = 3f;
    }
}
