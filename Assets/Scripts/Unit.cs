using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class Unit : MonoBehaviour
    {
        private float _maxHealth;
        protected float _currentHealth;


        [SerializeField]
        protected UnitParams unitParams;


        protected void Awake()
        {
            _maxHealth = unitParams.MaxHealth;
            _currentHealth = _maxHealth;
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
