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
        
       CompositeDisposable disposables = new CompositeDisposable();
       
       public GaugePresenter(PlayerModel model, GaugeView view)
       {
           _model = model;
           _view = view;
       }

       public void Initialized()
       {
           _view.Initialized();
       }

       public void Bind()
        {
            //model=>view
            _model.HpProp
                .DistinctUntilChanged()
                .Subscribe(x =>
                    {
                        Debug.Log("ゲージの値です："+x);
                        _view.UpdateText(x);
                        _view.GaugeValue = x;
                        _view.GaugeAnimation();
                    },
                    ex => Debug.LogError("OnError!"),
                    () => Debug.Log("OnCompleted!")).AddTo(disposables);
        }

       public void Dispose()
        {
            disposables.Dispose();
        }
    }
}