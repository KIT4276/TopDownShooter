using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class Blocks : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}
