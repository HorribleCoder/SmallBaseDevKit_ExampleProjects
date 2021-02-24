using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using SmallBaseDevKit;
using SmallBaseDevKit.GameModule;

using TD.Events;


namespace TD.GameModules
{
    internal sealed class PlayerInputModule : BaseGameModule
    {
        internal Vector3 PlayerInputDirection { get; private set; }

        protected override void CreateModule()
        {
            Game.AddEventListner<PlayerInputDirectionEventArg>(SetPlayerInputDirection);
        }

        private void SetPlayerInputDirection(object sender, EventArgs eventArgs)
        {
            var cEventArg = eventArgs as PlayerInputDirectionEventArg;
            PlayerInputDirection = new Vector3(cEventArg.posX, 0f, cEventArg.posY);
        }
    }
}
