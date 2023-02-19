using System;
using Commons.Interface;
using UniRx;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerPresenter : MonoBehaviour, IDamagable , IPushable
    {
        /// <summary>
        /// Model
        /// </summary>
        [Inject] private PlayerModel _model;
        
        /// <summary>
        /// View
        /// </summary>
        [SerializeField] private PlayerView _view;
        
        private Rigidbody _rigidbody;
        
        /// <summary>
        /// アニメーション終了時に呼ばれる
        /// </summary>
        public event Action OnAnimationCallBack;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialized()
        {
            _view.Initialized();
            TryGetComponent(out _rigidbody);
        }

        /// <summary>
        /// Bind
        /// </summary>
        public void Bind()
        {
            _view.OnStateExit()
               .Where(info => info.StateInfo.normalizedTime>=1.0f)
                .Subscribe(_=> OnAnimationCallBack())
                .AddTo(this);
        }

        /// <summary>
        /// イベント設定      
        /// </summary>
        public void SetEvent()
        {
            _model.OnHpOverBack += () => _view.SetDie();
        }

        /// <summary>
        /// 手動Update
        /// <summary>
        public void ManualUpdate(float deltaTime)
        {
            _model.UpdateMove(_view.SetSpeed(), _view.GetDirection());
            _view.ManualUpdate(_model.Pos, _model.Rotation, Time.deltaTime);
        }


        /// <summary>
        /// 泳ぐ
        /// </summary>
        public void Swim()
        {
            _view.SetSwim();
        }

        /// <summary>
        /// 歩く
        /// </summary>
        public void Walk()
        {
            _view.SetWalk();
        }

        /// <summary>
        /// 負傷
        /// </summary>
        public void Damage()
        {
            _model.UpdateHp();
        }

        /// <summary>
        /// 押される
        /// </summary>
        public void Push(Action OnCallBack)
        {
            _rigidbody.AddForce(new Vector3(0, 0, -30));
        }
    }
}