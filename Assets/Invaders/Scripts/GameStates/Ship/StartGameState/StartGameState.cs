using UnityEngine;


namespace Invaders.GameState
{
    internal abstract class StartGameState : TimerState
    {
        private bool _isComplite;

        protected override void ExtendedSetupState()
        {
            base.ExtendedSetupState();
            _isComplite = false;
        }
        protected override bool EndState()
        {
            return _isComplite;
        }

        protected void SetComplite()
        {
            _isComplite = true;
        }
    }
}

