#region

using System;
using System.Collections.Generic;
using Game.Scripts.Names;
using rStarUtility.Util.Extensions.Csharp;

#endregion

namespace Game.Scripts.Values
{
    public static class StatMinMaxValues
    {
    #region Private Variables

        /// <summary>
        /// stat's name , max amount
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string , float> maxLookUp = new Dictionary<string , float>()
        {
            { StatNames.MoveSpeed , 30 } , { StatNames.Atk , 1000 } ,
        };

        /// <summary>
        /// stat's name , min amount
        /// </summary>
        /// <returns></returns>
        private static readonly Dictionary<string , float> minLookUp = new Dictionary<string , float>()
        {
            { StatNames.MoveSpeed , 1 }
        };

    #endregion

    #region Public Methods

        public static float GetMax(string name)
        {
            return maxLookUp.GetOrReturn(name , float.MaxValue);
        }

        public static string GetMaxInfo(string name)
        {
            var max = GetMax(name);
            return Math.Abs(max - float.MaxValue) < 0.01f ? "Float.Max" : max.ToString();
        }

        public static float GetMin(string name)
        {
            return minLookUp.GetOrReturn(name , 0);
        }

    #endregion
    }
}