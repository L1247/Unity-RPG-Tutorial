using System.Collections.Generic;
using Game.Scripts.Names;

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
            return maxLookUp.ContainsKey(name) ? maxLookUp[name] : float.MaxValue;
        }

        public static float GetMin(string name)
        {
            return minLookUp.ContainsKey(name) ? minLookUp[name] : 0;
        }
    }
}