using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDS
{
    public class LVLManager : MonoBehaviour
    {
        private const string SCENE_0 = "LVL0";
        private const string SCENE_1 = "LVL1";
        private const string SCENE_2 = "LVL2";
        private const string SCENE_3 = "LVL3";
        private const string SCENE_4 = "LVL4";
        private const string SCENE_5 = "LVL5";

        private bool _isLoadiing;

        public static LVLManager _instance;

        private void Awake()
        {
            if(_instance != null)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void LoadScene(string sceneName)
        {
            if (_isLoadiing) return;

            var currentSceneName = SceneManager.GetActiveScene().name;
            if (currentSceneName == sceneName)
                throw new Exception("You are trying to load a scene that is already loaded");
            StartCoroutine(LoadSceneRoutine(sceneName));
        }

        private IEnumerator LoadSceneRoutine(string sceneName)
        {
            _isLoadiing = true;

            var waitFading = true;
            Fader.Instance.FadeIn(() => waitFading = false);

            while (waitFading)
                yield return null;

            var async = SceneManager.LoadSceneAsync(sceneName);
            async.allowSceneActivation = false;

            while(async.progress < 0.9f)
                yield return null;

            // --------------------------------- todo additional events when loading a new scene

            async.allowSceneActivation = true;

            waitFading = true;
            Fader.Instance.FadeOut(() => waitFading = false);

            while (waitFading)
                yield return null;

            _isLoadiing = false;
        }

        public string ReturnNextSceneName()
        {
            string nextSceneName;
            switch (SceneManager.GetActiveScene().name)
            {
                case SCENE_0:
                    nextSceneName = SCENE_1;
                    break;
                case SCENE_1:
                    nextSceneName = SCENE_2;
                    break;
                case SCENE_2:
                    nextSceneName = SCENE_3;
                    break;
                case SCENE_3:
                    nextSceneName = SCENE_4;
                    break;
                default:
                    nextSceneName = SCENE_5;
                    break;
            }
            return nextSceneName;
        }
    }
}
