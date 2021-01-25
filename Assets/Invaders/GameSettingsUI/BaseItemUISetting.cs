using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Invaders.GameSettings
{
    [CreateAssetMenu(fileName ="New GUIItem Setting", menuName = "Invaders/GUI/Item Setting")]
    public class BaseItemUISetting : ScriptableObject
    {
        public Graphic GuiComponent { get => _guiComponent; }
        [SerializeField] private Graphic _guiComponent;
    }
}
