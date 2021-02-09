﻿using UnityEngine;

using SmallBaseDevKit;

using Invaders.Links;
using Invaders.Events;
using Invaders.GameState;
using Invaders.GameSettings;

namespace Invaders.Units
{
    [RequireComponent(typeof(FirePointLink))]
    internal sealed class PlayerShip : BaseGameUnit<PlayerShipSetting>
    {
        protected override void ExtendedSetupUnit()
        {
            base.ExtendedSetupUnit();
            Game.AddUnitState<PlayerStartGameState>(this, AddStateType.AddFirst);
        }

        protected override void ExtendedDestroyUnit()
        {
            base.ExtendedDestroyUnit();
            Game.ExecuteEvent<PlayerInputAreaControllerEventArg>(eventArgSetupCallback: SetupEventArg);
            void SetupEventArg(PlayerInputAreaControllerEventArg eventArg)
            {
                eventArg.isActive = false;
            }
        }
    }
}
