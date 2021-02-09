using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Invaders.LevelEditor
{
    public class SimpleLevelEditor : MonoBehaviour
    {
        
        public int levelNumber;

        public List<EnemyMeshSetting> enemyMeshSettings;

        [ContextMenu("Create Level Data")]
        private void CreateLevelData()
        {
            var allEnemyPoint = FindObjectsOfType<EnemyPoint>();
            var playerPoint = FindObjectOfType<PlayerPoint>();
            var levelData = new LevelSetting.LevelData(allEnemyPoint.Length);

            levelData.playerPosX = playerPoint.pointPosX;
            levelData.playerPosY = playerPoint.pointPosY;

            for(int i = 0; i < allEnemyPoint.Length; ++i)
            {
                levelData.enemyData[i] = new LevelSetting.EnemyData(allEnemyPoint[i]);
            }

            GameUtiles.WriteJSON<LevelSetting.LevelData>(levelData, string.Concat(Application.dataPath, GlobalGameParams.LevelsFolderPath), string.Format(GlobalGameParams.LevelNameTitle, levelNumber));
            _Debug.Log($"Level - {string.Format(GlobalGameParams.LevelNameTitle, levelNumber)} was created! Check folder - Resources/Levels !", DebugColor.green);
        }

        [ContextMenu("Read Level Data")]
        private void ReadLevelData()
        {

        }

        [ContextMenu("Remove All Enemy")]
        private void RemoveAllEnemyPoint()
        {
            var allEnemyPoint = FindObjectsOfType<EnemyPoint>();
            for(int i = 0; i < allEnemyPoint.Length; ++i)
            {
                Object.DestroyImmediate(allEnemyPoint[i].gameObject);
            }
        }
    }
}

