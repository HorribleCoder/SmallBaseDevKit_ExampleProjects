using UnityEngine;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.State;

using Invaders.GameHandler;
using Invaders.GameSettings;

namespace Invaders.GameState
{
    [RequiredHandler(typeof(PhysicsHandler))]
    internal abstract class PhysicCollisionState : BaseUnitState<(Rigidbody selfRB, Ray ray, float distance, ShipType ownerType)>
    {
        protected Rigidbody ownerRigidBody;
        protected ShipType ownerType;
        protected abstract float checkDistance { get; }

        public override void Deconstruct(out (Rigidbody selfRB, Ray ray, float distance, ShipType ownerType) stateParam)
        {
            stateParam.selfRB = ownerRigidBody;
            stateParam.ray = new Ray(ownerRigidBody.position + GetOffset(), GetPhysicDirection());
            stateParam.distance = checkDistance;
            stateParam.ownerType = ownerType;
        }

        protected override void ExtendedSetupState()
        {
            owner.TryGetUnitComponent(out ownerRigidBody);
            owner.ReadUnitData<ShipSetting>(out var ownerData);
            ownerType = ownerData.shipType;
        }

        protected override void ExtendedStateComplite()
        {
            Game.AddUnitState<DestroyState>(owner, AddStateType.AddLast);
        }
        protected abstract Vector3 GetOffset();
        protected abstract Vector3 GetPhysicDirection();

        protected override bool EndState()
        {
            return false;
        }
    }
}
