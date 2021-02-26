using UnityEngine;
using SmallBaseDevKit;

using TD.GameModules;

namespace TD.Characters.State
{
    internal sealed class PlayerMoveToState : MoveToState
    {
        private const float MovementOffset = 1f;

        protected override bool EndState()
        {
            return GameInstance.Instance.GetGameModule<PlayerInputModule>().PlayerInputDirection == Vector3.zero;
        }

        protected override Vector3 GetMovementPoint()
        {
            return Agent.transform.position + GameInstance.Instance.GetGameModule<PlayerInputModule>().PlayerInputDirection.normalized * MovementOffset;
        }

        protected override void ExtendedStateComplite()
        {
            base.ExtendedStateComplite();
            Game.AddUnitState<PlayerAwaitMoveState>(owner, AddStateType.AddFirst);
        }
    }
}
