using System;
using UnityEngine;

using Invaders.Units;
using Invaders.Events;
using Invaders.GameModule;

using SmallBaseDevKit;

namespace Invaders
{

    public sealed class GameFieldCreator : MonoBehaviour
    {
        [Header("Main Position")]
        [SerializeField] private RectTransform _playerPoint;
        [SerializeField] private RectTransform[] _enemyPointList;

        private void Awake()
        {
            CreatePlayer();
            CreateEnemy();
        }

        private void Start()
        {
            Game.AddEventListner<RestartEventArg>(RestartPlayerEventCallback);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                GameInstance.Instance.TestDebugStateModule();
                GameInstance.Instance.TestDebugUnitModule();
            }
        }

        private void CreatePlayer()
        {
            var player = Game.CreateUnit<PlayerShip>(GameInstance.Instance.GetGameModule<GameResourcesModule>().GetShipSettingByType(ShipType.Player));
            player.SetPosition(Camera.main.ScreenToWorldPoint(_playerPoint.position));
        }

        private void CreateEnemy()
        {
            EnemyShip enemyShip = default;
            for(int i = 0; i < _enemyPointList.Length; ++i)
            {
                enemyShip = Game.CreateUnit<EnemyShip>(GameInstance.Instance.GetGameModule<GameResourcesModule>().GetShipSettingByType(ShipType.Enemy_Type_1));
                enemyShip.SetPosition(Camera.main.ScreenToWorldPoint(_enemyPointList[i].position));
            }
        }


        private void RestartPlayerEventCallback(object sender, EventArgs eventArgs)
        {
            CreatePlayer();

        }
    }
}

