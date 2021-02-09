using UnityEngine;

using SmallBaseDevKit.USH.Handler;
using SmallBaseDevKit.USH.State;

using Invaders.GameState;

namespace Invaders.GameHandler
{
    internal sealed class GameTimerHandler : BaseGameHandler
    {
        public override void ExecuteHandlerLogic(IState currentState)
        {
            currentState.ConvertTo<TimerState>().Deconstruct(out var stateParam);
            if(stateParam.timer <= Time.time)
            {
                stateParam.TimerAction.Invoke();
            }
        }

        protected override void SetupHandlerOnCreate()
        {

        }
    }
}
