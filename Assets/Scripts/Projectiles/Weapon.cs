using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace TDS
{
    public class Weapon : MonoBehaviour
    {
        private float _ammoInMag“ear;
        private float _ammoInMagFurther;
        private float _leftAmmo“ear = 15;
        private float _leftAmmoFurther = 15;
        private PlayerControls _controls;
        private string _pathToPrefab;
        
        public GameObject ActiveWeapon { get; private set; }

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
            _ammoInMag“ear = _magazineCapacity;
        }

        private void Update()
        {
            if(ActiveWeapon == _furtherWeaponObject)
            {
                _ammoInMagText.text = _ammoInMagFurther.ToString();
                _leftAmmoText.text = _leftAmmoFurther.ToString();
                if (_leftAmmoFurther <= _magazineCapacity) _leftAmmoText.color = Color.yellow;
                else _leftAmmoText.color = Color.blue;
            }

            else
            {
                _ammoInMagText.text = _ammoInMag“ear.ToString();
                _leftAmmoText.text = _leftAmmo“ear.ToString();
                if (_leftAmmoFurther <= _magazineCapacity) _leftAmmoText.color = Color.red;
                else _leftAmmoText.color = Color.green;
            }

        }

        private void WeaponSwitch(InputAction.CallbackContext obj)
        {
            if (ActiveWeapon == _tearWeaponObject)
            {
                ActiveWeapon = _furtherWeaponObject;
                _tearWeaponObject.SetActive(false);
                _furtherWeaponObject.SetActive(true);
                _ammoInMagText.color = Color.blue;
            }
            else
            {
                ActiveWeapon = _tearWeaponObject;
                _tearWeaponObject.SetActive(true);
                _furtherWeaponObject.SetActive(false);
                _ammoInMagText.color = Color.green;
            }
        }

        private void AmmoStatusUpdate()
        {
            if(ActiveWeapon == _furtherWeaponObject)
            {
                _ammoInMagFurther--;
                if (_ammoInMagFurther <= 0) Reload();
            }
            else
            {
                _ammoInMag“ear--;
                if (_ammoInMag“ear <= 0) Reload();
            }
        }

        public string GetProjectile()
        {
            if (ActiveWeapon == _furtherWeaponObject) _pathToPrefab = "Prefabs/FurtherProjectile";
            else  _pathToPrefab = "Prefabs/“earProjectile";

            return _pathToPrefab;
        }

        public bool GetAbilityToShoot()
        {
            if (ActiveWeapon == _furtherWeaponObject)
            {
                if (_leftAmmoFurther != 0 || _ammoInMagFurther != 0) return true;
                else return false;
            }
            else
            {
                if (_leftAmmo“ear != 0 || _ammoInMag“ear != 0) return true;
                else return false;
            }
        }

        public void AddAmmo(float value, ProjectileType type) //type = 2 => Further; type = 1 => “ear
        {
            if (type == ProjectileType.Further)
            {
                _leftAmmoFurther += value;
                if (_ammoInMagFurther == 0) Reload();
            }
            else
            {
                _leftAmmo“ear += value;
                if (_ammoInMag“ear == 0) Reload();
            }
            Debug.Log("_leftAmmo“ear " + _leftAmmo“ear);
            Debug.Log("_leftAmmoFurther " + _leftAmmoFurther);
        }

        private void Reload()
        {
            if (ActiveWeapon == _furtherWeaponObject)
            {
                if (_leftAmmoFurther < _magazineCapacity)
                {
                    _ammoInMagFurther = _leftAmmoFurther;
                    _leftAmmoFurther = 0;
                }
                else
                {
                    _leftAmmoFurther -= _magazineCapacity;
                    _ammoInMagFurther = _magazineCapacity;
                }
            } //------------------------------------------------- ‡Í ËÁ·‡‚ËÚ¸Òˇ ÓÚ ‚ÒÂı ˝ÚËı ·ÂÁÛÏÌ˚ı ÔÓ‚ÚÓÂÌËÈ?
            else
            {
                if (_leftAmmo“ear < _magazineCapacity)
                {
                    _ammoInMag“ear = _leftAmmo“ear;
                    _leftAmmo“ear = 0;
                }
                else
                {
                    _leftAmmo“ear -= _magazineCapacity;
                    _ammoInMag“ear = _magazineCapacity;
                }
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
