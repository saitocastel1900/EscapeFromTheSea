namespace Input
{
    public interface IInputMoveProvider
    {
        public bool InputAhead();
        public bool InputLeft();
        public bool InputRight();
        public bool InputBack();
        public bool InputSpeedUp();
    }
}