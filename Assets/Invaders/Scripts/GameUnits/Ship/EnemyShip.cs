using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Invaders.GameSettings;

namespace Invaders.Units
{
    internal sealed class EnemyShip : BaseGameUnit<EnemyShipSetting>
    {
        protected override void ExtendedSetupUnit(EnemyShipSetting unitData)
        {
            base.ExtendedSetupUnit(unitData);

        }
    }
}
