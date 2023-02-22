using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class ChapterManager : MonoBehaviour
    {
        public bool IsAsyncLoaded { get; private set; }
        public Chapter CurrentChapter { get; private set; }
        public Chapter NextChapter { get; private set; }

        public static ChapterManager instance;

        private void Awake()
        {
            instance = this;
            CurrentChapter = Chapter.Non;
        }

        public IEnumerator LoadSceneAsync(GameObject LVL)
        {
            IsAsyncLoaded = false;

            //yield return new WaitForSeconds(3); // заглушка
            LVL.SetActive(true);



            IsAsyncLoaded = true;
            NextChapter = ReturnNextChapter();
            yield return null;
        }
        public IEnumerator UnLoadSceneAsync(GameObject LVL)
        {
            LVL.SetActive(false);
            yield return null;
        }

            public Chapter ReturnNextChapter()
        {
            Chapter nextChapter;
            switch (CurrentChapter)
            {
                case Chapter.Non:
                    nextChapter = Chapter.RoutineTask;
                    break;
                case Chapter.RoutineTask:
                    nextChapter = Chapter.FirstMeeting;
                    break;
                case Chapter.FirstMeeting:
                    nextChapter = Chapter.TheIceHasBroken;
                    break;
                case Chapter.TheIceHasBroken:
                    nextChapter = Chapter.LookUp;
                    break;
                default:
                    nextChapter = Chapter.Non;
                    break;
            }
            return nextChapter;
        }
    }
}
