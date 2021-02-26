using System;

namespace TD.Events
{
    internal sealed class PlayerInputButtonEventArg : EventArgs
    {
        internal GUIButtonType buttonType = GUIButtonType.None;
    }
}
