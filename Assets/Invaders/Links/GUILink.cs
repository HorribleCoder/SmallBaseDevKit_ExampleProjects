using UnityEngine;

namespace Invaders.Links
{
    public sealed class GUILink : MonoBehaviour
    {
        public GUIType GUIType { get => _guiType; }
        public InteractiveStatus GUIStartGameStatus { get => _guiStartGameStatus; }
        [SerializeField] private GUIType _guiType = GUIType.None;
        [SerializeField] private InteractiveStatus _guiStartGameStatus = InteractiveStatus.Disable;
    }
}
