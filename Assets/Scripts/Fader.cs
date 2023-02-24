using System;
using UnityEngine;
using UnityEngine.UI;

namespace TDS
{
    public class Fader : MonoBehaviour
    {
        private const string FADER_PATH = "Prefabs/Others/FaderCanvas";

        [SerializeField]
        private Animator _animator;

        public static Fader _instance;

        public static Fader Instance
        {
            get 
            {
                if(_instance == null)
                {
                    var prefab = Resources.Load<Fader>(FADER_PATH);
                    _instance = Instantiate(prefab);
                    DontDestroyOnLoad(_instance.gameObject);
                }
                return _instance;
            }
        }

        public static bool IsFading { get; private set; }

        private Action _fadedInCallBack;
        private Action _fadedOutCallBack;

        public void FadeIn(Action fadedInCallBack)
        {
            if (IsFading) return;
            _fadedInCallBack = fadedInCallBack;
            IsFading = true;
            _animator.SetBool("Faded", true);
        }

        public void FadeOut(Action fadedOutCallBack)
        {
            if (IsFading) return;
            _fadedOutCallBack = fadedOutCallBack;
            IsFading = true;
            _animator.SetBool("Faded", false);
        }

        private void HandleFadeInAnimationOver()
        {
            _fadedInCallBack?.Invoke();
            _fadedInCallBack = null;
            IsFading = false;
        }

        private void HandleFadeOutAnimationOver()
        {
            _fadedOutCallBack?.Invoke();
            _fadedOutCallBack = null;
            IsFading = false;
        }

        //public void FaderInactive()
        //{
        //    var image = GetComponentInChildren<Image>();
        //    image.gameObject.SetActive(false);
        //    IsFading = false;
        //}
    }
}
