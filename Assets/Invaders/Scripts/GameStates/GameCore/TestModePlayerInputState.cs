using SmallBaseDevKit.USH.Unit;
using SmallBaseDevKit.USH.State;

using Invaders.GameHandler.Core;

namespace Invaders.GameState.Core
{
    [RequiredHandler(typeof(TestPlayerInputHandler))]
    internal sealed class TestModePlayerInputState : BaseUnitState<IUnit>
    {
        public override void Deconstruct(out IUnit stateParam)
        {
            stateParam = owner;
        }

        protected override bool EndState()
        {
            return false;
        }

        protected override void ExtendedSetupState()
        {

        }

        protected override void ExtendedStateComplite()
        {

        }
    }
}

