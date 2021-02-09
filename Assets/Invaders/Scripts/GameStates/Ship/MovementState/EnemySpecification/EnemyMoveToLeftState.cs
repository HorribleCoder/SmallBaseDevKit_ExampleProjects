using System;
using UnityEngine;
using SmallBaseDevKit;

namespace Invaders.GameState
{
    internal sealed class EnemyMoveToLeftState : EnemyMovementState
    {
        protected override Vector3 movementDirecion => Vector3.left;

        protected override float speed => ownerData.horizontalSpeed;

        protected override bool EndState()
        {
           return ownerRigidbody.position.x <= GlobalGameParams.Instance.horizontalLimit
           || ownerRigidbody.position.x <= enemyData.posX - enemyData.movementDistance;
        }

        protected override void ExtendedStateComplite()
        {
            Game.AddUnitState<EnemyMoveToRightState>(owner, AddStateType.AddFirst);
        }
    }
}
