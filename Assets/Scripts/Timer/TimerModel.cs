using UniRx;
using UnityEngine;
using System;

namespace Score
{
    public class TimerModel
    {
        /// <summary>
        /// 
        /// </summary>
        public event Action OnCallback;
        
        private FloatReactiveProperty _timeProp;
        public IReactiveProperty<float> TimeProp => _timeProp;
        private float Time => _timeProp.Value;
        
        public TimerModel()
        {
            _timeProp = new FloatReactiveProperty(30);
        }

        public void ManualUpdate(float deltaTime)
        {
            UpdateTime(deltaTime);
        }

        private void UpdateTime(float time)
        {
            var value =Mathf.Clamp(Time - time,0.0f,60.0f);
            _timeProp.Value = value;

            if (_timeProp.Value <= 0)
            {
                Debug.Log("コールバックが呼ばれました");
                OnCallback?.Invoke();
            }
        }
    }
}