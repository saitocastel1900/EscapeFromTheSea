using Commons.Enum;
using Gauge;
using Player;
using RipCurrent;
using Score;
using UniRx;
using UnityEngine;
using Zenject;

namespace InGame
{
    public class InGamePresenter : MonoBehaviour
    {
        [SerializeField] private InGameView _view;
        [SerializeField] private InGameModel _model;

        [SerializeField] private RipCurrentPresenter _ripCurrent;
        [SerializeField] private PlayerPresenter _player;
        [SerializeField] private ScorePresenter _score;
        
        [Inject]
        private GaugePresenter _gauge;

        private void Start()
        {
            Initialized();
            Bind();
            SetEvent();
        }

        private void Update()
        {
            _player.ManualUpdate(Time.deltaTime);
            _score.ManualUpdate(Time.deltaTime);
        }

        private void Initialized()
        {
            _view.Initialized();
            _model.Initialized();
            _player.Initialized();
            _gauge.Initialized();
         //   _ripCurrent.Initialized();
            _score.Initialized();
        }

        private void Bind()
        {
            _player.Bind();
            
           // _ripCurrent.OnCollisionEnter();

            _gauge.Bind();
            
            _model.StatePrp
                .DistinctUntilChanged().Subscribe(OnStateChanged).AddTo(this);
            
            _score.Bind();
        }

        private void SetEvent()
        {
            //_gauge.SetEvent();
        }

        private void OnStateChanged(InGameEnum.State state)
        {
            switch (state)
            {
                
            }
        }
    }
}