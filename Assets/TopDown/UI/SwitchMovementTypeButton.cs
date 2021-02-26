using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using SmallBaseDevKit;

using TD.Events;

namespace TD.UI
{
    internal sealed class SwitchMovementTypeButton : LazyButton
    {
        protected override GUIButtonType guiButtonType => GUIButtonType.ChangeMovementType;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnInput();
            }
        }
    }
}
