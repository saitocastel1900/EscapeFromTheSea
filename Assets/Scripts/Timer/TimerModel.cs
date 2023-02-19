using UniRx;
using UnityEngine;
using System;
using Commons.Const;

namespace Score
{
    public class TimerModel
    {
        /// <summary>
        /// 時間がゼロにになったら呼ばれる
        /// </summary>
        public event Action OnTimeOverBack;

        /// <summary>
        /// タイマー
        /// </summary>
        public IReactiveProperty<float> TimeProp => _timeProp;
        private FloatReactiveProperty _timeProp;
        private float Time => _timeProp.Value;
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TimerModel()
        {
            _timeProp = new FloatReactiveProperty(30);
        }

        /// <summary>
        /// 手動Update
        /// </summary>
        public void ManualUpdate(float deltaTime)
        {
            UpdateTime(deltaTime);
        }

        /// <summary>
        /// 時間を設定
        /// </summary>
        private void UpdateTime(float time)
        {
            var value =Mathf.Clamp(Time - time,0.0f,InGameConst.MaxTime);
            _timeProp.Value = value;

            //タイマーがゼロになったら呼ばれる
            if (_timeProp.Value <= 0)
            {
                OnTimeOverBack?.Invoke();
            }
        }
    }
}