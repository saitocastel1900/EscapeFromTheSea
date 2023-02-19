using System;
using UniRx;
using UnityEngine;

namespace Score
{
    public class TimerPresenter : MonoBehaviour
    {
        /// <summary>
        /// 時間がゼロになったら呼ばれる
        /// </summary>
        public event Action OnTimeOverBack;
        
        /// <summary>
        /// Model
        /// </summary>
        private TimerModel _model;
        
        /// <summary>
        /// View
        /// </summary>
        [SerializeField] private TimerView _view;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialized()
        {
            _model = new TimerModel();
            _view.Initialize();
        }

        /// <summary>
        /// Bind
        /// </summary>
        public void Bind()
        {
            //タイマーが変更されたら、表記もUpdateする
            _model.TimeProp
                .DistinctUntilChanged()
                .Subscribe(time=>_view.UpdateText(time)).AddTo(this);
        }

        /// <summary>
        /// イベントを設定
        /// </summary>
        public void SetEvent()
        {
            _model.OnTimeOverBack += () => OnTimeOverBack?.Invoke();
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