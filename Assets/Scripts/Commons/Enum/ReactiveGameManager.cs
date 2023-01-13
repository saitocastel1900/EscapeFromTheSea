using System;
using UniRx;
using UnityEngine;

namespace Commons.Enum
{
    public class ReactiveGameManager : MonoBehaviour
    {
        public IReadOnlyReactiveProperty<InGameEnum.State> State => _state;
        private EnumReactiveProperty _state;
        
        void Start()
        {
    
            /*
            _state
                .DistinctUntilChanged()
                .Where(x => x != InGameEnum.State.Ahead)
                .Subscribe(_ => { Result(); }).AddTo(this);
            */
        }

        private void Update()
        {
           
        }

        void Result()
        {
            //GUI‚Ì•\Ž¦‚Æ‚©... 
        }

        private void UpdateValue(InGameEnum.State state)
        {
            _state.Value = state;
        }
    }
}