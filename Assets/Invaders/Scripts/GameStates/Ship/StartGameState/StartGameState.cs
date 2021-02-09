using UnityEngine;


namespace Invaders.GameState
{
    internal abstract class StartGameState : TimerState
    {
        private bool _isComplite;
        protected override bool EndState()
        {
            return _isComplite;
        }

        protected override float SetTime()
        {
            _isComplite = false;
            return Time.time + GlobalGameParams.AwaitGameStartTime;
        }

        protected void SetComplite()
        {
            _isComplite = true;
        }
    }
}

