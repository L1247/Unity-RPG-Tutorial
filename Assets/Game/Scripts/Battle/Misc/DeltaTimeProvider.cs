#region

using UnityEngine;

#endregion

namespace Game.Scripts.Battle.Misc
{
    public interface IDeltaTimeProvider
    {
    #region Public Methods

        float GetDeltaTime();

    #endregion
    }

    public class DeltaTimeProvider : IDeltaTimeProvider
    {
    #region Public Methods

        public float GetDeltaTime()
        {
            return Time.deltaTime;
        }

    #endregion
    }
}