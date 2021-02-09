using SmallBaseDevKit;
using Invaders.GameState.Core;

namespace Invaders.GameState.Core
{
    internal sealed class ClearGameFieldState : BaseGameFieldState
    {
        protected override GameFieldStateType stateType => GameFieldStateType.ClearField;

        protected override void ExtendedStateComplite()
        {
            base.ExtendedStateComplite();
            Game.AddUnitState<CreateGameFieldState>(owner, AddStateType.AddFirst);
        }
    }
}
