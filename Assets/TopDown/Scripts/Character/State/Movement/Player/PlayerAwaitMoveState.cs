using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using SmallBaseDevKit;

using TD.GameModules;

namespace TD.Characters.State
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
            Game.AddUnitState<PlayerMoveToState>(owner, AddStateType.AddFirst);
            if(ownerData.movementType == CharacterMovementType.Walk)
            {
                Game.AddUnitState<WalkAnimationState>(owner, AddStateType.AddFirst);
            }
            else
            {
                Game.AddUnitState<RunAnimationState>(owner, AddStateType.AddFirst);
            }
        }
    }
}
