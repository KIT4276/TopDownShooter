using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class Base : MonoBehaviour
    {
        [SerializeField]
        private ChapterManager _chapterManager;

        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.gameObject.GetComponent<PlayerInput>()) _chapterManager.LeaveTheBase();
        //}
    }
}
