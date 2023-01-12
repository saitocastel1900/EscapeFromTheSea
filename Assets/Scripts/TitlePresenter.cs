using System;
using Commons.Utility;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Title
{
    public class TitlePresenter : MonoBehaviour
    {
        [SerializeField] private TitleModel _model;
        [SerializeField] private TitleView _view;

        [SerializeField] private AssetReference _scene;
        
        void Start()
        {
            Initialized();
            Bind();
            SetEvent();
        }
        
        private void Initialized()
        {
            _model.Initialized();
            _view.Initialized();
        }

        private void Bind()
        {
            _view.OnClickPlay()
                .First()
                .Subscribe(_=>_model.UpdatePush(true))
                .AddTo(this);

            _view.OnClickExit()
                .First()
                .Subscribe(_=>Application.OpenURL("about:blank"))
                .AddTo(this);
        }

        private void SetEvent()
        {
            _model.IsPushProp
                .Where(_=>_model.IsPush)
                .DistinctUntilChanged()
                .Subscribe(_=>SceneTransition.LoadScene(_scene)).AddTo(this);
        }
    }
}