using System;
using UnityEngine;

namespace TDS
{
    public class Fader : MonoBehaviour
    {
        //private const string FaderPath = "Fader";

        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private ChapterManager _chapterManager;
        
        public static Fader instance;

        private void Start()
        {
            instance = this;
        }
        //public static Fader Instance 
        //{ 
        //    get 
        //    {
        //        if (instance == null) instance = this;
        //        //if(instance == null)
        //        //{
        //        //    var prefab = Resources.Load<Fader>(FaderPath);
        //        //    instance = Instantiate(prefab);
        //        //    DontDestroyOnLoad(instance.gameObject);
        //        //}
        //        //return instance;
        //    } 
        //}

        public bool IsFading { get; private set; }

        private Action _fadedInCallBack;
        private Action _fadedOutCallBack;

        public void FadeIn(Action fadedInCallBack)
        {
            if (IsFading) return;

            IsFading = true;
            _fadedInCallBack = fadedInCallBack;
            _animator.SetBool("Faded", true);
        }

        public void FadeOut(Action fadedOutCallBack)
        {
            if (IsFading) return;

            IsFading = true;
            _fadedOutCallBack = fadedOutCallBack;
            _animator.SetBool("Faded", false);
        }

        private void HandleFadeInAnimationOver()
        {
            _fadedInCallBack.Invoke();
            _fadedInCallBack = null;
            IsFading = false;
        }

        private void HandleFadeOutAnimationOver()
        {
            if (_chapterManager.CurrentChapter != Chapter.Non) _fadedOutCallBack.Invoke();  
            
            _fadedOutCallBack = null;
            IsFading = false;
        }
    }
}
