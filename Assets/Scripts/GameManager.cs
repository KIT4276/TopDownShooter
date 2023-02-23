using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TDS
{
    public class GameManager : MonoBehaviour
    {
        private static int _experienceInChapter;
        private static int _totalExperience; 
        private static int _artifactsTaken;
        private static int _totalArtifacts;
        //private static Chapter _currentChapter;

        [SerializeField]
        private int _artifactsPrChapter1 = 1;
        [SerializeField]
        private int _artifactsPrChapter2 = 3; 
        [SerializeField]
        private int _artifactsPrChapter3 = 5;
        [SerializeField]
        private int _artifactsPrChapter4 = 4;

        [Space, SerializeField]
        private Text _artifactsTakenText;
        [SerializeField]
        private Text _totalArtifactsText;
        //[SerializeField]
        //private Text _chapterName;

        //[Space, SerializeField]
        //private float _delayBeforeMission = 5;

        [SerializeField]
        private GameObject _player;
        [SerializeField]
        private ChapterManager _chapterManager;

        public static GameManager instance;

        private void Start()
        {
            instance = this;

            //Fader.instance.FadeIn(); // todo

            //_currentChapter = Chapter.RoutineTask;
            //_chapterName.text = _chapterManager.CurrentChapter.ToString();
            _totalArtifacts = _artifactsPrChapter1;
        }

        private void Update()
        {
            //Debug.Log("In Chapter " + _experienceInChapter);
            //Debug.Log("Total " + _totalExperience);

            _artifactsTakenText.text = _artifactsTaken.ToString();
            _totalArtifactsText.text = _totalArtifacts.ToString();

            LevelVictory();
        }


        private void NextChapter()
        {
            //_chapterName.gameObject.SetActive(false);
            //-------------------------------------------------todo Events at the base between chapters, maybe a video

            _totalExperience += _experienceInChapter;
            _experienceInChapter = 0;
            _artifactsTaken = 0;

            _chapterManager.LoadNextScene(); // --------------------------------------отсюда начинается цепочка

            switch (_chapterManager.CurrentChapter)
            {
                case Chapter.RoutineTask:
                    _totalArtifacts = _artifactsPrChapter1;
                    break;
                case Chapter.FirstMeeting:
                    _totalArtifacts = _artifactsPrChapter2;
                    break;
                case Chapter.TheIceHasBroken:
                    _totalArtifacts = _artifactsPrChapter3;
                    break;
                case Chapter.LookUp:
                    _totalArtifacts = _artifactsPrChapter4;
                    break;
                default:
                    break;
            }

            //_chapterName.text = _chapterManager.CurrentChapter.ToString();
            //_chapterName.gameObject.SetActive(true);
            //StartCoroutine(DelayBeforeMission());
        }

        //private IEnumerator DelayBeforeMission()
        //{
        //    yield return new WaitForSeconds(_delayBeforeMission);
        //    //_chapterName.gameObject.SetActive(false);
        //}

        private void LevelVictory()
        {
            if (_artifactsTaken == _totalArtifacts) NextChapter();

        }


        public void ArtifactCapture()
            => _artifactsTaken++;
            

        public void AddExperience(int value)
            => _experienceInChapter+= value;
    }
}
