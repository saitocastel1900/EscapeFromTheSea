using UniRx;
using UnityEngine;

namespace Score
{
    public class ScorePresenter : MonoBehaviour
    {
        private ScoreModel _model;
        [SerializeField] private ScoreView _view;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Initialized()
        {
            _model = new ScoreModel();
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
        /// スコアを加算
        /// </summary>
        public void ManualUpdate(float deltaTime)
        {
            _model.ManualUpdate(deltaTime);
        }
    }
}