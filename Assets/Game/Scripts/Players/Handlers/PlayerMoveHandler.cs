#region

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
        private PlayerCharacter playerCharacter;

    #endregion

    #region Public Methods

        public void Tick()
        {
            // movement: fps * player's move speed * move direction
            // movement + player's pos
            var moveDirection = new Vector2(1 , 1);
            var movement      = Time.deltaTime * playerCharacter.MoveSpeed * moveDirection;
            playerCharacter.SetPos(movement + playerCharacter.GetPos());
        }

    #endregion
    }
}