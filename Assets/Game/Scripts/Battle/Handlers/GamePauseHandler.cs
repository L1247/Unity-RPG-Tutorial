#region

using Game.Scripts.Battle.Misc;
using Game.Scripts.Battle.States;
using rStarUtility.Util.Extensions.Unity;
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

        [Inject(Id = "Panel - Pause")]
        private RectTransform panelPause;

    #endregion

    #region Public Methods

        public void Tick()
        {
            if (inputState.PauseKeyDown == false) return;
            var pause         = gameState.Pause;
            var newPauseState = !pause;
            panelPause.SetActive(newPauseState);
            gameState.SetPauseState(newPauseState);
        }

    #endregion
    }
}