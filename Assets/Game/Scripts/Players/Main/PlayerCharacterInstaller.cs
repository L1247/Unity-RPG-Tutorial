#region

using Game.Scripts.Players.Handlers;
using Zenject;

#endregion

namespace Game.Scripts.Players.Main
{
    public class PlayerCharacterInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<PlayerInputState>().AsSingle();

            Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerMoveHandler>().AsSingle();

            Container.BindExecutionOrder<PlayerInputHandler>(-10000);
        }

    #endregion
    }
}