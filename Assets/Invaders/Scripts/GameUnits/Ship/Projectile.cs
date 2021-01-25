using Invaders.GameSettings;
using Invaders.GameState;

using SmallBaseDevKit;
using UnityEngine;

namespace Invaders.Units
{
    internal sealed class Projectile : BaseGameUnit<ProjectileSetting>
    {
        protected override void ExtendedSetupUnit(ProjectileSetting unitData)
        {
            base.ExtendedSetupUnit(unitData);
            Game.AddUnitState<ProjectileMovement>(this, AddStateType.AddFirst);
            Game.AddUnitState<ProjectilePhysicState>(this, AddStateType.AddLast);
        }
    }
}
