using UnityEngine;

namespace Input
{
    public class KeyInputMoveProvider : IInputMoveProvider
    {
        /// <summary>
        /// Wキー入力
        /// </summary>
        public bool InputAhead()
        {
            return UnityEngine.Input.GetKey(KeyCode.W);
        }

        /// <summary>
        /// Aキー入力
        /// </summary>
        public bool InputLeft()
        {
            return UnityEngine.Input.GetKey(KeyCode.A);
        }

        /// <summary>
        /// Dキー入力
        /// </summary>
        public bool InputRight()
        {
            return UnityEngine.Input.GetKey(KeyCode.D);
        }

        /// <summary>
        /// Sキー入力
        /// </summary>
        public bool InputBack()
        {
            return UnityEngine.Input.GetKey(KeyCode.S);
        }

        /// <summary>
        /// Shiftキー入力
        /// </summary>
        public bool InputSpeedUp()
        {
            return UnityEngine.Input.GetKey(KeyCode.LeftShift);
        }
    }
}