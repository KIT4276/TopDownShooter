using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class ChapterManager : MonoBehaviour
    {
        public bool IsAsyncLoaded { get; private set; } 
        public Chapter CurrentChapter { get; private set; }

        public IEnumerator LoadSceneAsync()
        {
            IsAsyncLoaded = false;

            yield return new WaitForSeconds(3); // заглушка

            

            IsAsyncLoaded = true;
            yield return null;
        }
    }
}
