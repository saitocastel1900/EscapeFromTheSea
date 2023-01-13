using UnityEngine;

namespace Input
{
    public class KeyInputMoveProvider : IInputMoveProvider
    {
        public bool InputAhead()
        {
            return UnityEngine.Input.GetKey(KeyCode.W);
        }

        public bool InputLeft()
        {
            return UnityEngine.Input.GetKey(KeyCode.A);
        }

        public bool InputRight()
        {
            return UnityEngine.Input.GetKey(KeyCode.D);
        }

        public bool InputBack()
        {
            return UnityEngine.Input.GetKey(KeyCode.S);
        }

        public bool InputSpeedUp()
        {
            return UnityEngine.Input.GetKey(KeyCode.LeftShift);
        }
    }
}