using System;
using Commons.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Player
{
    //TODO:コメントを書こう
    //TODO:移動を単純な物ではなく、浮力や水力、波の影響を受けたリアルな移動方法に
    //変更する
    public class PlayerPresenter : MonoBehaviour, IDamagable
    {
        [Inject] private PlayerModel _model;
        [SerializeField] private PlayerView _view;
        
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
        }

        //もっとも良い方法があるはず
        public void Bind()
        {
            _view.OnStateExit()
               .Where(info => info.StateInfo.normalizedTime>=1.0f)
                .Subscribe(_=> OnAnimationCallBack())
                .AddTo(this);
        }

        public void SetEvent()
        {
            _model.OnHpOverBack += () => _view.SetDie();
        }

        public void ManualUpdate(float deltaTime)
        {
            _model.ManualUpdate(_view.InputSpeed(), _view.InputMove());
            _view.ManualUpdate(_model.Pos, _model.Rotation, Time.deltaTime);
        }

        public void Swim()
        {
            _view.SetSwim();
        }

        public void Walk()
        {
            _view.SetWalk();
        }

        public void Damage()
        {
            _model.UpdateHp();
        }
    }
}