using UnityEngine;

using SmallBaseDevKit;

using TD.Links;

namespace TD.GameUtility
{
    ///Только для работы в редакторе
    internal sealed class SceneSpawnPointViewHandler : MonoSingleton<SceneSpawnPointViewHandler>
    {
        private void OnDrawGizmos()
        {
            var pointList = FindObjectsOfType<SpawnPointLink>();
            float pointRadius = 0.35f;
            for(int i = 0; i < pointList.Length; ++i)
            {
                Gizmos.color = (pointList[i].spawnCharacterType == CharacterType.Player) ? Color.green : Color.red;
                Gizmos.DrawSphere(pointList[i].transform.position, pointRadius);
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(pointList[i].transform.position, pointList[i].rangeSpawn);
            }
        }
    }
}
