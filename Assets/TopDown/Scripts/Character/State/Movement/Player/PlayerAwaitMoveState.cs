using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using SmallBaseDevKit;

using TD.GameModules;

namespace TD.Chacters.State
{
    internal sealed class PlayerAwaitMoveState : MoveToState
    {
        protected override bool EndState()
        {
            return GameInstance.Instance.GetGameModule<PlayerInputModule>().PlayerInputDirection != Vector3.zero;
        }

        protected override Vector3 GetMovementPoint()
        {
            return Vector3.zero;
        }

        protected override void ExtendedSetupState()
        {
            Game.AddUnitState<StopAnimationState>(owner, AddStateType.AddFirst);
            base.ExtendedSetupState();
        }

        protected override void ExtendedStateComplite()
        {
            base.ExtendedStateComplite();
            Game.AddUnitStateGroup<PlayerMoveToState, RunAnimationState>(owner, AddStateType.AddFirst);
        }
    }
}
