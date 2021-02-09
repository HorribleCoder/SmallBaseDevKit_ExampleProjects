using System;

namespace Invaders.LevelSetting
{
    [Serializable]
    internal sealed class EnemyData
    {
        public ShipType enemyType;
        public ActionType actionType;
        public StartMovementType startMovementType;

        public int enemyHealth;

        public float posX;
        public float posY;
        public float movementDistance;


        public float reloadTimer;
        public float startMovementTimer;
        public float shootChance;

        internal EnemyData(Invaders.LevelEditor.EnemyPoint point)
        {
            enemyType = point.shipType;
            actionType = point.actionType;
            startMovementType = point.startMovementType;

            enemyHealth = point.enemyHeath;

            posX = point.pointPosX;
            posY = point.pointPosY;
            movementDistance = point.movementDistance;

            reloadTimer = point.reloadTimer;
            startMovementTimer = point.startMovementTimer;
            shootChance = point.shootChance;
        }
    }
}
