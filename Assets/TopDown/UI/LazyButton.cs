using UnityEngine;
using UnityEngine.UI;

using SmallBaseDevKit;

using TD.Events;

namespace TD.UI
{
    //временно 
    [RequireComponent(typeof(Button))]
    internal abstract class LazyButton : MonoBehaviour
    {
        protected abstract GUIButtonType guiButtonType { get; }
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => OnInput());
        }

        protected void OnInput()
        {
            Game.ExecuteEvent(eventArgSetupCallback: (PlayerInputButtonEventArg eventArg) =>
             {
                 eventArg.buttonType = guiButtonType;
             });
        }
    }
}
