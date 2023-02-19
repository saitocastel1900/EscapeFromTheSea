using UniRx;
using UnityEngine;

namespace RipCurrent
{
    public class RipCurrentModel
    {
        /// <summary>
        /// 波の位置座標
        /// </summary>
        public IReactiveProperty<Vector3> PosProp => _posProp;
        private ReactiveProperty<Vector3> _posProp;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RipCurrentModel()
        {
            _posProp = new ReactiveProperty<Vector3>(Vector3.zero);
        }

        /// <summary>
        /// 波の位置を更新
        /// </summary>
        public void UpdatePos(Vector3 pos)
        {
            _posProp.Value = pos;
        }
    }
}