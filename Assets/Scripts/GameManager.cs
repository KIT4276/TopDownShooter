using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TDS
{
    public class GameManager : MonoBehaviour
    {
        private static int _experienceInChapter;
        //private static int _totalExperience; ---------------------------------------ÂÅÐÍÓÒÜ!
        private static int _artifactsTaken;
        private static int _artifactsLeft;
        private static Chapter _currentChapter;

        [SerializeField]
        private int _artifactsPrChapter1 = 1;
        [SerializeField]
        private int _artifactsPrChapter2 = 3;
        [SerializeField]
        private int _artifactsPrChapter3 = 5;

        [Space, SerializeField]
        private Text _artifactsTakenText;
        [SerializeField]
        private Text _artifactsLeftText;
        [SerializeField]
        private Text _chapterName;

        public static GameManager self;

        private void Start()
        {
            self = this;
            _currentChapter = Chapter.RoutineTask;
            _chapterName.text = _currentChapter.ToString();
            _artifactsLeft = _artifactsPrChapter1;
        }

        private void Update()
        {
            Debug.Log("In Chapter " + _experienceInChapter);
            // Debug.Log("Total " + _totalExperience);

            _artifactsTakenText.text = _artifactsTaken.ToString();
            _artifactsLeftText.text = _artifactsLeft.ToString();
        }

        //public void NextChapter()
        //{
        //    //_totalExperience += _experienceInChapter;  ---------------------------------------ÂÅÐÍÓÒÜ!
        //    _experienceInChapter = 0;
        //    //_artifactsLeft =  òóò íàäî ïîäóìàòü...
        //    _currentChapter++;
        //}

        public void ArtifactCapture()
        {
            _artifactsTaken++;
        }
            

        public void AddExperience(int value)
            => _experienceInChapter+= value;
    }
}
