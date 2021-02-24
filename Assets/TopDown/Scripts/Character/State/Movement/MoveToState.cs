using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

using SmallBaseDevKit;
using SmallBaseDevKit.GameException;
using SmallBaseDevKit.USH.State;

using TD.Chacters.Handler;

namespace TD.Chacters.State
{
    [RequiredHandler(typeof(MovementHandler))]
    internal abstract class MoveToState : BaseUnitState<(NavMeshAgent agent, Vector3 point)>
    {
        internal NavMeshAgent Agent { get => _agent; }
        private NavMeshAgent _agent;
        public override void Deconstruct(out (NavMeshAgent agent, Vector3 point) stateParam)
        {
            stateParam.agent = _agent;
            stateParam.point = GetMovementPoint();
        }

        protected override void ExtendedSetupState()
        {
            try
            {
                owner.TryGetUnitComponent(out _agent);
                if(_agent is null)
                {
                    throw new NullReferenceException();
                }
            }
            catch(Exception e)
            {
                ExceptionHandler.ExceptionProcessExecute(e, "Null reference to NavMeshAgent");
            }
            
        }

        protected override void ExtendedStateComplite()
        {

        }

        protected abstract Vector3 GetMovementPoint();
    }
}
