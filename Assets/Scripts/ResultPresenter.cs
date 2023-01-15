using Description;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Result
{
    public class ResultPresenter : MonoBehaviour
    {
        [SerializeField] private DescriptionPresenter _descriptionPresenter;
        [SerializeField] private ResultView _view;
        [SerializeField] private ResultModel _model;
        
        [SerializeField] private string _titleScene;
        [SerializeField] private string _inGameScene;
        
        
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
                .Subscribe(_=>SceneManager.LoadScene(_titleScene))
                .AddTo(this.gameObject);
            
            _view.OnClickPlayButton()
                .Subscribe(_=>SceneManager.LoadScene(_inGameScene))
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