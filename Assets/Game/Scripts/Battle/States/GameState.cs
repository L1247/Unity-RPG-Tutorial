namespace Game.Scripts.Battle.States
{
    public class GameState
    {
    #region Public Variables

        public bool Pause { get; private set; }

    #endregion

    #region Public Methods

        public void SetPauseState(bool pause)
        {
            var DoNothingIfSameValue = pause == Pause;
            if (DoNothingIfSameValue) return;
            Pause = pause;
        }

    #endregion
    }
}