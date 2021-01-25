using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using SmallBaseDevKit;
using Invaders.GameSettings;

namespace Invaders.GameState
{
    internal sealed class ProjectileMovement : MovementState
    {
        protected override Vector3 movementDirecion => ownerRigidbody.transform.up;

        protected override float speed => owner.ReadUnitData<ProjectileSetting>().verticalSpeed;

        protected override bool EndState()
        {
            return ownerRigidbody.position.y >= -GlobalGameParams.Instance.verticalLimit || ownerRigidbody.position.y <= GlobalGameParams.Instance.verticalLimit;
        }

        protected override void ExtendedStateComplite()
        {
            ownerRigidbody.velocity = Vector3.zero;
            Game.AddUnitState<DestroyState>(owner, AddStateType.AddLast);
        }
    }
}
