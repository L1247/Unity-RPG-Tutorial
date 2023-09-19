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
        private Mover mover;

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
            var moveSpeed = mover.MoveSpeed;
            var movement  = timeProvider.GetDeltaTime() * moveSpeed * inputState.MoveDirection;
            var newPos    = movement + mover.GetPos();
            mover.SetPos(newPos);
        }

    #endregion
    }
}