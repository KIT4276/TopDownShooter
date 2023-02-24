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
        private GameObject _player;

        public static GameManager _instance;

        private void Start()
        {
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

            LevelVictory();
        }

        private void NextChapter()
        {
            //-------------------------------------------------todo Events at the base between chapters, maybe a video
            _totalExperience += _experienceInChapter;
            _experienceInChapter = 0;
            _artifactsTaken = 0;

            NextLVL(); //--------------------------------------------this is where the new scene loading chain starts
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
