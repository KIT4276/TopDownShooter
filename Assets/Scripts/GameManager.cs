using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TDS
{
    public class GameManager : MonoBehaviour
    {
        private static int _experienceInChapter;
        private static int _totalExperience; 
        private static int _artifactsTaken;
        private static int _totalArtifacts;

        

        //private Data _data;

        [SerializeField]
        private int _artifactsOnLVL1 = 1;
        [SerializeField]
        private int _artifactsOnLVL2 = 3; 
        [SerializeField]
        private int _artifactsOnLVL3 = 5;
        [SerializeField]
        private int _artifactsOnLVL4 = 4;

        [Space, SerializeField]
        private Text _artifactsTakenText;
        [SerializeField]
        private Text _totalArtifactsText;
        [SerializeField]
        private Text _experienceText;
        [SerializeField]
        private Text _totalExperienceText;
        [SerializeField]
        private GameObject _infoPanel;
        [SerializeField]
        private Vector3 _locationPosition = new Vector3(-44, -1, -35);

        [Space, SerializeField]
        private GameObject _player;

        public static bool IsOnBase { get; private set; }

        public static GameManager _instance;

        private void Start()
        {
            //_data = new Data();
            //_totalExperience =  Data.GetExperience();
            if (SceneManager.GetActiveScene().name != "LVL1") IsOnBase = true;

            if (SceneManager.GetActiveScene().name != "LVL1") _infoPanel.SetActive(false);

            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;

            _totalArtifacts = ReturnArtifactsOnLVL();
        }

        private void Update()
        {
            _artifactsTakenText.text = _artifactsTaken.ToString();
            _totalArtifactsText.text = _totalArtifacts.ToString();
            _experienceText.text = _experienceInChapter.ToString();
            _totalExperienceText.text = _totalExperience.ToString();

            Debug.Log(IsOnBase);
            LevelVictory();
        }

        private void NextChapter()
        {
            _totalExperience += _experienceInChapter;
            _experienceInChapter = 0;
            _artifactsTaken = 0;

            NextLVL(); //--------------------------------------------this is where the new scene loading chain starts
        }

        public void MovingToLocation()
        {
            
            _player.transform.position = _locationPosition;
            _infoPanel.SetActive(true);
            IsOnBase = false;
        }

        private void LevelVictory()
        {
            if (_artifactsTaken == _totalArtifacts) 
                NextChapter();
        }

        private int ReturnArtifactsOnLVL()
        {
            int artifactsOnLVL;
            switch (SceneManager.GetActiveScene().name)
            {
                case "LVL0":
                    artifactsOnLVL = 1;
                    break;
                case "LVL1":
                    artifactsOnLVL = _artifactsOnLVL1;
                    break;
                case "LVL2":
                    artifactsOnLVL = _artifactsOnLVL2;
                    break;
                case "LVL3":
                    artifactsOnLVL = _artifactsOnLVL3;
                    break;
                case "LVL4":
                    artifactsOnLVL = _artifactsOnLVL4;
                    break;
                default:
                    artifactsOnLVL = 1;
                    break;
            }
            return artifactsOnLVL;
        }

        public void NextLVL()
            => LVLManager._instance.LoadScene(LVLManager._instance.ReturnNextSceneName());

        public void ArtifactCapture()
            => _artifactsTaken++;
            

        public void AddExperience(int value)
            => _experienceInChapter+= value;
    }
}
