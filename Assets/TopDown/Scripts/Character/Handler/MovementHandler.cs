using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

using SmallBaseDevKit.USH.Handler;
using SmallBaseDevKit.USH.State;

using TD.Chacters.State;

namespace TD.Chacters.Handler
{
    internal sealed class MovementHandler : BaseGameHandler
    {
        public override void ExecuteHandlerLogic(IState currentState)
        {
            currentState.ConvertTo<MoveToState>().Deconstruct(out var stateParam);
            if (stateParam.point == Vector3.zero) return;
            stateParam.agent.SetDestination(stateParam.point);
        }

        protected override void SetupHandlerOnCreate()
        {

        }
    }
}
