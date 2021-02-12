namespace Invaders.GameState.Core
{
    internal sealed class GameUnpauseState : GameRuntimeState
    {
        protected override InteractiveStatus gamePause => InteractiveStatus.Disable;
    }
}
