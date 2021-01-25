using UnityEngine;

using SmallBaseDevKit.USH.State;
using Invaders.Units;
using Invaders.GameHandler;
using Invaders.Links;

namespace Invaders.GameState
{
    [RequiredHandler(typeof(ActionHandler))]
    internal abstract class ActionState : BaseUnitState<(Vector3 positon, ActionType actionType, ShipType ownerType)>
    {
        protected abstract ActionType actiontype { get; }

        public override void Deconstruct(out (Vector3 positon, ActionType actionType, ShipType ownerType) stateParam)
        {
            stateParam.actionType = this.actiontype;
            stateParam.ownerType = (owner is PlayerShip) ? ShipType.Player : ShipType.None;
            stateParam.positon = Vector3.zero;
            if (owner.TryGetUnitComponent<FirePointLink>(out var firepoint))
            {
                stateParam.positon = firepoint.Position;
            }
            else
            {
                owner.TryGetUnitComponent<Rigidbody>(out var rb);
                stateParam.positon = rb.position;
            }
        }

        protected override void ExtendedSetupState()
        {

        }

        protected override void ExtendedStateComplite()
        {

        }

        protected override bool EndState()
        {
            return true;
        }
    }
}
