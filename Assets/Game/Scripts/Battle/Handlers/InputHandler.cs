#region

using Game.Scripts.Battle.Misc;
using UnityEngine;
using Zenject;

#endregion

namespace Game.Scripts.Battle.Handlers
{
    public class InputHandler : ITickable
    {
    #region Private Variables

        [Inject]
        private InputState inputState;

    #endregion

    #region Public Methods

        public void Tick()
        {
            inputState.SetPauseKeyDown(Input.GetKeyDown(KeyCode.Escape));
            inputState.SetHorizontal((int)Input.GetAxisRaw("Horizontal"));
            inputState.SetVertical((int)Input.GetAxisRaw("Vertical"));
        }

    #endregion
    }
}