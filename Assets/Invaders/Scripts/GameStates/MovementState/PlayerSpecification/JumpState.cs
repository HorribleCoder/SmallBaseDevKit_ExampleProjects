using UnityEngine;
using SmallBaseDevKit;

using Invaders.GameSettings;

namespace Invaders.GameState
{
    internal sealed class JumpState : PlayerVerticalMovement
    {
        protected override Vector3 movementDirecion => Vector3.up;

        protected override void ChangeCurrentSpeed()
        {
            currentSpeed -= 0.4f;
        }

        protected override void ExtendedSetupState()
        {
            base.ExtendedSetupState();
            Game.RemoveUnitState<GravityState>(owner);
        }

        protected override void ExtendedStateComplite()
        {
            Game.AddUnitState<GravityState>(owner, AddStateType.AddLast);
        }

        protected override float StartSetSpeed()
        {
            return speed;
        }

        protected override bool EndState()
        {
            return currentSpeed <= 0f || ownerRigidbody.position.y >= -GlobalGameParams.Instance.verticalLimit;
        }
    }
}
