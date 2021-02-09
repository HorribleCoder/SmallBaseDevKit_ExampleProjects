using SmallBaseDevKit.USH.State;

using Invaders.GameHandler.Core;

namespace Invaders.GameState.Core
{
    [RequiredHandler(typeof(GameFieldHandler))]
    internal abstract class BaseGameFieldState : BaseUnitState<GameFieldStateType>
    {
        protected abstract GameFieldStateType stateType { get; }
        public override void Deconstruct(out GameFieldStateType stateParam)
        {
            stateParam = stateType;
        }

        protected override bool EndState()
        {
            return true;
        }

        protected override void ExtendedSetupState()
        {

        }

        protected override void ExtendedStateComplite()
        {

        }
    }
}
