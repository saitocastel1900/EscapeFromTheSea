using System;
using Commons.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace RipCurrent
{
    public class RipCurrentPresenter : MonoBehaviour
    {
        /// <summary>
        /// 波に入った際に呼べれる
        /// </summary>
        public event Action OnSeaEnterBack;

        /// <summary>
        /// 波を出た際に呼ばれる
        /// </summary>
        public event Action OnSeaExitBack;

        /// <summary>
        /// Model
        /// </summary>
        private RipCurrentModel _model;
        
        /// <summary>
        /// View
        /// </summary>
        [SerializeField] private RipCurrentView _view;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialized()
        {
            _model = new RipCurrentModel();
            _view.Initialized();
        }

        /// <summary>
        /// Bind
        /// </summary>
        public void Bind()
        {
            //波に入ったらコールバックが呼ばれる
            this.gameObject.OnTriggerEnterAsObservable()
                .Subscribe(target=>
                {
                    OnSeaEnterBack?.Invoke();
                }).AddTo(this);
            
            //波に一定時間いたら、ダメージを受ける
            _view.OnTriggerEnterStay()
                .Where(target => target.gameObject.TryGetComponent<IDamagable>(out var t))
                .Buffer(60)
                .Subscribe(target=>
                {
                    if (target[0]!=null)
                    {
                        var hit = target[0]?.gameObject?.GetComponent<IDamagable>();
                        hit?.Damage();
                    }
                }).AddTo(this);
            
            //波にいる間押される
            _view.OnTriggerEnterStay()
                .Where(target => target.gameObject.TryGetComponent<IPushable>(out var t))
                .Subscribe(target =>
                {
                    var hit = target.gameObject.GetComponent<IPushable>();
                    hit?.Push();
                }).AddTo(this);
            
            //波から出たらコールバックが呼ばれる
            this.gameObject.OnTriggerExitAsObservable()
                .Subscribe(_ =>
                {
                    OnSeaExitBack?.Invoke();
                }).AddTo(this);
        }
    }
}