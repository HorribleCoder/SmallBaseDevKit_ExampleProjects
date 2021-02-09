using Invaders.GameSettings;
using Invaders.GameState;

using SmallBaseDevKit;
using UnityEngine;

namespace Invaders.Units
{
    internal abstract class Projectile : BaseGameUnit<ProjectileSetting>
    {
        protected override void ExtendedSetupUnit()
        {
            base.ExtendedSetupUnit();
            Game.AddUnitStateGroup<ProjectilePhysicState, ProjectileMovement>(this, AddStateType.AddFirst);
        }
    }
}
