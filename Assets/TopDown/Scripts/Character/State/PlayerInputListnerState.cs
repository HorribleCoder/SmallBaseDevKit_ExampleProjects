using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.Unit;
using SmallBaseDevKit.USH.State;

namespace TD.Characters.State
{
    internal sealed class PlayerInputListnerState : BaseUnitState<IUnit>
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
