using UnityEngine;

namespace Invaders.Links
{
    [AddComponentMenu("Invaders/Links/Fire Point")]
    public sealed class FirePointLink : MonoBehaviour
    {
        public Vector3 Position { get => this.transform.position; }
    }
}
