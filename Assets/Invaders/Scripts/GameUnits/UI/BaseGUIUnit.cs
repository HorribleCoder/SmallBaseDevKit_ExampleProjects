using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

using SmallBaseDevKit.USH.Unit;
using Invaders.GameSettings;

namespace Invaders.UI
{
    internal abstract class BaseGUIUnit<T> : BaseUnit<BaseItemUISetting>
        where T: Graphic
    {
        protected T guiComponent;

        protected override void ExtendedSetupUnit(BaseItemUISetting unitData)
        {
            guiComponent = GetGuiComponentByType(unitData.GuiComponent);
        }
        protected override void ExtendedDestroyUnit()
        {
            
        }

        protected T GetGuiComponentByType(Graphic currentGUIComponent)
        {
            return currentGUIComponent as T;
        }

    }
}
