#region

using Game.Scripts.Players.Handlers;
using UnityEngine;
using Zenject;

#endregion

namespace Game.Scripts.Players.Main
{
    public class PlayerCharacterInstaller : MonoInstaller
    {
    #region Private Variables

        [SerializeField]
        private float moveSpeed = 5f;

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            Container.Bind<float>().WithId("MoveSpeed").FromInstance(moveSpeed);
            Container.Bind<PlayerInputState>().AsSingle();

            Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
            Container.BindInterfacesTo<PlayerMoveHandler>().AsSingle();

            Container.BindExecutionOrder<PlayerInputHandler>(-10000);
        }

    #endregion
    }
}