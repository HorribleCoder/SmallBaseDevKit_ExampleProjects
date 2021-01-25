using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Invaders.GameSettings
{
    internal abstract class BaseGameItemSetting : ScriptableObject
    {
        internal GameObject ItemPrefab { get => _itemPrefab; }
        [SerializeField] private GameObject _itemPrefab;
    }
}
