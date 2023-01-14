using UniRx;
using UnityEngine;

namespace Description
{
    /// <summary>
    /// 
    /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        private void Initialize()
        {
            _model.Initialize();
            _view.Initialize();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Bind()
        {
            _model.SlideCurrentNumProp
                .DistinctUntilChanged()
                .Subscribe(_view.SetSlide)
                .AddTo(this.gameObject);
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetEvent()
        {
            _view.OnClickNextButton()
                .Subscribe(_=>_model.AddSlideNum())
                .AddTo(this.gameObject);

            _view.OnClickBackButton()
                .Subscribe(_=>_model.SubSlideNum())
                .AddTo(this.gameObject);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Show()
        {
            _view.Show();
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Hide()
        {
            _view.Hide();
        }
    }
}