using Commons.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace RipCurrent
{
    public class RipCurrentPresenter : MonoBehaviour
    {
        private RipCurrentModel _model;
        [SerializeField] private RipCurrentView _view;

        public void Initialized()
        {
            _model = new RipCurrentModel();
            _view.Initialized();
        }

        /// <summary>
        /// 衝突判定
        /// </summary>
        public void OnCollisionEnter()
        {
            this.gameObject.OnTriggerEnterAsObservable()
                .Subscribe(target =>
                {
                    var hit = target.gameObject.GetComponent<IDamagable>();
                    hit?.Damage();
                }).AddTo(this);
        }
    }
}