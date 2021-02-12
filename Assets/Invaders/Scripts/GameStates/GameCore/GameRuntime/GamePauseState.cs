namespace Invaders.GameState.Core
{
    internal sealed class GamePauseState : GameRuntimeState
    {
        protected override InteractiveStatus gamePause => InteractiveStatus.Enable;
    }
}
