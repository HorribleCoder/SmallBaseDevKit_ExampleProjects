using System;

using SmallBaseDevKit.USH.State;
using Invaders.GameHandler;

namespace Invaders.GameState
{
    [RequiredHandler(typeof(GameRuntimeHandler))]
    internal abstract class GameRuntimeState : BaseUnitState<InteractiveStatus>
    {
        protected abstract InteractiveStatus gamePause { get; }

        public override void Deconstruct(out InteractiveStatus stateParam)
        {
            stateParam = gamePause;
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
