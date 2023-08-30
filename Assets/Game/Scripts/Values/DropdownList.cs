#region

using Game.Scripts.Names;
using Sirenix.OdinInspector;

#endregion

namespace Game.Scripts.Values
{
    public static class DropdownList
    {
    #region Public Variables

        public static ValueDropdownList<string> GetBaseStatNames = new ValueDropdownList<string>()
        {
            { "基礎數值 / 移動速度" , StatNames.MoveSpeed } , { "基礎數值 / 攻擊力" , StatNames.Atk }
        };

        public static ValueDropdownList<string> GetSkillStatNames = new ValueDropdownList<string>()
        {
            { "技能 / 技能1攻擊" , StatNames.Skill_1_Atk }
        };

    #endregion

    #region Public Methods

        public static ValueDropdownList<string> GetAllStatNames(bool isPlayer)
        {
            var list = new ValueDropdownList<string>();
            list.AddRange(GetBaseStatNames);
            if (isPlayer) list.AddRange(GetSkillStatNames);
            return list;
        }

    #endregion
    }
}