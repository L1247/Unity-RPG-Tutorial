#region

using Game.Scripts.Battle.Misc;
using Game.Scripts.Players.Handlers;
using Game.Scripts.Players.Main;
using NSubstitute;
using NUnit.Framework;
using rStarUtility.Generic.TestExtensions;
using rStarUtility.Generic.TestFrameWork;

#endregion

public class PlayerCharacterTests : TestFixture_DI_Log
{
#region Test Methods

    [Test(Description = "透過玩家輸入，移動玩家角色")]
    public void MovePlayerCharacter_By_PlayerInput()
    {
        Container.Bind<float>().WithId("MoveSpeed").FromInstance(1);
        Container.Bind<PlayerCharacter>().FromNewComponentOnNewGameObject().AsSingle();

        var playerCharacter = Container.Resolve<PlayerCharacter>();
        var inputState      = BindAndResolve<PlayerInputState>();
        var timeProvider    = BindMockAndResolve<IDeltaTimeProvider>();
        timeProvider.GetDeltaTime().Returns(1);
        inputState.SetMoveDirection(1 , 1);

        var moveHandler = BindAndResolve<PlayerMoveHandler>();

        moveHandler.Tick();
        playerCharacter.ShouldTransformPositionBe(1 , 1);
        moveHandler.Tick();
        playerCharacter.ShouldTransformPositionBe(2 , 2);
    }

#endregion
}