#region

using rStarUtility.Util.Extensions.Csharp;

#endregion

namespace Game.Scripts.Helpers
{
    public class ValidateHelper
    {
    #region Public Methods

        public static bool ValidateString(string str)
        {
            return str.HasValue();
        }

    #endregion
    }
}