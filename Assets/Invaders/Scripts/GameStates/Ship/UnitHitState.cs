using UnityEngine;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.Unit;
using SmallBaseDevKit.USH.State;

using Invaders.GameHandler;
using Invaders.GameModule;

namespace Invaders.GameState
{
    [RequiredHandler(typeof(UnitHitHandler))]
    internal sealed class UnitHitState : BaseUnitState<IUnit>
    {
        public override void Deconstruct(out IUnit stateParam)
        {
            stateParam = owner;
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
