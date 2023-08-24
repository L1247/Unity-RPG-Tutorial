#region

using System;
using UnityEngine;

#endregion

namespace Game.Scripts.RPG
{
    public class Stat
    {
    #region Public Variables

        public float  Amount { get; private set; }
        public string Name   { get; }

    #endregion

    #region Constructor

        public Stat(string statName , float statAmount)
        {
            Name   = statName;
            Amount = statAmount;
        }

    #endregion

    #region Public Methods

        public void SetAmount(float newAmount)
        {
            Amount = newAmount;
        }

    #endregion

    #region Nested Types

        [Serializable]
        public class Data
        {
        #region Public Variables

            [Min(0)]
            public float amount;

            public string name;

        #endregion
        }

    #endregion
    }
}