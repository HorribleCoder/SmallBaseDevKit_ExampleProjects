using System;

namespace Invaders.Events
{
    internal sealed class AddScoreEventArg : EventArgs
    {
        internal int scoreValue;

        internal AddScoreEventArg(int scoreValue)
        {
            this.scoreValue = scoreValue;
        }
    }
}
