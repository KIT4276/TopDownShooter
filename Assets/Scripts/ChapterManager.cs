using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class ChapterManager : MonoBehaviour
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

        [Space, SerializeField]
        private Fader _fader;

        //public bool IsAsyncLoaded { get; private set; }
        public Chapter CurrentChapter { get; private set; }
        public static Chapter NextChapter { get; private set; }

        //public static ChapterManager instance;

        private void Awake()
        {
            //instance = this;
            CurrentChapter = Chapter.Non;
            NextChapter = Chapter.RoutineTask;
            //_fader.gameObject.SetActive(false);
            _lvl0.SetActive(true);
            //_fader.gameObject.SetActive(true);
        }

        private void Update()
        {
            if(CurrentChapter == NextChapter)
            NextChapter = ReturnNextChapter();

            //Debug.Log("CurrentChapter " + CurrentChapter);
            //Debug.Log("NextChapter " + NextChapter);

        }

        public void LoadNextScene()
        {
            if (NextChapter == Chapter.RoutineTask)
            {
                _player.SetActive(true);
                //Debug.Log("NextChapter == Chapter.RoutineTask");
            }
            StartCoroutine(LoadSceneRoutine());
        }

        private IEnumerator LoadSceneRoutine()
        {
            _fader.gameObject.SetActive(true);
            _fader.FadeIn();

            while (_fader.IsFading)
                yield return null;

            UnLoadScene(ReturnLVL(CurrentChapter));
            LoadScene(ReturnLVL(NextChapter));

            while (_fader.IsFading)
                yield return null;


            _fader.FadeOut();

            CurrentChapter = NextChapter;
            yield return null;
        }

        public void LoadScene(GameObject LVL)
        {
            Debug.Log("LoadScene " + LVL.name);
            //IsAsyncLoaded = false;

            LVL.SetActive(true);

            //IsAsyncLoaded = true;
            NextChapter = ReturnNextChapter();
            //_fader.gameObject.SetActive(false);
            //yield return null;
        }
        public void UnLoadScene(GameObject LVL)
        {
            Debug.Log("UnLoadScene " + LVL.name);
            LVL.SetActive(false);
            //yield return null;
        }

        public GameObject ReturnLVL(Chapter chapter)
        {
            GameObject LVL;
            switch (chapter)
            {
                case Chapter.Non:
                    LVL = _lvl0;
                    break;
                case Chapter.RoutineTask:
                    LVL = _lvl1;
                    break;
                case Chapter.FirstMeeting:
                    LVL = _lvl2;
                    break;
                case Chapter.TheIceHasBroken:
                    LVL = _lvl3;
                    break;
                case Chapter.LookUp:
                    LVL = _lvl4;
                    break;
                default:
                    LVL = _lvl0;
                    break;
            }
            return LVL;
        }

        public Chapter ReturnNextChapter() //--------------------------------------------ну почему не работает?!
        {
            Chapter nextChapter; 
            switch (CurrentChapter)
            {
                case Chapter.Non:
                    nextChapter = Chapter.RoutineTask;
                    break;
                case Chapter.RoutineTask:
                    nextChapter = Chapter.FirstMeeting;
                    break;
                case Chapter.FirstMeeting:
                    nextChapter = Chapter.TheIceHasBroken;
                    break;
                case Chapter.TheIceHasBroken:
                    nextChapter = Chapter.LookUp;
                    break;
                default:
                    nextChapter = Chapter.between;
                    break;
            }
            return nextChapter;
        }
    }
}
