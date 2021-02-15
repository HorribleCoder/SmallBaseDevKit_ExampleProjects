using SmallBaseDevKit;
using SmallBaseDevKit.USH.Handler;
using SmallBaseDevKit.USH.State;

using Invaders.Units;
using Invaders.Events;
using Invaders.GameState;
using Invaders.GameModule;
//GameInstance.Instance.GetGameModule<GameResourcesModule>().CurrentLevelData.enemyData[Game.GetUnitIndexInRegistor<Rigidbody>(owner)].enemyHealth;
namespace Invaders.GameHandler
{
    internal sealed class UnitHitHandler : BaseGameHandler
    {
        public override void ExecuteHandlerLogic(IState currentState)
        {
            currentState.ConvertTo<UnitHitState>().Deconstruct(out var stateParam);
            int currentUnitLive = 0;
            var gameInfoModule = GameInstance.Instance.GetGameModule<GameInfoModule>();
            if (stateParam is PlayerShip)
            {
                gameInfoModule.PlayerLostLive();
                currentUnitLive = GameInstance.Instance.GetGameModule<GameInfoModule>().PlayerLives;
            }
            else
            {
                gameInfoModule.TryGetUnitLive(stateParam, out currentUnitLive);
                --currentUnitLive;
                gameInfoModule.SetNewLiveValueInTable(stateParam, currentUnitLive);
            }

            if(currentUnitLive <= 0)
            {
                Game.AddUnitState<DestroyState>(stateParam, AddStateType.AddLast);
            }

        }

        protected override void SetupHandlerOnCreate()
        {

        }
    }
}
