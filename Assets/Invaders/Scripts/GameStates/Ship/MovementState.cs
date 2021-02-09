using System;

using UnityEngine;

using SmallBaseDevKit.USH.State;
using SmallBaseDevKit.GameException;
using Invaders.Units;
using Invaders.GameSettings;
using Invaders.GameHandler;

namespace Invaders.GameState
{
    [RequiredHandler(typeof(MovementHandler))]
    internal abstract class MovementState : BaseUnitState<(Rigidbody rigidbody, Vector3 velocity)>
    {
        protected Rigidbody ownerRigidbody;
        protected ShipSetting ownerData;
        protected abstract Vector3 movementDirecion { get; }
        protected abstract float speed { get; }

        protected override void ExtendedSetupState()
        {
            try
            {
                owner.TryGetUnitComponent(out ownerRigidbody);
                if(ownerRigidbody is null)
                {
                    throw new Exception();
                }
                owner.ReadUnitData(out ownerData);
            }
            catch (Exception e)
            {
                ExceptionHandler.ExceptionProcessExecute(e, $"Character - {owner.GetType().Name} in state - {GetType().Name} don't have component - Rigidbody!");
            }
        }

        public override void Deconstruct(out (Rigidbody rigidbody, Vector3 velocity) stateParam)
        {
            stateParam.rigidbody = ownerRigidbody;
            stateParam.velocity = movementDirecion * speed;
        }
    }
}
