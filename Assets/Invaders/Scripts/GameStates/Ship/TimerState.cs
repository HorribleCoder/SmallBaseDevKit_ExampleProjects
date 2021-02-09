using System;

using SmallBaseDevKit.USH.State;
using Invaders.GameHandler;

namespace Invaders.GameState
{
    [RequiredHandler(typeof(GameTimerHandler))]
    internal abstract class TimerState : BaseUnitState<(float timer, Action TimerAction)>
    {
        private float _timer;

        public override void Deconstruct(out (float timer, Action TimerAction) stateParam)
        {
            stateParam.timer = _timer;
            stateParam.TimerAction = TimerAction;
        }

        protected override void ExtendedSetupState()
        {
            ResetTimer();
        }

        protected override void ExtendedStateComplite()
        {
            
        }

        protected abstract float SetTimeValue();
        protected abstract void TimerAction();

        protected void ResetTimer()
        {
            _timer = SetTimeValue();
        }
    }
}
