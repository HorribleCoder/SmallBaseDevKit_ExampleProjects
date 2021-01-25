using UnityEngine;

using Invaders.GameSettings;

namespace Invaders.GameState
{
    internal sealed class GravityState : PlayerVerticalMovement
    {
        protected override Vector3 movementDirecion => Vector3.down;

        protected override void ChangeCurrentSpeed()
        {
            currentSpeed += Time.deltaTime * 2.5f;
        }

        protected override bool EndState()
        {
            return ownerRigidbody.position.y <= GlobalGameParams.Instance.verticalLimit;
        }

        protected override void ExtendedStateComplite()
        {

        }

        protected override float StartSetSpeed()
        {
            return speed * 1.15f;
        }
    }
}
