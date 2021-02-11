using System;

namespace Invaders.Events
{
    internal sealed class GUIActivePanelEventArg : EventArgs
    {
        internal GUIType guiType = GUIType.None;
        internal InteractiveStatus status = InteractiveStatus.Enable;
    }
}
