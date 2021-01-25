using UnityEngine;

namespace Invaders.GameState
{
    internal sealed class ProjectilePhysicState : PhysicCollisionState
    {
        protected override float checkDistance => 1f;

        protected override Vector3 GetPhysicDirection()
        {
            return ownerRigidBody.transform.up * checkDistance;
        }
    }
}
