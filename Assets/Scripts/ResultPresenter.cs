using System;
using Commons.Utility;
using Description;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Result
{
    public class ResultPresenter : MonoBehaviour
    {
        [SerializeField] private DescriptionPresenter _descriptionPresenter;
        [SerializeField] private ResultView _view;
        [SerializeField] private ResultModel _model;
        
        [SerializeField] private AssetReference _titleScene;
        [SerializeField] private AssetReference _inGameScene;
        
        
        // Start is called before the first frame update
        private void Start()
        {
            Initialize();
            Bind();
            SetEvent();
        }

        private void Initialize()
        {
            _view.Initialize();
            _model.Initialize();
        }

        private void Bind()
        {
            _model.IsClearProp
                .Subscribe(_view.SetResult)
                .AddTo(this.gameObject);
        }

        private void SetEvent()
        {
            _view.OnClickTitleButton()
                .Subscribe(_=>SceneTransition.LoadScene(_titleScene))
                .AddTo(this.gameObject);
            
            _view.OnClickPlayButton()
                .Subscribe(_=>SceneTransition.LoadScene(_inGameScene))
                .AddTo(this.gameObject);

            _view.OnClickDescriptionButton()
                .Subscribe(_=>_descriptionPresenter?.Show())
                .AddTo(this.gameObject);

            _view.OnClickCloseButton()
                .Subscribe(_=>_descriptionPresenter.Hide())
                .AddTo(this.gameObject);
        }
    }
}