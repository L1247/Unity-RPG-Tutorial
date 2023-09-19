namespace Game.Scripts.Battle.Misc
{
    public class InputState
    {
    #region Public Variables

        public bool PauseKeyDown { get; private set; }

        public int Horizontal { get; private set; }
        public int Vertical   { get; private set; }

    #endregion

    #region Public Methods

        public void SetHorizontal(int horizontal)
        {
            Horizontal = horizontal;
        }

        public void SetPauseKeyDown(bool pauseKeyDown)
        {
            PauseKeyDown = pauseKeyDown;
        }

        public void SetVertical(int vertical)
        {
            Vertical = vertical;
        }

    #endregion
    }
}