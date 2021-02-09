namespace Invaders.LevelSetting
{
    internal sealed class LevelData
    {
        public float playerPosX;
        public float playerPosY;

        public EnemyData[] enemyData;

        internal LevelData(int count)
        {
            enemyData = new EnemyData[count];
        }
    }
}
