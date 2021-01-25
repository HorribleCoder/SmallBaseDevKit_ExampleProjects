using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using Invaders.GameSettings;

namespace Invaders.GameState
{
    internal sealed class MoveToLeftState : MovementState
    {
        protected override Vector3 movementDirecion => Vector3.left;

        protected override float speed => owner.ReadUnitData<ShipSetting>().horizontalSpeed;

        protected override void ExtendedStateComplite()
        {
            SmallBaseDevKit.Game.AddUnitState<MoveToRightState>(owner, SmallBaseDevKit.AddStateType.AddFirst);
        }

        protected override bool EndState()
        {
            return ownerRigidbody.position.x <= GlobalGameParams.Instance.horizontalLimit;
        }
    }
}
