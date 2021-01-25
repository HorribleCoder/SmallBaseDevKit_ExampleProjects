using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SmallBaseDevKit.USH.State;
using SmallBaseDevKit.USH.Unit;

using Invaders.GameHandler;
using Invaders.GameSettings;

namespace Invaders.GameState
{
    [RequiredHandler(typeof(DestroyHandler))]
    internal sealed class DestroyState : BaseUnitState<IUnit>
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
