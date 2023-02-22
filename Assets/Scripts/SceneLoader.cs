using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField]
        private GameObject _lvl0;
        [SerializeField]
        private GameObject _lvl1;
        [SerializeField]
        private GameObject _lvl2;
        [SerializeField]
        private GameObject _lvl3;
        [SerializeField]
        private GameObject _lvl4;
        [SerializeField, Tooltip("Всё от персонажа, кроме CameraPoint")]
        private GameObject _player;

        private bool _isLoading;
        private Chapter _nextChapter;

        public static SceneLoader instance;



        private void Awake()
        {
            _lvl0.SetActive(true);

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
            //if (Input.GetKeyDown(KeyCode.Alpha0)) LoadScene(Chapter.Non); // врееменные

            //if (Input.GetKeyDown(KeyCode.Alpha1)) LoadScene(Chapter.RoutineTask);

            //if (Input.GetKeyDown(KeyCode.Alpha2)) LoadScene(Chapter.FirstMeeting);

        }

        public void LoadScene(Chapter chapter)
        {
            if (_isLoading) return;
            if (chapter == Chapter.RoutineTask) _player.SetActive(true);


            //if (ChapterManager.instance.NextChapter == ChapterManager.instance.CurrentChapter)
            //{
            //    Debug.Log(" Попытка загрузить уже загруженную сцену");
            //    return;
            //}

            StartCoroutine(LoadSceneRoutine());
        }

        private IEnumerator LoadSceneRoutine()
        {
            _isLoading = true;

            Chapter nextChapter = ChapterManager.instance.ReturnNextChapter();

            var waitFading = true;
            Fader.instance.FadeIn(() => waitFading = false);

            while (waitFading) 
                yield return null;

            ChapterManager.instance.UnLoadSceneAsync(ReturnLVL(ChapterManager.instance.CurrentChapter));
            ChapterManager.instance.LoadSceneAsync(ReturnLVL(nextChapter));
            

            while (!ChapterManager.instance.IsAsyncLoaded) 
                yield return null;

            waitFading = true;

            Fader.instance.FadeOut(() => waitFading = false);

            while (waitFading) 
                yield return null;

            _isLoading = false;
        }

        

        public GameObject ReturnLVL(Chapter NextChapter)
        {
            GameObject nextLVL;
            switch (NextChapter)
            {
                case Chapter.Non:
                    nextLVL = _lvl0;
                    break;
                case Chapter.RoutineTask:
                    nextLVL = _lvl1;
                    break;
                case Chapter.FirstMeeting:
                    nextLVL = _lvl2;
                    break;
                case Chapter.TheIceHasBroken:
                    nextLVL = _lvl3;
                    break;
                case Chapter.LookUp:
                    nextLVL = _lvl4;
                    break;
                default:
                    nextLVL = _lvl0;
                    break;
            }
            return nextLVL;
        }
    }
}
