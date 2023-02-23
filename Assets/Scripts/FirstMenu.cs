using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TDS
{
    public class FirstMenu : MonoBehaviour
    {
        [SerializeField]
        private ChapterManager _chapterManager;
        [SerializeField]
        private Fader _fader;
        //[SerializeField]
        //private GameObject _faderImage;
        public void NextLVL()
        {
            _chapterManager.LoadNextScene();
            //Debug.Log("NextLVL");
            //_faderImage.gameObject.SetActive(true);
            _chapterManager.LeaveTheBase();
        }

    }
}
