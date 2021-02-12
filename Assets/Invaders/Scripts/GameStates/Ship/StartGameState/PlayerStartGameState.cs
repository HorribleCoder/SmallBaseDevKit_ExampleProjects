using UnityEngine;
using SmallBaseDevKit;

using Invaders.Events;

namespace Invaders.GameState
{
    internal sealed class PlayerStartGameState : StartGameState
    {
        protected override float SetTimeValue()
        {
            return Time.time + GlobalGameParams.AwaitGameStartTime;
        }

        protected override void TimerAction()
        {
            if (Random.Range(-1f, 1f) > 0)
            {
                Game.AddUnitState<PlayerMoveToRightState>(owner, AddStateType.AddFirst);
            }
            else
            {
                Game.AddUnitState<PlayerMoveToLeftState>(owner, AddStateType.AddFirst);
            }
            Game.AddUnitStateGroup<PlayerInputState, PlayerSelfControlCollisionState, GravityState>(owner, AddStateType.AddLast);

            Game.ExecuteEvent<PlayerInputAreaControllerEventArg>(eventArgSetupCallback: SetupEventArg);
            void SetupEventArg(PlayerInputAreaControllerEventArg eventArg)
            {
                eventArg.status = InteractiveStatus.Enable;
            }
            SetComplite();
        }
    }
}
