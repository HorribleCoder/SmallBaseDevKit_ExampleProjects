using UnityEngine;
using UnityEngine.UI;

namespace TD.UI
{
    //временно 
    [RequireComponent(typeof(Button))]
    internal abstract class LazyButton : MonoBehaviour
    {
        private void Awake()
        {
            SetupButton(GetComponent<Button>());
        }

        protected abstract void SetupButton(Button button);
    }
}
