#region

using UnityEngine;
using Zenject;

#endregion

namespace Game.Scripts.Players.Main
{
    public class PlayerCharacter : MonoBehaviour
    {
    #region Public Variables

        [Inject(Id = "MoveSpeed")]
        public float MoveSpeed { get; }

        public Transform Trans
        {
            get
            {
                if (trans == null) trans = transform;
                return trans;
            }
        }

    #endregion

    #region Private Variables

        private Transform trans;

    #endregion

    #region Public Methods

        public Vector2 GetPos()
        {
            return Trans.position;
        }

        public void SetPos(Vector2 newPos)
        {
            Trans.position = newPos;
        }

    #endregion
    }
}