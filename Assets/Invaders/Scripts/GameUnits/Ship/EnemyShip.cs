using SmallBaseDevKit;

using Invaders.GameState;
using Invaders.GameSettings;

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
