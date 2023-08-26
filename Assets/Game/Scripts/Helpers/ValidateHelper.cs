#region

using System.Collections.Generic;
using System.Linq;
using Game.Scripts.RPG;
using rStarUtility.Util.Extensions.Csharp;

#endregion

namespace Game.Scripts.Helpers
{
    public class ValidateHelper
    {
    #region Public Methods

        public static bool StatDataValidation(List<Stat.Data> datas , ref string errorMessage)
        {
            var groupByName      = datas.GroupBy(data => data.Name);
            var anyDuplicateName = groupByName.Any(g => g.Count() > 1);
            var happyPath        = anyDuplicateName == false;
            if (happyPath) return true;

            var duplicateGroup    = groupByName.First(g => g.Count() > 1);
            var duplicateStatName = duplicateGroup.Key;
            errorMessage = $"發現重複屬性資料，屬性名稱為:{duplicateStatName}";
            return false;
        }

        public static bool ValidateString(string str)
        {
            return str.HasValue();
        }

    #endregion
    }
}