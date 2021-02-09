using UnityEngine;

using Invaders.GameSettings;

namespace Invaders.GameState
{
    internal abstract class PlayerVerticalMovement : MovementState
    {
        protected float currentSpeed;
        protected override float speed => ownerData.verticalSpeed;

        protected override void ExtendedSetupState()
        {
            base.ExtendedSetupState();
            currentSpeed = StartSetSpeed();
            ownerRigidbody.velocity = new Vector3(ownerRigidbody.velocity.x, 0f, 0f);
        }

        public override void Deconstruct(out (Rigidbody rigidbody, Vector3 velocity) stateParam)
        {
            base.Deconstruct(out stateParam);
            ChangeCurrentSpeed();
        }

        protected abstract float StartSetSpeed();

        protected abstract void ChangeCurrentSpeed();
    }
}
