using UniRx;
using UnityEngine;

namespace Description
{
    public class DescriptionPresenter : MonoBehaviour
    {
        [SerializeField] private DescriptionModel _model;
        [SerializeField] private DescriptionView _view;

        // Start is called before the first frame update
        private void Start()
        {
            Initialize();
            Bind();
            SetEvent();
        }

        private void Initialize()
        {
            _model.Initialize();
            _view.Initialize();
        }

        private void Bind()
        {
            _model.SlideCurrentNumProp
                .DistinctUntilChanged()
                .Subscribe(_view.SetSlide)
                .AddTo(this.gameObject);
        }

        private void SetEvent()
        {
            _view.OnClickNextButton()
                .Subscribe(_=>_model.AddSlideNum())
                .AddTo(this.gameObject);

            _view.OnClickBackButton()
                .Subscribe(_=>_model.SubSlideNum())
                .AddTo(this.gameObject);
        }
    }
}