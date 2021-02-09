using System.Threading.Tasks;
using UnityEngine;

using SmallBaseDevKit;
using SmallBaseDevKit.GameModule;
using Invaders.GameSettings;
using Invaders.LevelSetting;

namespace Invaders.GameModule
{
    internal sealed class GameResourcesModule : BaseGameModule
    {
        internal LevelData CurrentLevelData
        {
            get
            {
                if(_currentLevelData is null)
                {
                    LoadLevelData();
                }
                return _currentLevelData;
            }
        }

        private MainGameSetting _gameSetting;
        private PlayerShipSetting _playerSetting;

        private LevelData _currentLevelData;

        protected override void CreateModule()
        {
            _gameSetting = Resources.Load<MainGameSetting>("Game Setting");
            _playerSetting = GetShipSettingByType(ShipType.Player) as PlayerShipSetting;
        }

        internal GetSettingType[] GetItemsSettingList<GetSettingType>() where GetSettingType : BaseGameItemSetting
        {
            return _gameSetting.FindAllItemsByType<GetSettingType>();
        }

        internal ShipSetting GetShipSettingByType(ShipType shipType)
        {
            ShipSetting findSetting = _playerSetting;

            var shipSettingList = GetItemsSettingList<ShipSetting>();

            for (int i = 0; i < shipSettingList.Length; ++i)
            {
                if (shipSettingList[i].shipType == shipType)
                {
                    findSetting = shipSettingList[i];
                    break;
                }
            }

            return findSetting;
        }

        internal void ResetCurrentLevelData()
        {
            _currentLevelData = null;
        }

        internal async void LoadLevelData()
        {
            _currentLevelData = GameUtiles.ReadJSON<LevelData>(string.Concat(Application.dataPath,GlobalGameParams.LevelsFolderPath), GameInstance.Instance.GetGameModule<GameInfoModule>().CurrentLevelName);
            while(_currentLevelData is null)
            {
                await Task.Yield();
            }
        }
    }
}
