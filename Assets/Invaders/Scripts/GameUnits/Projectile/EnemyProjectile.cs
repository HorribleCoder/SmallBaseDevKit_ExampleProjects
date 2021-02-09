using UnityEngine;

namespace Invaders.Units
{
    internal sealed class EnemyProjectile : Projectile
    {
        internal override void SetPosition(Vector3 position)
        {
            base.SetPosition(position);
            characterVisual.transform.position += Vector3.back * GlobalGameParams.EnemyProjectileLayer;
        }
    }
}
