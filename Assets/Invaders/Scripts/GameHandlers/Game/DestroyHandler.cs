using System.Threading.Tasks;

using SmallBaseDevKit.USH.Handler;
using SmallBaseDevKit.USH.State;

using Invaders.Units;
using Invaders.GameState;
using Invaders.GameSettings;

namespace Invaders.GameHandler
{
    internal sealed class DestroyHandler : BaseGameHandler
    {
        public override void ExecuteHandlerLogic(IState currentState)
        {
            var convertState = ConvertStateToType<DestroyState>(currentState);
            convertState.Deconstruct(out var stateParam);

            if(stateParam is PlayerShip)
            {

            }
            else
            {

            }

            SmallBaseDevKit.Game.DestroyUnit(stateParam);
        }

    }
}
