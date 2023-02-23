using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class FirstMenu : MonoBehaviour
    {
        [SerializeField]
        private ChapterManager _chapterManager;
        [SerializeField]
        private Fader _fader;
        public void NextLVL()
        {
            _chapterManager.LoadNextScene();
            Debug.Log("NextLVL");
            _fader.gameObject.SetActive(true); 
        }

    }
}
