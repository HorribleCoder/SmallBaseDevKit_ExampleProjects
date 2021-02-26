using System;
using System.Collections.Generic;
using UnityEngine;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.Handler;
using SmallBaseDevKit.USH.State;

using TD.GameModules;
using TD.Links;
using TD.Characters;
using TD.Setting;

namespace TD.Level
{
    internal sealed class GameFieldHandler : BaseGameHandler
    {
        public override void ExecuteHandlerLogic(IState currentState)
        {
            if(currentState is CreateGameFieldState)
            {
                CreateGameField();
            }
            else
            {
                ClearGameField();
            }
        }

        protected override void SetupHandlerOnCreate()
        {

        }

        private void CreateGameField()
        {
            List<SpawnPointLink> allSpawnPoint = new List<SpawnPointLink>();
            allSpawnPoint.AddRange(MonoBehaviour.FindObjectsOfType<SpawnPointLink>());
            var playerPoint = allSpawnPoint.Find(x => x.spawnCharacterType == CharacterType.Player);
            allSpawnPoint.Remove(playerPoint);
            //player
            var player = Game.CreateUnit<PlayerCharacter, CharacterSetting>(GameInstance.Instance.GetGameModule<ResourscesModule>().GetCharacterSettingByType(CharacterType.Player));
            player.SetPosition(playerPoint.GetRandomPositonInPointArea());
            player.AddData();
            GameInstance.Instance.GetGameModule<PlayerInputModule>().SetPlayer(player);
        }

        private void ClearGameField()
        {
            
        }
    }
}
