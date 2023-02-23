using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TDS
{
    public class ChapterManager : MonoBehaviour
    {
        private bool _isOnBase;
        private Vector3 _positionOnBase = new Vector3(29, -1, -36);
        
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
        [SerializeField]
        private Transform _playersTransform;

        [Space, SerializeField]
        private Fader _fader;
        [SerializeField]
        private GameObject _faderImage;

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
            //if(CurrentChapter == NextChapter) NextChapter = ReturnNextChapter();

            //Debug.Log("CurrentChapter " + CurrentChapter);
            //Debug.Log("NextChapter " + NextChapter);
            Debug.Log("_isOnBase " + _isOnBase);
        }


        public void LoadNextScene()
        {
            if (NextChapter == Chapter.RoutineTask) _player.SetActive(true);

            //Debug.Log("Current " + CurrentChapter);
            //Debug.Log("Next " + NextChapter);
            StartCoroutine(LoadSceneRoutine());
        }

        private IEnumerator LoadSceneRoutine()
        {
            _isOnBase = true;
            _faderImage.SetActive(true);
            _fader.FadeIn();
            Debug.Log("worked FadeIn LoadSceneRoutine");

            while (_fader.IsFading)
                yield return null;

            UnLoadScene(ReturnLVL(CurrentChapter));
            if (_isOnBase) _playersTransform.position = _positionOnBase;
            LoadScene(ReturnLVL(NextChapter));

            while (_fader.IsFading)
                yield return null;

            _fader.FadeOut();
            Debug.Log("worked FadeOut LoadSceneRoutine");

            CurrentChapter = NextChapter;
            NextChapter = ReturnNextChapter();
            yield return null;
        }

        public void LoadScene(GameObject LVL)
        {
            //Debug.Log("LoadScene " + LVL.name);
            //IsAsyncLoaded = false;

            LVL.SetActive(true);

            //IsAsyncLoaded = true;
            //NextChapter = ReturnNextChapter();
            //_fader.gameObject.SetActive(false);
            //yield return null;
        }
        public void UnLoadScene(GameObject LVL)
        {
            //Debug.Log("UnLoadScene " + LVL.name);
            LVL.SetActive(false);
            //yield return null;
        }

        //public void LeaveTheBase()
        //{
        //    _isOnBase = false;
        //    _fader.FadeIn();
        //    Debug.Log("FadeIn LeaveTheBase");

        //    _playersTransform.position = ReturnPositionOnLVL();

        //    //while (_fader.IsFading) TY();


        //    _fader.FadeOut();
        //    Debug.Log("FadeOut LeaveTheBase");
        //    //StartCoroutine(WaitForIsFading());
        //}
        public void LeaveTheBase()
        {
            StartCoroutine(LeaveTheBaseRoutine());
        }

        public IEnumerator LeaveTheBaseRoutine()
        {
            _isOnBase = false;
            _faderImage.SetActive(true);
            _fader.FadeIn();
            Debug.Log("worked FadeIn LeaveTheBase");

            

            while (_fader.IsFading) 
                yield return null;

            _playersTransform.position = ReturnPositionOnLVL();


            _fader.FadeOut();
            Debug.Log(" worked FadeOut LeaveTheBase");
            
            yield return null;
        }


        private Vector3 ReturnPositionOnLVL()
        {
            Vector3 _pos;
            switch (CurrentChapter)
            {
                //case Chapter.Non:
                //    _pos = Vector3.zero; // пока так
                //    break;
                case Chapter.RoutineTask:
                    _pos = new Vector3(-8.4f, -1f, -36f);
                    break;
                case Chapter.FirstMeeting:
                    _pos = new Vector3(-8.4f, -10f, -36f);
                    break;
                case Chapter.TheIceHasBroken:
                    _pos = new Vector3(-8.4f, -20f, -36f);
                    break;
                case Chapter.LookUp:
                    _pos = new Vector3(-8.4f, -30f, -36f);
                    break;
                case Chapter.between:
                    _pos = new Vector3(-8.4f, -40f, -36f);
                    break;
                default:
                    _pos = new Vector3(29f, -1f, -36f);
                    break;
            }

            return _pos;
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

        public Chapter ReturnNextChapter() 
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
