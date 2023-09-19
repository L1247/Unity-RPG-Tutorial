#region

using Game.Scripts.Battle.Misc;
using Game.Scripts.Battle.States;
using UnityEngine;
using Zenject;

#endregion

namespace Game.Scripts.Battle.Handlers
{
    public class GamePauseHandler : ITickable
    {
    #region Private Variables

        [Inject]
        private InputState inputState;

        [Inject]
        private GameState gameState;

    #endregion

    #region Public Methods

        public void Tick()
        {
            if (inputState.PauseKeyDown == false) return;
            var pause         = gameState.Pause;
            var newPauseState = !pause;
            Debug.Log($"Pause: {newPauseState}");
            gameState.SetPauseState(newPauseState);
        }

    #endregion
    }
}