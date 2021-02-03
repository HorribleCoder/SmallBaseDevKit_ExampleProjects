using UnityEngine;

namespace Invaders.LevelEditor
{
    [CreateAssetMenu(fileName = "New Enemy Mesh Setting", menuName ="Invaders/Level Editor/EnemyMeshSetting")]
    public sealed class EnemyMeshSetting : ScriptableObject
    {
        public ShipType shipType = ShipType.None;
        public Mesh shipMesh;

        public Vector3 eulerVisual;
    }
}
