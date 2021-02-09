using UnityEngine;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.Handler;
using SmallBaseDevKit.USH.State;
using SmallBaseDevKit.USH.Unit;

using Invaders.Units;
using Invaders.LevelSetting;
using Invaders.GameSettings;
using Invaders.GameModule;
using Invaders.GameState.Core;


namespace Invaders.GameHandler.Core
{
    internal sealed class GameFieldHandler : BaseGameHandler
    {
        public override void ExecuteHandlerLogic(IState currentState)
        {
            var c_state = currentState.ConvertTo<BaseGameFieldState>();
            c_state.Deconstruct(out var stateParam);
            switch (stateParam)
            {
                case GameFieldStateType.CreateField:
                    CreateGameField();
                    break;
                case GameFieldStateType.ClearField:
                    ClearGameField();
                    break;
                default:
                    break;
            }
        }

        private void CreateGameField()
        {
            var levelData = GameInstance.Instance.GetGameModule<GameResourcesModule>().CurrentLevelData;
            var resourceModule = GameInstance.Instance.GetGameModule<GameResourcesModule>();
            //player
            var player = Game.CreateUnit<PlayerShip, ShipSetting>(resourceModule.GetShipSettingByType(ShipType.Player));
            player.SetPosition(new Vector3(levelData.playerPosX, levelData.playerPosY));
            for (int i = 0; i < levelData.enemyData.Length; ++i)
            {
                CreateEnemy(levelData.enemyData[i], resourceModule);
            }
        }

        private void ClearGameField()
        {
            Game.ForEachAllUnitInRegistor<Rigidbody>((IUnit unit) =>
            {
                unit.DestroyUnit();
            });
            Game.ResetUnitRegistor();
        }

        private void CreateEnemy(EnemyData enemyData, GameResourcesModule resourcesModule)
        {
            EnemyShip enemy = default;
            switch (enemyData.enemyType)
            {
                case ShipType.Enemy_Type_1:
                    enemy = Game.CreateUnit<EnemyShipType1, ShipSetting>(resourcesModule.GetShipSettingByType(enemyData.enemyType));
                    break;
                case ShipType.Enemy_Type_2:
                    enemy = Game.CreateUnit<EnemyShipType2, ShipSetting>(resourcesModule.GetShipSettingByType(enemyData.enemyType));
                    break;
                default:
                    break;
            }

            enemy.SetPosition(new Vector3(enemyData.posX, enemyData.posY));
        }

        protected override void SetupHandlerOnCreate()
        {

        }
    }
}
