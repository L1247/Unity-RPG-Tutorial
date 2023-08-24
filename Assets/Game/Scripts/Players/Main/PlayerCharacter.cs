#region

using System;
using UnityEngine;
using Zenject;

#endregion

namespace Game.Scripts.Players.Main
{
    public class PlayerCharacter : MonoBehaviour
    {
    #region Public Variables

        public float MoveSpeed { get; private set; }

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

        [Inject]
        private Data data;

        private Transform trans;

    #endregion

    #region Public Methods

        public Vector2 GetPos()
        {
            return Trans.position;
        }

        public void SetMoveSpeed(float moveSpeed)
        {
            MoveSpeed = moveSpeed;
        }

        public void SetPos(Vector2 newPos)
        {
            Trans.position = newPos;
        }

    #endregion

    #region Private Methods

        [Inject]
        private void Init()
        {
            MoveSpeed = data.moveSpeed;
        }

    #endregion

    #region Nested Types

        [Serializable]
        public class Data
        {
        #region Public Variables

            public float atk;
            public float hp;

            [Min(1)]
            public float moveSpeed;

        #endregion
        }

    #endregion
    }
}