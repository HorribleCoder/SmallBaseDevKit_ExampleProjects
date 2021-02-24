using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.State;

namespace TD.Level
{
    [RequiredHandler(typeof(GameFieldHandler))]
    internal class GameFieldState : BaseUnitState<Type>
    {
        public override void Deconstruct(out Type stateParam)
        {
            stateParam = GetType();
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
