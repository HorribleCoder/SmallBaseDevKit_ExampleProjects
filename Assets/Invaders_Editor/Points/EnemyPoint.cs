using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;



namespace Invaders.LevelEditor
{
    [ExecuteInEditMode]
    public sealed class EnemyPoint : ShipPoint
    {
        private MeshFilter _visualShip;
        private Mesh _defaultMesh;
        [Header("Основные настройки")]
        public EnemyMeshSetting enemyMeshSetting;
        public int enemyHeath = 1;
        [Space]
        
        [Header("Нстройки движения")]
        public StartMovementType startMovementType = StartMovementType.None;
        [Range(0f, 5f)]
        public float startMovementTimer;
        public float movementDistance = Single.PositiveInfinity;
        [Space]

        [Header("Нстройки стрельбы")]
        public ActionType actionType = ActionType.None;
        [Range(1f, 10f)]
        public float reloadTimer = 1f;
        [Range(0f, 1f)]
        public float shootChance;
        
       

        private void Start()
        {
            if(transform.childCount > 0)
            {
                _visualShip = transform.GetChild(0).GetComponent<MeshFilter>();
                _defaultMesh = _visualShip.sharedMesh;
            }
        }

        private void LateUpdate()
        {
            if(enemyMeshSetting is null)
            {
                _visualShip.mesh = _defaultMesh;
                shipType = ShipType.None;
            }
            else
            {
                _visualShip.mesh = enemyMeshSetting.shipMesh;
                _visualShip.transform.rotation = Quaternion.Euler(enemyMeshSetting.eulerVisual);
                shipType = enemyMeshSetting.shipType;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawMesh(_visualShip.sharedMesh, transform.position + Vector3.right * movementDistance, _visualShip.transform.rotation);
            Gizmos.DrawMesh(_visualShip.sharedMesh, transform.position + Vector3.left * movementDistance, _visualShip.transform.rotation);
        }
    }
}
