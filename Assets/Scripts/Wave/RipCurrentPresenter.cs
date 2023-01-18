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
        /// 
        /// </summary>
        public event Action OnSeaEnterBack;

        /// <summary>
        /// 
        /// </summary>
        public event Action OnSeaExitBack;

        private RipCurrentModel _model;
        [SerializeField] private RipCurrentView _view;

        /// <summary>
        /// 
        /// </summary>
        public void Initialized()
        {
            _model = new RipCurrentModel();
            _view.Initialized();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Bind()
        {
            //
            this.gameObject.OnTriggerEnterAsObservable()
                .Subscribe(target=>
                {
                    OnSeaEnterBack?.Invoke();
                }).AddTo(this);
            
            //
            this.gameObject
                .OnTriggerStayAsObservable()
                .Where(target => target.gameObject.TryGetComponent<IDamagable>(out var t))
                //ここは変えた方が良い
                .Buffer(60)
                .Subscribe(target=>
                {
                    if (target[0]!=null)
                    {
                        var hit = target[0]?.gameObject?.GetComponent<IDamagable>();
                        hit?.Damage();
                    }
                }).AddTo(this);
            
            _view.OnTriggerEnterStay()
                .Where(target => target.gameObject.TryGetComponent<IPushable>(out var t))
                .Subscribe(target =>
                {
                    var hit = target.gameObject.GetComponent<IPushable>();
                    hit?.Push();
                }).AddTo(this);
            
            //
            this.gameObject.OnTriggerExitAsObservable()
                .Subscribe(_ =>
                {
                    OnSeaExitBack?.Invoke();
                }).AddTo(this);
        }
    }
}