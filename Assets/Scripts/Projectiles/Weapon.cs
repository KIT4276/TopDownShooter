using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TDS
{
    public class Weapon : MonoBehaviour
    {
        private float _ammoInMag;
        private float _leftAmmo = 15;

        private string _pathToPrefab;

        [SerializeField]
        private ProjectileType _projectileType;
        [SerializeField]
        private float _magazineCapacity = 10;

        [Space, SerializeField]
        private Text _ammoInMagText;
        [SerializeField]
        private Text _leftAmmoText;

        //private event SimpleHandle Shoot;

        //public void CallOnShootEvent() => Shoot?.Invoke();

        public void CallOnShoot() => AmmoStatusUpdate();

        private void Start()
        {
            //Shoot += AmmoStatusUpdate;
            _ammoInMag = _magazineCapacity;
        }

        private void Update()
        {
            _ammoInMagText.text = _ammoInMag.ToString();
            _leftAmmoText.text = _leftAmmo.ToString();
        }

        private void AmmoStatusUpdate()
        {
            _ammoInMag--;
            
            if (_ammoInMag <= 0)
            {
                if(_leftAmmo < _magazineCapacity)
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
        }

        public string GetProjectile()
        {
            switch (_projectileType)
            {
                case ProjectileType.�ear:
                    _pathToPrefab = "Prefabs/�earProjectile";
                    break;
                case ProjectileType.Further:
                    _pathToPrefab = "Prefabs/FurtherProjectile";
                    break;
                default:
                    _pathToPrefab = "Prefabs/�earProjectile";
                    break;
            }
            return _pathToPrefab;
        }

        public bool CanShoot()
        {
            if (_leftAmmo != 0 || _ammoInMag != 0) return true;
            else return false;
        }


        public float GetCapacity()
        {
            return _magazineCapacity;
        }

        //private void OnDestroy()
        //{
        //    Shoot -= CallOnShootEvent;
        //}
    }
}