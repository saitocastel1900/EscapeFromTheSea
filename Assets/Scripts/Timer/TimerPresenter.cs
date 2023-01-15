using System;
using UniRx;
using UnityEngine;

namespace Score
{
    public class TimerPresenter : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        public event Action OnTimeOverBack;
        
        private TimerModel _model;
        [SerializeField] private TimerView _view;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialized()
        {
            _model = new TimerModel();
            _view.Initialize();
        }

        public void Bind()
        {
            _model.TimeProp
                .DistinctUntilChanged()
                .Subscribe(time=>_view.UpdateText(time)).AddTo(this);

            // スコアが変更された表示も変更
            //_model.OnSetScore += _view.SetScore;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetEvent()
        {
            _model.OnCallback += () => OnTimeOverBack?.Invoke();
        }

        /// <summary>
        /// スコアを加算
        /// </summary>
        public void ManualUpdate(float deltaTime)
        {
            _model.ManualUpdate(deltaTime);
        }
    }
}