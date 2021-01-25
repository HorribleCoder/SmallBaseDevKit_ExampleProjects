using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Invaders.GameSettings
{
    [CreateAssetMenu(fileName = "New Enemy Ship Setting", menuName = "Invaders/Settings/Enemy Ship Setting")]
    internal sealed class EnemyShipSetting : ShipSetting
    {
        public readonly int scoreValue;
    }
}
