using System;

namespace Invaders.Events
{
    internal sealed class PlayerInputAreaControllerEventArg : EventArgs
    {
        internal InteractiveStatus status = InteractiveStatus.Disable;
    }
}
