#region

using Game.Scripts.Battle.Misc;
using Zenject;

#endregion

namespace Game.Scripts.Battle.Main
{
    public class BattlerInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<IDeltaTimeProvider>().To<DeltaTimeProvider>().AsSingle();
        }

    #endregion
    }
}