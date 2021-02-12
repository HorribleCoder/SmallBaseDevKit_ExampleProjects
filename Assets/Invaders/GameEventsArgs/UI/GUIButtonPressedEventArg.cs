using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invaders.Events
{
    internal sealed class GUIButtonPressedEventArg : EventArgs
    {
        internal GUIType buttonType = GUIType.None;
    }
}
