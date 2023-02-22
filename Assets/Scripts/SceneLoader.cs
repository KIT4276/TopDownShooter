using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class SceneLoader : MonoBehaviour
    {

        private bool _isLoading;
        private ChapterManager _chapterManager;

        public static SceneLoader instance;



        private void Awake()
        {
            _chapterManager = GetComponent<ChapterManager>();


            if (instance != null) // на случай загрузки карт в разных сценах
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            //DontDestroyOnLoad(gameObject);// на случай загрузки карт в разных сценах
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0)) LoadScene(Chapter.Non); // врееменные

            if (Input.GetKeyDown(KeyCode.Alpha1)) LoadScene(Chapter.RoutineTask);

            if (Input.GetKeyDown(KeyCode.Alpha2)) LoadScene(Chapter.FirstMeeting);

        }

        public void LoadScene(Chapter chapter)
        {
            if (_isLoading) return;

            if (chapter == _chapterManager.CurrentChapter)
            {
                Debug.Log(" Попытка загрузить уже загруженную сцену");
                return;
            }

            StartCoroutine(LoadSceneRoutine());
        }

        private IEnumerator LoadSceneRoutine()
        {
            _isLoading = true;

            var waitFading = true;
            Fader.instance.FadeIn(() => waitFading = false);

            while (waitFading) 
                yield return null;

            var async = _chapterManager.LoadSceneAsync();

            while(!_chapterManager.IsAsyncLoaded) 
                yield return null;

            waitFading = true;

            Fader.instance.FadeOut(() => waitFading = false);

            while (waitFading) 
                yield return null;

            _isLoading = false;
        }

        
    }
}
