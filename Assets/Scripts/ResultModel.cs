using UniRx;
using UnityEngine;

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

        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {
            //TODO:シングルトンでGetしたものを入れる
            //ここでGetする
            _isClearProp = new BoolReactiveProperty(false);
        }
    }
}