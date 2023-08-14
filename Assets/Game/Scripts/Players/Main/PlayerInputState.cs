#region

using UnityEngine;

#endregion

namespace Game.Scripts.Players.Main
{
    public class PlayerInputState
    {
    #region Public Variables

        public float   Horizontal    { get; private set; }
        public float   Vertical      { get; private set; }
        public Vector2 MoveDirection => new Vector2(Horizontal , Vertical);

    #endregion

    #region Public Methods

        public void SetHorizontal(float horizontal)
        {
            Horizontal = horizontal;
        }

        public void SetVertical(float vertical)
        {
            Vertical = vertical;
        }

    #endregion
    }
}