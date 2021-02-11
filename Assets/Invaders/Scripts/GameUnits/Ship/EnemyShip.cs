﻿using SmallBaseDevKit;

using Invaders.GameState;
using Invaders.GameSettings;
using Invaders.GameModule;

namespace Invaders.Units
{
    internal class EnemyShip : BaseGameUnit<EnemyShipSetting>
    {
        protected override void ExtendedSetupUnit()
        {
            base.ExtendedSetupUnit();
            Game.AddUnitState<EnemyStartGameState>(this, AddStateType.AddFirst);
        }
    }
}
