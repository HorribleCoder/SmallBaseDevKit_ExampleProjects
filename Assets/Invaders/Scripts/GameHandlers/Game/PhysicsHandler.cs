using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using Invaders.GameState;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.Handler;
using SmallBaseDevKit.USH.State;

namespace Invaders.GameHandler
{
    internal sealed class PhysicsHandler : BaseGameHandler
    {
        public override void ExecuteHandlerLogic(IState currentState)
        {
            var convertState = currentState.ConvertTo<PhysicCollisionState>();
            convertState.Deconstruct(out var stateParam);
            if(currentState is PlayerSelfControlCollisionState)
            {
               
                if(Physics.SphereCast(stateParam.ray.origin, stateParam.distance, Vector3.one, out var hit))
                {
                    Game.AddUnitState<DestroyState>(Game.GetUnitInRegistor(hit.rigidbody), AddStateType.AddLast);
                    Game.AddUnitState<DestroyState>(Game.GetUnitInRegistor(stateParam.selfRB), AddStateType.AddLast);
                }
            }
            else
            {
                if (Physics.Raycast(stateParam.ray, out var hit, stateParam.distance))
                {
                    Game.AddUnitState<DestroyState>(Game.GetUnitInRegistor(hit.rigidbody), AddStateType.AddLast);
                }
            }
            
        }

        protected override void SetupHandlerOnCreate()
        {

        }
    }
}
