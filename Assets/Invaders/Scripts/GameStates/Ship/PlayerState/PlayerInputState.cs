using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.State;
using SmallBaseDevKit.USH.Unit;

using Invaders.Events;
using Invaders.GameHandler;


namespace Invaders.GameState
{
    [RequiredHandler(typeof(PlayerInputHandler))]
    internal sealed class PlayerInputState : BaseUnitState<(IUnit unit, Vector3 currentDirection)>
    {
        private Rigidbody _ownerRigidbody;

        public override void Deconstruct(out (IUnit unit, Vector3 currentDirection) stateParam)
        {
            stateParam.unit = owner;
            stateParam.currentDirection = _ownerRigidbody.velocity;
        }

        protected override bool EndState()
        {
            return false;
        }

        protected override void ExtendedSetupState()
        {
            owner.TryGetUnitComponent(out _ownerRigidbody);
        }

        protected override void ExtendedStateComplite()
        {

        }
       
    }
}
