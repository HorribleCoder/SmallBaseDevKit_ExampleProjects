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
            _timer = SetTime();
        }

        protected override void ExtendedStateComplite()
        {
            
        }

        protected abstract float SetTime();
        protected abstract void TimerAction();
    }
}
