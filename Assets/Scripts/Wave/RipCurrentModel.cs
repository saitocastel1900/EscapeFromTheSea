using UniRx;
using UnityEngine;

namespace RipCurrent
{
    public class RipCurrentModel
    {
        //TODO:プレイヤーの場所を比較して、波がプレイヤーを押す力を調整
        //TODO:何かしらのデータをセットする
        private ReactiveProperty<Vector3> _posProp;
        public IReactiveProperty<Vector3> PosProp => _posProp;

        public RipCurrentModel()
        {
            _posProp = new ReactiveProperty<Vector3>(Vector3.zero);
        }

        public void UpdatePos(Vector3 pos)
        {
            _posProp.Value = pos;
        }
    }
}