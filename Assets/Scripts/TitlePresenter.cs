using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Title
{
    /// <summary>
    /// 
    /// </summary>
    public class TitlePresenter : MonoBehaviour
    {
        [SerializeField] private TitleModel _model;
        [SerializeField] private TitleView _view;

        [SerializeField] private string _inGameScene;

        private void Start()
        {
            Initialized();
            Bind();
            SetEvent();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Initialized()
        {
            _model.Initialized();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Bind()
        {
            _model.IsPushProp
                .Where(_ => _model.IsPush)
                .DistinctUntilChanged()
                .Subscribe(_ => SceneManager.LoadScene(_inGameScene)).AddTo(this);
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetEvent()
        {
            _view.OnClickPlay()
                .First()
                .Subscribe(_ => _model.GamePlay(true))
                .AddTo(this);

            _view.OnClickExit()
                .First()
                .Subscribe(_ => GameQuite())
                .AddTo(this);
        }

        private void GameQuite()
        {
            #if UNITY_WEBGL
                Application.OpenURL("about:blank");
            #elif UNITY_EDITOR
                Application.Quit();
            #endif
        }
    }
}