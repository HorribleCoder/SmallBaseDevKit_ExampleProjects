using System;

namespace Invaders.Events
{
    internal sealed class GUISetValueEventArg : EventArgs
    {
        internal GUIType guiType;
        internal int value;
    }
}
