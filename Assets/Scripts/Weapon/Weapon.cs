using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace TDS
{
    public class Weapon : BaseWeapon
    {

        [Space, SerializeField]
        private Text _ammoInMagText;
        [SerializeField]
        private Text _leftAmmoText;
        

        [Space, SerializeField]
        private GameObject _tearWeaponImage;
        [SerializeField]
        private GameObject _furtherWeaponImage;

        public override void CallOnShoot() => AmmoStatusUpdate();

        private void Awake()
        {
            _controls = new PlayerControls();
            _controls.PlayerInputMapp.WeaponSwitch.performed += WeaponSwitch;
        }

        private void Start()
        {
            _ammoInMag“ear = _magazineCapacity;
            _ammoInMagFurther = _magazineCapacity;
            ActiveWeapon = ProjectileType.“ear; //_tearWeaponObject;
            _ammoInMagText.color = Color.blue;
            _leftAmmoText.color = Color.blue;
        }

        private void Update()
        {
            if (ActiveWeapon == ProjectileType.Further)  //_furtherWeaponObject)
            {
                _ammoInMagText.text = _ammoInMagFurther.ToString();
                _leftAmmoText.text = _leftAmmoFurther.ToString();
                //if (_leftAmmoFurther <= _magazineCapacity) _leftAmmoText.color = Color.red;
                //else _leftAmmoText.color = Color.yellow;
            }

            else
            {
                _ammoInMagText.text = _ammoInMag“ear.ToString();
                _leftAmmoText.text = _leftAmmo“ear.ToString();
                //if (_leftAmmoFurther <= _magazineCapacity) _leftAmmoText.color = Color.red;
                //else _leftAmmoText.color = Color.blue;
            }

        }

        private void WeaponSwitch(InputAction.CallbackContext obj)
        {
            if (ActiveWeapon == ProjectileType.“ear)//_tearWeaponObject)
            {
                ActiveWeapon =  ProjectileType.Further;// _furtherWeaponObject;
                _tearWeaponObject.SetActive(false);
                _furtherWeaponObject.SetActive(true);
                _ammoInMagText.color = Color.yellow;
                _leftAmmoText.color = Color.yellow;
                _furtherWeaponImage.SetActive(true);
                _tearWeaponImage.SetActive(false);
            }
            else
            {
                ActiveWeapon = ProjectileType.“ear;//_tearWeaponObject;
                _tearWeaponObject.SetActive(true);
                _furtherWeaponObject.SetActive(false);
                _ammoInMagText.color = Color.blue;
                _leftAmmoText.color = Color.blue;
                _furtherWeaponImage.SetActive(false);
                _tearWeaponImage.SetActive(true);
            }
        }

        private void AmmoStatusUpdate()
        {
            if (ActiveWeapon == ProjectileType.Further)//_furtherWeaponObject)
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


        public override bool GetAbilityToShoot()
        {
            if (ActiveWeapon == ProjectileType.Further)// _furtherWeaponObject)
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
