using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

using Invaders.Events;

using SmallBaseDevKit;

namespace Invaders.UI
{
    internal sealed class PlayerInputArea : MonoBehaviour, IPointerDownHandler
    {
        private bool _isInteract;

        private void Start()
        {
            Game.AddEventListner<PlayerInputAreaControllerEventArg>(ControlEventCallback);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_isInteract) return;
            Game.ExecuteEvent<PlayerInputEventArg>(this);
        }

        private void ControlEventCallback(object sender, EventArgs eventArgs)
        {
            var convertArg = eventArgs as PlayerInputAreaControllerEventArg;
            _isInteract = convertArg.isActive;
        }
    }
}
