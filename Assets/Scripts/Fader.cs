using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TDS
{
    public class Fader : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private ChapterManager _chapterManager;

        public bool IsFading { get; private set; }

        private void Start()
        {
            if(_chapterManager.CurrentChapter != Chapter.Non)
            {
                _animator.SetBool("Faded", false);
            }
        }

        public void FadeIn()
        {
            //if (IsFading) return;
            //Debug.Log("FadeIn");
            IsFading = true;
            _animator.SetBool("Faded", true);
        }

        public void FadeOut()
        {
            //if (IsFading) return;
            //Debug.Log("FadeOut");
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

        public void FaderInactive()
        {
            var image = GetComponentInChildren<Image>();
            image.gameObject.SetActive(false);
        }
    }
}
