using System;
using Commons.Interface;
using UniRx;
using UnityEngine;
using Zenject;

namespace Player
{
    //TODO:コメントを書こう
    //TODO:移動を単純な物ではなく、浮力や水力、波の影響を受けたリアルな移動方法に
    //変更する
    /// <summary>
    /// 
    /// </summary>
    public class PlayerPresenter : MonoBehaviour, IDamagable , IPushable
    {
        [Inject] private PlayerModel _model;
        [SerializeField] private PlayerView _view;

        private Rigidbody _rigidbody;
        
        /// <summary>
        /// 
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

        //もっとも良い方法があるはず
        public void Bind()
        {
            _view.OnStateExit()
               .Where(info => info.StateInfo.normalizedTime>=1.0f)
                .Subscribe(_=> OnAnimationCallBack())
                .AddTo(this);
        }

        /// <summary>
        ///       
        /// </summary>
        public void SetEvent()
        {
            _model.OnHpOverBack += () => _view.SetDie();
        }

        /// <summary>
        /// 
        /// </su
        public void ManualUpdate(float deltaTime)
        {
            _model.ManualUpdate(_view.InputSpeed(), _view.InputMove());
            _view.ManualUpdate(_model.Pos, _model.Rotation, Time.deltaTime);
        }


        /// <summary>
        /// 
        /// </summary>
        public void Swim()
        {
            _view.SetSwim();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Walk()
        {
            _view.SetWalk();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Damage()
        {
            _model.UpdateHp();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Push(Action OnCallBack)
        {
            _rigidbody.AddForce(new Vector3(0, 0, -30));
        }
    }
}