using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace TDS
{
    public class Weapon : MonoBehaviour
    {
        private float _ammoInMag;
        private float _leftAmmo = 15;
        private PlayerControls _controls;
        private string _pathToPrefab;
        
        public GameObject ActiveWeapon { get; private set; }

        //[SerializeField]
        //private ProjectileType _projectileType;
        [SerializeField]
        private float _magazineCapacity = 10;

        [Space, SerializeField]
        private Text _ammoInMagText;
        [SerializeField]
        private Text _leftAmmoText;

        [Space, SerializeField]
        private GameObject _tearWeaponObject;
        [SerializeField]
        private GameObject _furtherWeaponObject;

        public void CallOnShoot() => AmmoStatusUpdate();

        private void Awake()
        {
            _controls = new PlayerControls();
            _controls.PlayerInputMapp.WeaponSwitch.performed += WeaponSwitch;
        }

        private void Start()
        {
            _ammoInMag = _magazineCapacity;
        }

        private void Update()
        {
            _ammoInMagText.text = _ammoInMag.ToString();
            _leftAmmoText.text = _leftAmmo.ToString();
        }

        private void WeaponSwitch(InputAction.CallbackContext obj)
        {
            if (ActiveWeapon == _tearWeaponObject)
            {
                ActiveWeapon = _furtherWeaponObject;
                _tearWeaponObject.SetActive(false);
                _furtherWeaponObject.SetActive(true);
            }
            else
            {
                ActiveWeapon = _tearWeaponObject;
                _tearWeaponObject.SetActive(true);
                _furtherWeaponObject.SetActive(false);
            }
        }

        private void AmmoStatusUpdate()
        {
            _ammoInMag--;
            if (_ammoInMag <= 0) Reload();
        }

        public string GetProjectile()
        {
            if (ActiveWeapon == _furtherWeaponObject) _pathToPrefab = "Prefabs/FurtherProjectile";
            else  _pathToPrefab = "Prefabs/ÒearProjectile";

            return _pathToPrefab;
        }

        public bool GetAbilityToShoot()
        {
            if (_leftAmmo != 0 || _ammoInMag != 0) return true;
            else return false;
        }

        public void AddAmmo(float value)
        {
            _leftAmmo += value;
            if (_ammoInMag == 0) Reload();
        }

        private void Reload()
        {
            if (_leftAmmo < _magazineCapacity)
            {
                _ammoInMag = _leftAmmo;
                _leftAmmo = 0;
            }
            else
            {
                _leftAmmo -= _magazineCapacity;
                _ammoInMag = _magazineCapacity;
            }
        }

        private void OnEnable()
           => _controls.PlayerInputMapp.Enable();

        private void OnDisable()
            => _controls.PlayerInputMapp.Disable();

        private void OnDestroy()
        {
            _controls.PlayerInputMapp.WeaponSwitch.performed -= WeaponSwitch;
            _controls.Dispose();
        }
    }
}
