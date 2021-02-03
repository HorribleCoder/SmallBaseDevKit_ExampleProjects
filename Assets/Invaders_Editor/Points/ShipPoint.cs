using UnityEngine;

namespace Invaders.LevelEditor
{
    public abstract class ShipPoint : MonoBehaviour
    {
        public float pointPosX { get => this.transform.position.x; }
        public float pointPosY { get => this.transform.position.y; }

        public ShipType shipType = ShipType.None;
    }
}
