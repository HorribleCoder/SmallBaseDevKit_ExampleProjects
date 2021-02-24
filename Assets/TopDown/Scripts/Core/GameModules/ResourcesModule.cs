using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using SmallBaseDevKit;
using SmallBaseDevKit.GameModule;

using TD.Setting;

namespace TD.GameModules
{
    internal sealed class ResourscesModule : BaseGameModule
    {
        private IDictionary<CharacterType, CharacterSetting> _characterSettingsInGame;
        protected override void CreateModule()
        {
            _characterSettingsInGame = new Dictionary<CharacterType, CharacterSetting>();
        }

        internal CharacterSetting GetCharacterSettingByType(CharacterType characterType)
        {
            if(!_characterSettingsInGame.TryGetValue(characterType, out var foundCharacterSetting))
            {
                var resourcesSetting = Resources.Load<GameResourcesSetting>("Main Game Resources");
                foundCharacterSetting = resourcesSetting.GetChracterSettingByCharacterType(characterType);
                _characterSettingsInGame.Add(characterType, foundCharacterSetting);
            }
            return foundCharacterSetting;
        }
    }
}
