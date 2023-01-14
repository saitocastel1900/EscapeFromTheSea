using Commons.Interface;
using InGame;
using Zenject;

namespace InGane
{
    public class InGameDataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IDataHolder>()
                .To<InGameData>()
                .AsSingle()
                .NonLazy();
        }
    }
}