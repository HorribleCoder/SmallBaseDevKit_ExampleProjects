using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using SmallBaseDevKit.GameException;


namespace TD.Setting
{
    [CreateAssetMenu(fileName = "Main Game Resources", menuName = "TD/Setting/Main Game Resources")]
    internal sealed class GameResourcesSetting : ScriptableObject
    {
        [SerializeField] private CharacterSetting[] _characterSettings;


        internal CharacterSetting GetChracterSettingByCharacterType(CharacterType characterType)
        {
            CharacterSetting findSetting = default;

            try
            {
                for(int i = 0; i < _characterSettings.Length; ++i)
                {
                    if(_characterSettings[i].characterType == characterType)
                    {
                        findSetting = _characterSettings[i];
                        break;
                    }
                }
                if(findSetting == default)
                {
                    throw new Exception();
                }
            }
            catch(Exception e)
            {
                ExceptionHandler.ExceptionProcessExecute(e, $"Not found character setting by type - {characterType.ToString()}");
            }

            return findSetting;
        }
    }
}
