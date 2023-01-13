using Gauge;
using Player;
using UnityEngine;
using Zenject;

public class GaugeInstaller : MonoInstaller
{
    [SerializeField]
    Transform _playerTransform;
    
    public override void InstallBindings()
    {
        Container.Bind<GaugePresenter>().FromNew().AsCached().NonLazy();
        Container.Bind<PlayerModel>().FromNew().AsCached().WithArguments(_playerTransform);
    }
}