#region

using System.Collections.Generic;
using Game.Scripts.Battle.Misc;
using Game.Scripts.Battle.States;
using Game.Scripts.Names;
using Game.Scripts.Players.Handlers;
using Game.Scripts.Players.Main;
using Game.Scripts.RPG;
using Game.Tests.FakeDatas;
using NSubstitute;
using NUnit.Framework;
using rStarUtility.Generic.TestExtensions;
using rStarUtility.Generic.TestFrameWork;
using AssertionException = UnityEngine.Assertions.AssertionException;

#endregion

public class PlayerCharacterTests : TestFixture_DI_Log
{
#region Test Methods

    [Test(Description = "暫停遊戲，玩家不能移動玩家角色")]
    public void Cant_MovePlayerCharacter_When_Game_Is_Pausing()
    {
        var gameState = Bind_And_Resolve<GameState>();
        Bind_InterfacesTo<Movable>();
        var playerCharacter = NewPlayerCharacter();
        playerCharacter.SetStatAmount(StatNames.MoveSpeed , 1);

        var inputState   = Bind_And_Resolve<PlayerInputState>();
        var timeProvider = Bind_Mock_And_Resolve<ITimeProvider>();
        timeProvider.GetDeltaTime().Returns(1);
        inputState.SetMoveDirection(1 , 1);

        var moveHandler = Bind_And_Resolve<PlayerMoveHandler>();

        gameState.SetPauseState(true);
        moveHandler.Tick();
        playerCharacter.ShouldTransformPositionBe(0 , 0);
        gameState.SetPauseState(false);
        moveHandler.Tick();
        playerCharacter.ShouldTransformPositionBe(1 , 1);
    }

    [Test(Description = "初始化角色，角色數值正確")]
    public void Init_PlayerCharacter_Stats_WouldBe_Correct()
    {
        var statDatas = new List<Stat.Data> { new Stat.Data(StatNames.Atk , 999) };
        Bind_Instance(new PlayerCharacter.Data() { statDatas = statDatas });
        var character = NewPlayerCharacter();

        character.Stats.CountShouldBe(1);
        character.GetStatFinalValue(StatNames.Atk).ShouldBe(999);
    }

    [Test(Description = "透過玩家輸入，移動玩家角色")]
    public void MovePlayerCharacter_By_PlayerInput()
    {
        var movable = Bind_Mock_And_Resolve<IMovable>();
        movable.Get().Returns(true);
        var playerCharacter = NewPlayerCharacter();
        playerCharacter.SetStatAmount(StatNames.MoveSpeed , 1);
        var inputState   = Bind_And_Resolve<PlayerInputState>();
        var timeProvider = Bind_Mock_And_Resolve<ITimeProvider>();
        timeProvider.GetDeltaTime().Returns(1);
        inputState.SetMoveDirection(1 , 1);

        var moveHandler = Bind_And_Resolve<PlayerMoveHandler>();

        moveHandler.Tick();
        playerCharacter.ShouldTransformPositionBe(1 , 1);
        moveHandler.Tick();
        playerCharacter.ShouldTransformPositionBe(2 , 2);
    }

    [Test(Description = "設定角色任意名稱數值時，會限制最終數值的最大最小值")]
    public void Set_PlayerCharacter_Any_Stats_Amount_WouldBe_Clamp_In_Min_Max()
    {
        var statName  = "123";
        var statDatas = new List<Stat.Data> { new FakeStatData(statName , 0 , 2 , 99) };
        Bind_Instance(new PlayerCharacter.Data() { statDatas = statDatas });
        var character = NewPlayerCharacter();
        character.GetStatFinalValue(statName).ShouldBe(2);

        character.SetStatAmount(statName , -5);
        character.GetStatFinalValue(statName).ShouldBe(2);
        character.SetStatAmount(statName , 100);
        character.GetStatFinalValue(statName).ShouldBe(99);
    }

    [Test(Description = "設定角色數值時，如果有上下限，會限制最終數值為最大最小值內")]
    public void Set_PlayerCharacter_Stats_Amount_WouldBe_Clamp_If_MinMaxExist()
    {
        var character = NewPlayerCharacter();

        character.SetStatAmount(StatNames.MoveSpeed , 0);
        character.GetStatFinalValue(StatNames.MoveSpeed).ShouldBe(1);
        character.SetStatAmount(StatNames.MoveSpeed , 31);
        character.GetStatFinalValue(StatNames.MoveSpeed).ShouldBe(30);
        character.SetStatAmount(StatNames.Atk , 9999);
        character.GetStatFinalValue(StatNames.Atk).ShouldBe(1000);
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
        Bind_Instance(new PlayerCharacter.Data());
        Bind_InterfacesAndSelfTo_From_NewGameObject<PlayerCharacter>();
        return Resolve<PlayerCharacter>();
    }

#endregion
}