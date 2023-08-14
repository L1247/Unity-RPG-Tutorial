#region

using Game.Scripts.Players.Main;
using UnityEngine;
using Zenject;

#endregion

namespace Game.Scripts.Players.Handlers
{
    public class PlayerInputHandler : ITickable
    {
    #region Private Variables

        [Inject]
        private PlayerInputState inputState;

    #endregion

    #region Public Methods

        public void Tick()
        {
            inputState.SetHorizontal(Input.GetAxisRaw("Horizontal"));
            inputState.SetVertical(Input.GetAxisRaw("Vertical"));
        }

    #endregion
    }
}