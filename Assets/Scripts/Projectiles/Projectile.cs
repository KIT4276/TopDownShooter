using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class Projectile : MonoBehaviour
    {
        private float _distance;
        private Vector3 _startPos;
        //private Vector3 _target;
        private PlayerInput _playerInput;

        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _lifeTime = 5;
        [SerializeField]
        private float _minDamage;
        [SerializeField]
        private float _maxDamage;
        [SerializeField]
        private ProjectileType _projectileType;
        [SerializeField, Tooltip("Расстояние перехода от ближней атаки к дальней")]
        private float _transitDistance;

        public float Damage { get; private set; }

        public SideType SideType { get; set; }

        private void Start()
        {
            StartCoroutine(DestroyProjectile());
            _startPos = transform.position;
            _playerInput = FindObjectOfType<PlayerInput>();
        }

        private void Update()
        {
            MoveProjectile();
        }


        private void MoveProjectile()
        {
            transform.position += _speed * Time.deltaTime * transform.forward;
            _distance = Vector3.Distance(_startPos, transform.position);

            UpdateProjectileProperties();
        }

        private void UpdateProjectileProperties()
        {
            if (_projectileType == ProjectileType.Тear)
            {
                if (_distance < _transitDistance) Damage = _maxDamage;
                else Damage = _minDamage;
            }

            if (_projectileType == ProjectileType.Further)
            {
                if (_distance <= _transitDistance) Damage = _minDamage;
                else Damage = _maxDamage;
            }
        }

        private IEnumerator DestroyProjectile()
        {
            yield return new WaitForSeconds(_lifeTime);
            Destroy(gameObject);
        }
    }
}
