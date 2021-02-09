using UnityEngine;


namespace Invaders.GameState
{
    internal sealed class PlayerMoveToRightState : MovementState
    {
        protected override Vector3 movementDirecion => Vector3.right;

        protected override float speed => ownerData.horizontalSpeed;

        protected override void ExtendedStateComplite()
        {
            SmallBaseDevKit.Game.AddUnitState<PlayerMoveToLeftState>(owner, SmallBaseDevKit.AddStateType.AddFirst);
        }

        protected override bool EndState()
        {
            return ownerRigidbody.position.x >= -GlobalGameParams.Instance.horizontalLimit;
        }
    }
}
