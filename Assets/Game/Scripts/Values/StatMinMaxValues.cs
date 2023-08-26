using System.Collections.Generic;
using Game.Scripts.Names;
using rStarUtility.Util.Extensions.Csharp;

namespace Game.Scripts.Values
{
    public static class StatMinMaxValues
    {
        /// <summary>
        /// stat's name , max amount
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string , float> maxLookUp = new Dictionary<string , float>() { { StatNames.MoveSpeed , 30 } , };

        /// <summary>
        /// stat's name , min amount
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string , float> minLookUp = new Dictionary<string , float>()
        {
            { StatNames.MoveSpeed , 1 } ,
        };

        public static float GetMax(string name)
        {
            return maxLookUp.GetOrReturn(name , float.MaxValue);
        }

        public static float GetMin(string name)
        {
            return minLookUp.GetOrReturn(name , 0);
        }
    }
}