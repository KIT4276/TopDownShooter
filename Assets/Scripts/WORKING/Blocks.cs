using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class Blocks : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<Projectile>() != null)
            {
                Destroy(gameObject);
                //Debug.Log(transform.name + " Destroyed by Projectile");
            }
            
        }
    }
}
