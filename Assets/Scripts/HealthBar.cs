using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TDS
{
    public class HealthBar : MonoBehaviour
    {
        private Transform _camera;
        private BaseNPC _npc;

        [SerializeField]
        private Slider _healthBar;

        private void Start()
        {
            _npc = GetComponentInParent<BaseNPC>();
            _camera = Camera.main.transform;
            _healthBar.maxValue = _npc.GetMaxHealth();
        }
        private void Update()
        {
            transform.LookAt(_camera);
            _healthBar.value = _npc.GetCurrentHealth();
        }


    }
}
