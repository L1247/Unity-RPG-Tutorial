#region

using UnityEngine;

#endregion

namespace Game.Scripts.Battle.Misc
{
    public interface ITimeProvider
    {
    #region Public Methods

        float GetDeltaTime();

    #endregion
    }

    public class TimeProvider : ITimeProvider
    {
    #region Public Methods

        public float GetDeltaTime()
        {
            return Time.deltaTime;
        }

    #endregion
    }
}