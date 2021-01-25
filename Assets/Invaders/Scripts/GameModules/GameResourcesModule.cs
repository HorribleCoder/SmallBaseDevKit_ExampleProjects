using UnityEngine;

using SmallBaseDevKit.GameModule;
using Invaders.GameSettings;

namespace Invaders.GameModule
{
    internal sealed class GameResourcesModule : BaseGameModule
    {
        private MainGameSetting _gameSetting;
        private PlayerShipSetting _playerSetting;

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
    }
}
