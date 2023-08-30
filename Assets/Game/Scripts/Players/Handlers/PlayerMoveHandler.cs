#region

using Game.Scripts.Battle.Misc;
using Game.Scripts.Names;
using Game.Scripts.Players.Main;
using UnityEngine;
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
        private ITimeProvider timeProvider;

    #endregion

    #region Public Methods

        public void Tick()
        {
            // movement: fps * player's move speed * move direction
            // newPos = movement + player's pos
            // set player's character position by new position. 
            var moveSpeed = character.GetStatFinalValue(StatNames.MoveSpeed);
            var movement  = timeProvider.GetDeltaTime() * moveSpeed * inputState.MoveDirection;
            var newPos    = movement + character.GetPos();
            character.SetPos(newPos);
        }

    #endregion
    }
}