#region

using System.Collections.Generic;
using Game.Scripts.Battle.Misc;
using Game.Scripts.Names;
using Game.Scripts.Players.Handlers;
using Game.Scripts.Players.Main;
using Game.Scripts.RPG;
using NSubstitute;
using NUnit.Framework;
using rStarUtility.Generic.TestExtensions;
using rStarUtility.Generic.TestFrameWork;
using AssertionException = UnityEngine.Assertions.AssertionException;

#endregion

public class PlayerCharacterTests : TestFixture_DI_Log
{
#region Test Methods

    [Test(Description = "初始化角色，角色數值正確")]
    public void Init_PlayerCharacter_Stats_WouldBe_Correct()
    {
        var statDatas = new List<Stat.Data> { new Stat.Data(StatNames.Atk , 999) };
        BindInstance(new PlayerCharacter.Data() { statDatas = statDatas });
        var character = NewPlayerCharacter();

        character.Stats.CountShouldBe(1);
        character.GetStatFinalValue(StatNames.Atk).ShouldBe(999);
    }

    [Test(Description = "透過玩家輸入，移動玩家角色")]
    public void MovePlayerCharacter_By_PlayerInput()
    {
        var playerCharacter = NewPlayerCharacter();
        playerCharacter.SetMoveSpeed(1);

        var inputState   = BindAndResolve<PlayerInputState>();
        var timeProvider = BindMockAndResolve<ITimeProvider>();
        timeProvider.GetDeltaTime().Returns(1);
        inputState.SetMoveDirection(1 , 1);

        var moveHandler = BindAndResolve<PlayerMoveHandler>();

        moveHandler.Tick();
        playerCharacter.ShouldTransformPositionBe(1 , 1);
        moveHandler.Tick();
        playerCharacter.ShouldTransformPositionBe(2 , 2);
    }

    [Test(Description = "設定角色數值時，會限制最終數值的最大最小值")]
    [Ignore("還沒做完，正確為計算值的限制")]
    public void Set_PlayerCharacter_Stats_Amount_WouldBe_Clamp()
    {
        var character = NewPlayerCharacter();
        character.SetMoveSpeed(0);

        character.GetStatFinalValue(StatNames.MoveSpeed).ShouldBe(1);
    }

    [Test(Description = "數值資料名稱不能為空白，會錯誤")]
    public void Set_StatData_Name_Empty_Should_Error()
    {
        Assert.Throws<AssertionException>(() => new Stat.Data(string.Empty , 999));
    }

#endregion

#region Private Methods

    private PlayerCharacter NewPlayerCharacter()
    {
        BindInstance(new PlayerCharacter.Data());
        var playerCharacter = Bind_ComponentOnNewGameObject_And_Resolve<PlayerCharacter>();
        return playerCharacter;
    }

#endregion
}