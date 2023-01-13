using Commons.Enum;
using UniRx;
using UnityEngine;

namespace InGame
{
    public class InGameModel : MonoBehaviour
    {
        private EnumReactiveProperty _stateProp;
        public IReadOnlyReactiveProperty<InGameEnum.State> StatePrp => _stateProp;

        public InGameEnum.State State => _stateProp.Value;

        public void Initialized()
        {
            _stateProp = new EnumReactiveProperty(InGameEnum.State.WaitStart);
        }

        /// <summary>
        /// Enumを書き換える
        /// </summary>
        /// <param name="state"></param>
        public void UpdateState(InGameEnum.State state)
        {
            _stateProp.Value = state;
        }
    }
}