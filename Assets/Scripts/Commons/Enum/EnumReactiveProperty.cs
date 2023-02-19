using UniRx;

namespace Commons.Enum
{
    [System.Serializable]
    public class EnumReactiveProperty : ReactiveProperty<InGameEnum.State>
    {
        //�R���X�g���N�^
        public EnumReactiveProperty()
        {
        }

        public EnumReactiveProperty(InGameEnum.State initialValue) : base(initialValue)
        {
        }
    }
}