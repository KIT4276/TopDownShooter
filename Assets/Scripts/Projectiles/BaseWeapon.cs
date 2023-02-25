using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class BaseWeapon : MonoBehaviour
    {
        protected float _ammoInMag“ear;
        protected float _ammoInMagFurther;
        protected float _leftAmmo“ear = 15;
        protected float _leftAmmoFurther = 15;
        protected PlayerControls _controls;
        protected string _pathToPrefab;

        [SerializeField]
        protected float _magazineCapacity = 10;

        [Space, SerializeField]
        protected GameObject _tearWeaponObject;
        [SerializeField]
        protected GameObject _furtherWeaponObject;
        [SerializeField]
        private ProjectileType _NPCActiveWeapon;

        public ProjectileType ActiveWeapon { get; protected set; }

        private void Start()
        {
            ActiveWeapon = _NPCActiveWeapon;
            if (ActiveWeapon == ProjectileType.Further)
            {
                _tearWeaponObject.SetActive(false);
                _furtherWeaponObject.SetActive(true);
            }
            else
            {
                _tearWeaponObject.SetActive(true);
                _furtherWeaponObject.SetActive(false);
            }
        }

        public string GetProjectile()
        {
            if (ActiveWeapon == ProjectileType.Further) //_furtherWeaponObject) 
                _pathToPrefab = "Prefabs/FurtherProjectile";
            else _pathToPrefab = "Prefabs/“earProjectile";

            return _pathToPrefab;
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
            //Debug.Log("_leftAmmo“ear " + _leftAmmo“ear);
            //Debug.Log("_leftAmmoFurther " + _leftAmmoFurther);
        }

        protected void Reload()
        {
            if (ActiveWeapon == ProjectileType.Further)//_furtherWeaponObject)
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


        public void PutAwayWeapon()
        {
            _furtherWeaponObject.SetActive(false);
            _tearWeaponObject.SetActive(false);
        }

        public virtual bool GetAbilityToShoot() => true;

        public virtual void CallOnShoot() { } // Á‡„ÎÛ¯Í‡
    }
}
