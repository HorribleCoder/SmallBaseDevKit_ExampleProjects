using SmallBaseDevKit;

using Invaders.Events;

namespace Invaders.GameState
{
    internal sealed class PlayerStartGameState : StartGameState
    {
        protected override void TimerAction()
        {
            if (UnityEngine.Random.Range(-1f, 1f) > 0)
            {
                Game.AddUnitState<MoveToRightState>(owner, AddStateType.AddFirst);
            }
            else
            {
                Game.AddUnitState<MoveToLeftState>(owner, AddStateType.AddFirst);
            }
            Game.AddUnitStateGroup<PlayerInputState, PlayerSelfControlCollisionState, GravityState>(owner, AddStateType.AddLast);

            Game.ExecuteEvent<PlayerInputAreaControllerEventArg>(eventArgSetupCallback: SetupEventArg);
            void SetupEventArg(PlayerInputAreaControllerEventArg eventArg)
            {
                eventArg.isActive = true;
            }
            SetComplite();
        }
    }
}
