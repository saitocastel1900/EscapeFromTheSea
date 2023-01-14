using UniRx;
using UnityEngine;

namespace Score
{
    public class ScoreModel
    {
        private FloatReactiveProperty _timeProp;
        public IReactiveProperty<float> TimeProp => _timeProp;
        private float Time => _timeProp.Value;
        
        public ScoreModel()
        {
            _timeProp = new FloatReactiveProperty(60);
        }

        public void ManualUpdate(float deltaTime)
        {
            UpdateTime(deltaTime);
        }

        private void UpdateTime(float time)
        {
            var value =Mathf.Clamp(Time - time,0.0f,60.0f);
            _timeProp.Value = value;
        }
    }
}