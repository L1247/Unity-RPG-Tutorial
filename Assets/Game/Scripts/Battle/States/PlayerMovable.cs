#region

using Game.Scripts.Battle.Misc;
using Zenject;

#endregion

namespace Game.Scripts.Battle.States
{
    public class PlayerMovable : Movable
    {
    #region Private Variables

        [Inject]
        private GameState gameState;

    #endregion

    #region Public Methods

        public bool Get()
        {
            return gameState.Pause == false;
        }

    #endregion
    }
}