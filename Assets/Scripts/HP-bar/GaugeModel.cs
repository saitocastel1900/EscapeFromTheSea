using System;
using UniRx;
using UnityEngine;

namespace Gauge
{
    public class GaugeModel
    {
        public IReadOnlyReactiveProperty<int> Value => _value;
        private IntReactiveProperty _value;
        
        public event Action OnCallback;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="value"></param>
        public GaugeModel()
        {
            _value=new IntReactiveProperty(0);
        }

        /// <summary>
        /// スコアを更新（加算）
        /// </summary>
        /// <param name="value"></param>
        public void UpdateCount(int value)
        {
            _value.Value = Mathf.Clamp(value, 0, 10);
            if (_value.Value >= 10) OnCallback?.Invoke();
        }
    }
}