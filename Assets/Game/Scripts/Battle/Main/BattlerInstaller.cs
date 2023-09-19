#region

using Game.Scripts.Battle.Handlers;
using Game.Scripts.Battle.Misc;
using Game.Scripts.Battle.States;
using Zenject;

#endregion

namespace Game.Scripts.Battle.Main
{
    public class BattlerInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<GameState>().AsSingle();
            Container.Bind<InputState>().AsSingle();

            Container.BindInterfacesAndSelfTo<TimeProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<Movable>().AsSingle();
            Container.BindInterfacesTo<InputHandler>().AsSingle();
            Container.BindInterfacesTo<GamePauseHandler>().AsSingle();

            Container.BindExecutionOrder<InputHandler>(-10000);
        }

    #endregion
    }
}