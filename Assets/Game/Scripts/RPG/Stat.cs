#region

using System;
using Game.Scripts.Values;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Assertions;
using Math = rStarUtility.Util.Helper.Math;

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

            public float  Amount => amount;
            public string Name   => name;

        #endregion

        #region Private Variables

            private float  MinValue     => StatMinMaxValues.GetMin(Name);
            private float  MaxValue     => StatMinMaxValues.GetMax(Name);
            private string MaxValueInfo => StatMinMaxValues.GetMaxInfo(Name);
            private string MinMaxInfo   => $"最小值: {MinValue}\n最大值: {MaxValueInfo}";
            private string AmountSuffix => $"{MinValue} ~ {MaxValueInfo}";

            [MinValue("@MinValue")]
            [MaxValue("@MaxValue")]
            [Tooltip("@MinMaxInfo")]
            [SuffixLabel("@AmountSuffix" , overlay : true , Icon = SdfIconType.ShieldFillExclamation)]
            [OnValueChanged("OnAmountChanged")]
            [SerializeField]
            [LabelText("數值:")]
            [ValidateInput("MinMaxValidation" , "最大值不能小於最小值")]
            [LabelWidth(30)]
            [HorizontalGroup("StatData")]
            private float amount;

            [SerializeField]
            [ValidateInput("@ValidateHelper.ValidateString(this.name)" , "名稱是空白，需要輸入任意名稱")]
            [LabelText("名稱:")]
            [PropertyOrder(-100)]
            [HorizontalGroup("StatData")]
            [LabelWidth(30)]
            private string name;

        #endregion

        #region Constructor

            public Data(string name , float amount)
            {
                SetName(name);
                SetAmount(amount);
            }

        #endregion

        #region Private Methods

            private bool MinMaxValidation()
            {
                return MaxValue > MinValue;
            }

            private void OnAmountChanged(float newAmount)
            {
                SetAmount(newAmount);
            }

            private void SetAmount(float newAmount)
            {
                var min = MinValue;
                var max = MaxValue;
                amount = Math.Clamp(newAmount , min , max);
            }

            private void SetName(string name)
            {
                Assert.IsTrue(string.IsNullOrEmpty(name) == false , "name string is null or empty.");
                this.name = name;
            }

        #endregion
        }

    #endregion
    }
}