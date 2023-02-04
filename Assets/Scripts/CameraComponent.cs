using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class CameraComponent : MonoBehaviour
    {
        private Transform _target;

        [SerializeField]
        private float _speed = 2f;

        private void Start()
        {
            _target = transform.parent.GetComponent<Unit>().transform;
            transform.parent = null;
        }

        private void LateUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, _speed * Time.deltaTime);
            //transform.position = _target.position;
        }
    }
}
