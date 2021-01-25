using UnityEngine;

namespace Invaders.GameSettings
{
    [CreateAssetMenu(fileName = "New Projectile Setting", menuName = "Invaders/Settings/Projectile Setting")]
    internal sealed class ProjectileSetting : ShipSetting
    {
        public ProjectileType projectileType = ProjectileType.None;
    }
}
