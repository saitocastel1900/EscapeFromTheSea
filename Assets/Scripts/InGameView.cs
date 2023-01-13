using UnityEngine;

namespace InGame
{
    public class InGameView : MonoBehaviour
    {
        public void Initialized()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}