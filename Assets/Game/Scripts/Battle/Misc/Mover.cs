#region

using UnityEngine;

#endregion

namespace Game.Scripts.Battle.Misc
{
    public interface Mover
    {
    #region Public Variables

        float MoveSpeed { get; }

    #endregion

    #region Public Methods

        Vector2 GetPos();
        void    SetPos(Vector2 newPos);

    #endregion
    }
}