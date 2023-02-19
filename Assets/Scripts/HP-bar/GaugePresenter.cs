using System;
using Player;
using UniRx;
using UnityEngine;

namespace Gauge
{
    public class GaugePresenter : IDisposable
    {
        //view
        private GaugeView _view;
        //model
        private PlayerModel _model;
        
       CompositeDisposable _disposables;
       
       /// <summary>
       /// コンストラクタ
       /// </summary>
       public GaugePresenter(PlayerModel model, GaugeView view)
       {
           _model = model;
           _view = view;
       }

       /// <summary>
       /// 初期化
       /// </summary>
       public void Initialized()
       {
           _view.Initialized();
           _disposables = new CompositeDisposable();
       }

       /// <summary>
       /// Bind
       /// </summary>
       public void Bind()
        {
            //model=>view
            //体力が減少したら体力ゲージのアニメーションを実行する
            _model.HpProp
                .DistinctUntilChanged()
                .Subscribe(x =>
                    {
                        _view.UpdateText(x);
                        _view.GaugeValue = x;
                        _view.GaugeAnimation();
                    },
                    ex => Debug.LogError("OnError!"),
                    () => Debug.Log("OnCompleted!")).AddTo(_disposables);
        }

       /// <summary>
       /// Dispose
       /// </summary>
       public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}