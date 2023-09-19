#region

using Game.Scripts.Battle.Misc;
using rStarUtility.Util.Extensions.Unity;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

#endregion

namespace Game.Scripts.Battle.Handlers
{
    public class InputKeyUIHandler : ITickable
    {
    #region Private Variables

        [Inject(Id = "Up")]
        private Image up;

        [Inject(Id = "Down")]
        private Image down;

        [Inject(Id = "Left")]
        private Image left;

        [Inject(Id = "Right")]
        private Image right;

        [Inject]
        private InputState inputState;

        private readonly Color keyDownColor = Color.white;
        private readonly Color keyUpColor   = Color.gray.WithA(0.5f);

    #endregion

    #region Public Methods

        public void Tick()
        {
            left.color  = inputState.Horizontal == -1 ? keyDownColor : keyUpColor;
            right.color = inputState.Horizontal == 1 ? keyDownColor : keyUpColor;
            up.color    = inputState.Vertical == 1 ? keyDownColor : keyUpColor;
            down.color  = inputState.Vertical == -1 ? keyDownColor : keyUpColor;
        }

    #endregion
    }
}