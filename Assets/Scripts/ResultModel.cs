using Commons.Interface;
using UniRx;
using UnityEngine;
using Zenject;

namespace Result
{
    public class ResultModel : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        public IReactiveProperty<bool> IsClearProp => _isClearProp;
        public bool IsClear => _isClearProp.Value;
        private BoolReactiveProperty _isClearProp;

        [Inject]
        private IDataHolder _data;
        
        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {
            _isClearProp = new BoolReactiveProperty(_data.Get());
        }
    }
}