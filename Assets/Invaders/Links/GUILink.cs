using UnityEngine;

namespace Invaders.Links
{
    public sealed class GUILink : MonoBehaviour
    {
        public GUIType GUIType { get => _guiType; }
        [SerializeField] private GUIType _guiType = GUIType.None;
    }
}
