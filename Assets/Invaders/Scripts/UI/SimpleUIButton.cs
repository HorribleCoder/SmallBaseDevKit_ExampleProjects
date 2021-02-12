using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using SmallBaseDevKit;
using Invaders.Events;

namespace Invaders.UI
{
    [RequireComponent(typeof(Image))]
    internal sealed class SimpleUIButton : MonoBehaviour, IPointerDownHandler
    {
        public GUIType buttonType = GUIType.None;
        private Image _buttonImage;

        private void Awake()
        {
            _buttonImage = GetComponent<Image>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Game.ExecuteEvent<GUIButtonPressedEventArg>(this.gameObject, SetupEventArg);
            void SetupEventArg(GUIButtonPressedEventArg eventArg)
            {
                eventArg.buttonType = this.buttonType;
            }
        }

        public void SetActiveButton(InteractiveStatus status)
        {
            _buttonImage.raycastTarget = status == InteractiveStatus.Enable;
        }
    }
}
