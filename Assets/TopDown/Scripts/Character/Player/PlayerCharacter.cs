using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using SmallBaseDevKit;

using TD.Chacters.State;
using TD.Events;

namespace TD.Chacters
{
    internal sealed class PlayerCharacter : BaseCharacter
    {
        protected override void ExtendedSetupUnit()
        {
            base.ExtendedSetupUnit();
            Game.ExecuteEvent<CameraTargetEventArg>(this, (CameraTargetEventArg eventArg) =>
            {
                eventArg.targetTransform = characterVisula.transform;
            });

            Game.AddUnitState<PlayerMoveToState>(this, AddStateType.AddFirst);
        }

        protected override void ExtendedDestroyUnit()
        {

        }
    }
}
