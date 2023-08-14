#region

using Game.Scripts.Players.Main;
using Zenject;

#endregion

namespace Game.Scripts.Players.Handlers
{
    public class PlayerMoveHandler : ITickable
    {
    #region Private Variables

        [Inject]
        private PlayerCharacter character;

        [Inject]
        private PlayerInputState inputState;

        [Inject]
        private IDeltaTimeProvider deltaTimeProvider;

    #endregion

    #region Public Methods

        public void Tick()
        {
            // movement: fps * player's move speed * move direction
            // movement + player's pos
            var movement = deltaTimeProvider.GetDeltaTime() * character.MoveSpeed * inputState.MoveDirection;
            character.SetPos(movement + character.GetPos());
        }

    #endregion
    }
}