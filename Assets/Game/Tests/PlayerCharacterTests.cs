#region

using System.Collections.Generic;
using Game.Scripts.Battle.Misc;
using Game.Scripts.Players.Handlers;
using Game.Scripts.Players.Main;
using Game.Scripts.RPG;
using NSubstitute;
using NUnit.Framework;
using rStarUtility.Generic.TestExtensions;
using rStarUtility.Generic.TestFrameWork;

#endregion

public class PlayerCharacterTests : TestFixture_DI_Log
{
#region Test Methods

    [Test(Description = "初始化角色，角色數值正確")]
    public void Init_PlayerCharacter_Stats_WouldBe_Correct()
    {
        var statDatas = new List<Stat.Data> { new Stat.Data() { name = "MoveSpeed" , amount = 999 } };
        BindInstance(new PlayerCharacter.Data() { statDatas = statDatas });
        var character = NewPlayerCharacter();

        character.Stats.CountShouldBe(1);
        character.MoveSpeed.ShouldBe(999);
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