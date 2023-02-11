using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class Ammo : MonoBehaviour
    {
        [SerializeField]
        private float value;

        private Collider _collider;

        public float GetValue() => value;

        private void Start()
        {
            _collider = GetComponent<Collider>();
            _collider.isTrigger = true;
        }
    }
}
