using System;
using UnityEngine;
using SmallBaseDevKit;

namespace Invaders.GameState
{
    internal sealed class EnemyMoveToRightState : EnemyMovementState
    {
        protected override Vector3 movementDirecion => Vector3.right;

        protected override float speed => ownerData.horizontalSpeed;

        protected override bool EndState()
        {
            return ownerRigidbody.position.x >= -GlobalGameParams.Instance.horizontalLimit
            || ownerRigidbody.position.x >= enemyData.posX + enemyData.movementDistance;
        }

        protected override void ExtendedStateComplite()
        {
            Game.AddUnitState<EnemyMoveToLeftState>(owner, AddStateType.AddFirst);
        }
    }
}
