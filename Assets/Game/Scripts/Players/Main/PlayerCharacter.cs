#region

using UnityEngine;

#endregion

namespace Game.Scripts.Players.Main
{
    public class PlayerCharacter : MonoBehaviour
    {
    #region Public Variables

        public float MoveSpeed = 5f;

    #endregion

    #region Private Variables

        private Transform trans;

    #endregion

    #region Unity events

        private void Awake()
        {
            trans = transform;
        }

    #endregion

    #region Public Methods

        public Vector2 GetPos()
        {
            return trans.position;
        }

        public void SetPos(Vector2 newPos)
        {
            trans.position = newPos;
        }

    #endregion
    }
}