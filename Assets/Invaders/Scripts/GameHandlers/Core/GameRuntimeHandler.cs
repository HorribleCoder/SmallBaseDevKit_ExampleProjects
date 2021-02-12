using UnityEngine;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.Handler;
using SmallBaseDevKit.USH.State;

using Invaders.GameState;

namespace Invaders.GameHandler
{
    internal sealed class GameRuntimeHandler : BaseGameHandler
    {
        public override void ExecuteHandlerLogic(IState currentState)
        {
            currentState.ConvertTo<GameRuntimeState>().Deconstruct(out var stateParam);
            if(stateParam == InteractiveStatus.Enable)
            {
                Time.timeScale = 1 / 10000f;
                GlobalGameParams.Instance.gameOnPause = true;
            }
            else
            {
                Time.timeScale = 1f;
                GlobalGameParams.Instance.gameOnPause = false;
            }
        }

        protected override void SetupHandlerOnCreate()
        {

        }
    }
}
