using UniRx;
using UnityEngine;

namespace Result
{
    public class ResultPresenter : MonoBehaviour
    {
        [SerializeField] private ResultView _view;
        [SerializeField] private ResultModel _model;
        
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
            
        }
    }
}