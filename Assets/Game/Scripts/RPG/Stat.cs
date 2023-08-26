#region

using System;
using Game.Scripts.Values;
using Sirenix.OdinInspector;
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

            public  float  Amount   => amount;
            public  string Name     => name;

        #endregion

        #region Private Variables

            private float MinValue => StatMinMaxValues.GetMin(Name);
            private float MaxValue => StatMinMaxValues.GetMax(Name);

            [MinValue("@MinValue")]
            [MaxValue("@MaxValue")]
            [SerializeField]
            private float amount;

            [SerializeField]
            private string name;

            public Data(string name , float amount)
            {
                this.name   = name;
                this.amount = amount;
            }

        #endregion
        }

    #endregion
    }
}