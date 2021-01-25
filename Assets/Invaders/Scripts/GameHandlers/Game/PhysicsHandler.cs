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
            var convertState = ConvertStateToType<PhysicCollisionState>(currentState);
            convertState.Deconstruct(out var stateParam);
            if(currentState is PlayerSelfControlCollisionState)
            {
               
                if(Physics.SphereCast(stateParam.ray.origin, stateParam.distance, Vector3.one, out var hit))
                {
                    _Debug.Log($"Self collision - {hit.rigidbody.name}");
                    Game.AddUnitState<DestroyState>(Game.GetUnitInRegistor(hit.rigidbody), AddStateType.AddLast);
                    Game.AddUnitState<DestroyState>(Game.GetUnitInRegistor(stateParam.selfRB), AddStateType.AddLast);
                }
            }
            else
            {
                if (Physics.Raycast(stateParam.ray, out var hit, stateParam.distance))
                {
                    _Debug.Log($"handler callback - {hit.rigidbody.name}");
                    Game.AddUnitState<DestroyState>(Game.GetUnitInRegistor(hit.rigidbody), AddStateType.AddLast);
                }
            }
            
        }
    }
}
