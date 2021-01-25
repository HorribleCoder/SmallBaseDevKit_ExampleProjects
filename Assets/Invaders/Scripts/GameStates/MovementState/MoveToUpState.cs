using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using Invaders.GameSettings;

namespace Invaders.GameState
{
    internal sealed class MoveToUpState : MovementState
    {
        protected override Vector3 movementDirecion => Vector3.up;

        protected override float speed => owner.ReadUnitData<ShipSetting>().verticalSpeed;

        protected override bool EndState()
        {
            return ownerRigidbody.position.y >= -GlobalGameParams.Instance.verticalLimit;
        }

        protected override void ExtendedStateComplite()
        {

        }
    }
}
