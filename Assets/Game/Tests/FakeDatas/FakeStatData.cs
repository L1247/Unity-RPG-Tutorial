#region

using Game.Scripts.RPG;

#endregion

namespace Game.Tests.FakeDatas
{
    public class FakeStatData : Stat.Data
    {
    #region Public Variables

        public override float MaxValue { get; }
        public override float MinValue { get; }

    #endregion

    #region Constructor

        public FakeStatData(string name , float amount , float min , float max)
        {
            MaxValue = max;
            MinValue = min;
            SetName(name);
            SetAmount(amount);
        }

    #endregion
    }
}