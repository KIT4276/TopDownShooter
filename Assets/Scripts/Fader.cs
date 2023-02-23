using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class Fader : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        //public static Fader instance;

        private void Start()
        {
            //instance = this;
        }

        public bool IsFading { get; private set; }


        public void FadeIn()
        {
            if (IsFading) return;

            IsFading = true;
            _animator.SetBool("Faded", true);
        }

        public void FadeOut()
        {
            if (IsFading) return;

            IsFading = true;
            _animator.SetBool("Faded", false);
        }

        private void HandleFadeInAnimationOver()
        {
            IsFading = false;
        }

        private void HandleFadeOutAnimationOver()
        {
            IsFading = false;
        }

        //public void FaderActive()
        //{
        //    gameObject.SetActive(true);
        //    Debug.Log("FaderActive");
        //}

        public void FaderInactive()
        {
            gameObject.SetActive(false);
            Debug.Log("FaderInactive");
        }
        }
}
