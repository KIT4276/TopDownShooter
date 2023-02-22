using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class FirstMenu : MonoBehaviour
    {
        public void NextLVL()
        {
            SceneLoader.instance.LoadScene(Chapter.RoutineTask);
            Debug.Log("NextLVL");
        }
    }
}
