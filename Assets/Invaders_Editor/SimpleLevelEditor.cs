using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Invaders.LevelEditor
{
    public class SimpleLevelEditor : MonoBehaviour
    {
        private const string LevelsFolderPath = "/Resources/Levels/";
        public int levelNumber;

        public List<EnemyMeshSetting> enemyMeshSettings;

        [ContextMenu("Create Level Data")]
        private void CreateLevelData()
        {
            var allEnemyPoint = FindObjectsOfType<EnemyPoint>();
            var playerPoint = FindObjectOfType<PlayerPoint>();
            var levelData = new LevelData.LevelData(allEnemyPoint.Length);

            levelData.playerPosX = playerPoint.pointPosX;
            levelData.playerPosY = playerPoint.pointPosY;

            for(int i = 0; i < allEnemyPoint.Length; ++i)
            {
                levelData.enemyData[i] = new LevelData.EnemyData(allEnemyPoint[i]);
            }

            GameUtiles.WriteJSON<LevelData.LevelData>(levelData, string.Concat(Application.dataPath, LevelsFolderPath), string.Format(GlobalGameParams.LevelNameTitle, levelNumber));
            _Debug.Log($"Level - {string.Format(GlobalGameParams.LevelNameTitle, levelNumber)} was created! Check folder - Resources/Levels !", DebugColor.green);
        }
    }
}

