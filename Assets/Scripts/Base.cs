using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class Base : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("OnCollisionEnter");
            if (collision.gameObject.GetComponent<PlayerInput>() != null)
                GameManager._instance.MovingToLocation();
        }

    }
}
