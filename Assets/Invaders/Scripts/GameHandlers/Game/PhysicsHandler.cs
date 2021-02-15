using UnityEngine;

using Invaders.GameState;
using Invaders.Units;

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
                    Game.AddUnitState<UnitHitState>(Game.GetUnitInRegistor(stateParam.selfRB), AddStateType.AddLast);
                }
            }
            else
            {
                if (Physics.Raycast(stateParam.ray, out var hit, stateParam.distance))
                {
                    var hitUnit = Game.GetUnitInRegistor(hit.rigidbody);
                    if((stateParam.ownerType == ShipType.Player && hitUnit is EnemyShip) || (stateParam.ownerType != ShipType.Player && hitUnit is PlayerShip))
                    {
                        Game.AddUnitState<UnitHitState>(hitUnit, AddStateType.AddFirst);
                        Game.AddUnitState<DestroyState>(Game.GetUnitInRegistor(stateParam.selfRB), AddStateType.AddFirst);
                    }
                }
            }
            
        }

        protected override void SetupHandlerOnCreate()
        {

        }
    }
}
