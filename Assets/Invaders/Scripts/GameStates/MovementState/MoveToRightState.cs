using UnityEngine;

using Invaders.GameSettings;

namespace Invaders.GameState
{
    internal sealed class MoveToRightState : MovementState
    {
        protected override Vector3 movementDirecion => Vector3.right;

        protected override float speed => owner.ReadUnitData<ShipSetting>().horizontalSpeed;

        protected override void ExtendedStateComplite()
        {
            SmallBaseDevKit.Game.AddUnitState<MoveToLeftState>(owner, SmallBaseDevKit.AddStateType.AddFirst);
        }

        protected override bool EndState()
        {
            return ownerRigidbody.position.x >= -GlobalGameParams.Instance.horizontalLimit;
        }
    }
}
