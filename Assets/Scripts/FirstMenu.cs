using UnityEngine;

namespace TDS
{
    public class FirstMenu : MonoBehaviour
    {
        public void NextLVL()
            => GameManager._instance.NextLVL();
    }
}
