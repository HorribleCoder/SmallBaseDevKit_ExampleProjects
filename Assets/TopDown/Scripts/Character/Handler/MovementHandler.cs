using UnityEngine;

using SmallBaseDevKit.USH.Handler;
using SmallBaseDevKit.USH.State;

using TD.Characters.State;

namespace TD.Characters.Handler
{
    internal sealed class MovementHandler : BaseGameHandler
    {
        private const float NormalSpeed = 1.5f;

        public override void ExecuteHandlerLogic(IState currentState)
        {
            currentState.ConvertTo<MoveToState>().Deconstruct(out var stateParam);
            if (stateParam.point == Vector3.zero) return;
            float speedMod;
            switch (stateParam.movementType)
            {
                case CharacterMovementType.Run:
                    speedMod = 1.75f;
                    break;
                case CharacterMovementType.Rush:
                    speedMod = 2.5f;
                    break;
                default:
                    speedMod = 1f;
                    break;
            }
            stateParam.agent.speed = NormalSpeed * speedMod;
            stateParam.agent.SetDestination(stateParam.point);
        }

        protected override void SetupHandlerOnCreate()
        {

        }
    }
}
