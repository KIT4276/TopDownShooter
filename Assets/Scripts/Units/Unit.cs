using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class Unit : MonoBehaviour
    {
        private float _maxHealth;

        protected float _currentHealth;
        protected bool _isMoving;
        protected bool _inAnimation; //  --------------------------todo _animator
        protected Vector3 _movement;
        protected GameObject _projectile;


        [SerializeField]
        protected UnitParams unitParams;

        protected void Start()
        {
            _maxHealth = unitParams.MaxHealth;
            _currentHealth = _maxHealth;
        }

        protected  void FixedUpdate()
        {
            OnMove();
        }

        protected void OnMove()
        {
            transform.position += _movement * unitParams.MoveSpeed * Time.deltaTime;
        }

        protected void ToShoot(Transform parent, Transform weapon)
        {
            string path = "Prefabs/“earProjectile";// ÔÓÍ‡ Ú‡Í
            _projectile = Instantiate(Resources.Load<GameObject>(path), weapon.transform.position, weapon.transform.rotation, parent);
        }

        public void SetDamage(float damage)
            => _currentHealth -= damage;

        public void RestoreHealth(float restore)
        {
            _currentHealth += restore;
            if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;
        }
    }
}
