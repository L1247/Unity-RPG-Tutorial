namespace Game.Scripts.Battle.Misc
{
    public class InputState
    {
    #region Public Variables

        public bool PauseKeyDown { get; private set; }

    #endregion

    #region Public Methods

        public void SetPauseKeyDown(bool pauseKeyDown)
        {
            PauseKeyDown = pauseKeyDown;
        }

    #endregion
    }
}