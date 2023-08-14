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
            Container.BindInterfacesTo<PlayerMoveHandler>().AsSingle();
        }

    #endregion
    }
}