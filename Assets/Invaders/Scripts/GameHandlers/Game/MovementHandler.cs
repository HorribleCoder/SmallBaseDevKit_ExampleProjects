using SmallBaseDevKit.USH.Handler;
using SmallBaseDevKit.USH.State;
using Invaders.GameState;

namespace Invaders.GameHandler
{
    internal sealed class MovementHandler : BaseGameHandler
    {
        public override void ExecuteHandlerLogic(IState currentState)
        {
            var converState = currentState.ConvertTo<MovementState>();
            converState.Deconstruct(out var stateParam);
            if(currentState is PlayerVerticalMovement)
            {
                stateParam.rigidbody.velocity += stateParam.velocity;
            }
            else
            {
                stateParam.rigidbody.velocity = stateParam.velocity;
            }
        }

        protected override void SetupHandlerOnCreate()
        {

        }
    }
}

