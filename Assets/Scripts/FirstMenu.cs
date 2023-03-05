using UnityEngine;

namespace TDS
{
    public class FirstMenu : MonoBehaviour
    {
        public void NextLVL()
            => LVLManager._instance.LoadNextScene();
    }
}
