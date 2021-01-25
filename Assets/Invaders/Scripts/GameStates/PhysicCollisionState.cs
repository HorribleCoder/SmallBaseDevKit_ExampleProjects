using UnityEngine;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.State;

using Invaders.GameHandler;

namespace Invaders.GameState
{
    [RequiredHandler(typeof(PhysicsHandler))]
    internal abstract class PhysicCollisionState : BaseUnitState<(Rigidbody selfRB, Ray ray, float distance)>
    {
        protected Rigidbody ownerRigidBody;
        protected abstract float checkDistance { get; }

        public override void Deconstruct(out (Rigidbody selfRB, Ray ray, float distance) stateParam)
        {
            stateParam.selfRB = ownerRigidBody;
            stateParam.ray = new Ray(ownerRigidBody.position, GetPhysicDirection());
            stateParam.distance = checkDistance;
        }

        protected override void ExtendedSetupState()
        {
            owner.TryGetUnitComponent(out ownerRigidBody);
        }

        protected override void ExtendedStateComplite()
        {
            Game.AddUnitState<DestroyState>(owner, AddStateType.AddLast);
        }

        protected abstract Vector3 GetPhysicDirection();

        protected override bool EndState()
        {
            return Physics.Raycast(ownerRigidBody.position, GetPhysicDirection(), checkDistance);
        }
    }
}
