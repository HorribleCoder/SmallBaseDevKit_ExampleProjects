using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TD.Links
{
    public sealed class SpawnPointLink : MonoBehaviour
    {
        public CharacterType spawnCharacterType = CharacterType.None;
        [Range(0f, 5f)]
        public float rangeSpawn;

        public Vector3 GetRandomPositonInPointArea()
        {
            return transform.position + (Vector3)Random.insideUnitCircle * rangeSpawn;
        }
    }
}
