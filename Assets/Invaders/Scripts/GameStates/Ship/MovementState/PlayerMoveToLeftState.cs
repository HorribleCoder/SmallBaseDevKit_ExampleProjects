using UnityEngine;

namespace Invaders.GameState
{
    internal sealed class PlayerMoveToLeftState : MovementState
    {
        protected override Vector3 movementDirecion => Vector3.left;

        protected override float speed => ownerData.horizontalSpeed;

        protected override void ExtendedStateComplite()
        {
            SmallBaseDevKit.Game.AddUnitState<PlayerMoveToRightState>(owner, SmallBaseDevKit.AddStateType.AddFirst);
        }

        protected override bool EndState()
        {
            return ownerRigidbody.position.x <= GlobalGameParams.Instance.horizontalLimit;
        }
    }
}
