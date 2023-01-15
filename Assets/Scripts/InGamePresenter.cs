using Commons.Enum;
using Commons.Interface;
using Gauge;
using Player;
using RipCurrent;
using Score;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace InGame
{
    public class InGamePresenter : MonoBehaviour
    {
        [SerializeField] private InGameView _view;
        [SerializeField] private InGameModel _model;

        [SerializeField] private RipCurrentPresenter _ripCurrent;
        [SerializeField] private PlayerPresenter _player;
        [SerializeField] private TimerPresenter _timer;
        [Inject] private GaugePresenter _gauge;

        [SerializeField] private string _resultScene;
        
        [Inject]
        private IDataHolder _data;
        
        private void Start()
        {
            Initialized();
            Bind();
            SetEvent();
        }

        private void Update()
        {
            _player.ManualUpdate(Time.deltaTime);
            _timer.ManualUpdate(Time.deltaTime);
        }

        /// <summary>
        /// 
        /// </summary>
        private void Initialized()
        {
            _view.Initialized();
            _model.Initialized();
            _player.Initialized();
            _gauge.Initialized();
         //   _ripCurrent.Initialized();
            _timer.Initialized();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Bind()
        {
            _player.Bind();
            
           // _ripCurrent.OnCollisionEnter();

            _gauge.Bind();
            
            _model.StatePrp
                .DistinctUntilChanged().Subscribe(OnStateChanged).AddTo(this);
            
            _timer.Bind();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetEvent()
        {
            _timer.OnTimeOverBack += () => GameFinish(true);
            _player.OnHpOverBack += () => GameFinish(false);
            
            _timer.SetEvent();
            _player.SetEvent();
            //_gauge.SetEvent();
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnStateChanged(InGameEnum.State state)
        {
            switch (state)
            {
               
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void GameFinish(bool value)
        {
            
            _data.Set(value);
            Debug.Log(_data.Get());
            SceneManager.LoadScene(_resultScene);
        }
    }
}