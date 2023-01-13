using Commons.Interface;
using UniRx;
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
        /// 初期化
        /// </summary>
        public void Initialized()
        {
            _view.Initialized();
        }

        //もっとも良い方法があるはず
        public void Bind()
        {
            
        }

        public void ManualUpdate(float deltaTime)
        {
            _model.ManualUpdate(_view.InputSpeed(), _view.InputMove());
            _view.ManualUpdate(_model.Pos, _model.Rotation, Time.deltaTime);
        }

        public void Damage()
        {
            _model.UpdateHp();
        }
    }
}