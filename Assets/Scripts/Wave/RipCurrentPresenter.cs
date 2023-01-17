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
                    var hit = target.gameObject.GetComponent<IDamagable>();
                    hit?.Damage();
                    OnSeaEnterBack?.Invoke();
                }).AddTo(this);

            //
            this.gameObject.OnTriggerStayAsObservable()
                .Subscribe(target=>
                {
                   
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