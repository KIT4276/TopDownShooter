using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDS
{
    public class FaderExample : MonoBehaviour
    {
        private const string SCENE_0 = "LVL0";
        private const string SCENE_1 = "LVL1";
        private const string SCENE_2 = "LVL2";
        private const string SCENE_3 = "LVL3";
        private const string SCENE_4 = "LVL4";

        private bool _isLoadiing;

        private static FaderExample _instance;

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

        private void Update() //временно для проверки загрузок. далее метод LoadScene вызывается извне
        {
            if (Input.GetKeyDown(KeyCode.Alpha0)) LoadScene(SCENE_0);
            if (Input.GetKeyDown(KeyCode.Alpha1)) LoadScene(SCENE_1);
            if (Input.GetKeyDown(KeyCode.Alpha2)) LoadScene(SCENE_2);
            if (Input.GetKeyDown(KeyCode.Alpha3)) LoadScene(SCENE_3);
            if (Input.GetKeyDown(KeyCode.Alpha4)) LoadScene(SCENE_4);
        }

        private void LoadScene(string sceneName)
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

            // todo additional events when loading a new scene

            async.allowSceneActivation = true;

            waitFading = true;
            Fader.Instance.FadeOut(() => waitFading = false);

            while (waitFading)
                yield return null;

            _isLoadiing = false;
        }
    }
}
