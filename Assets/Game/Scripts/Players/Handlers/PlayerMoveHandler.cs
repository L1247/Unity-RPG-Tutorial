#region

using Game.Scripts.Battle.Misc;
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
            // newPos = movement + player's pos
            // set player's character position by new position. 
            var movement = deltaTimeProvider.GetDeltaTime() * character.MoveSpeed * inputState.MoveDirection;
            var newPos   = movement + character.GetPos();
            character.SetPos(newPos);
        }

    #endregion
    }
}