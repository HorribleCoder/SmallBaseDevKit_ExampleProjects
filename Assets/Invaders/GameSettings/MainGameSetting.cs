using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using SmallBaseDevKit.GameException;

namespace Invaders.GameSettings
{
    [CreateAssetMenu(fileName = "New Game Setting", menuName = "Invaders/Settings/Game Setting")]
    internal sealed class MainGameSetting : ScriptableObject
    {
        [SerializeField] private List<BaseGameItemSetting> _itemsSettingList;

        internal T[] FindAllItemsByType<T>() where T : BaseGameItemSetting
        {
           
            var list = _itemsSettingList.FindAll(x => x.GetType() == typeof(T) || x.GetType().IsSubclassOf(typeof(T)));
            try
            {
                if(list.Count == 0)
                {
                    throw new Exception();
                }
                var itemList = new T[list.Count];
                for(int i = 0; i < list.Count; ++i)
                {
                    itemList[i] = list[i] as T;
                }
                return itemList;
            }
            catch(Exception e)
            {
                ExceptionHandler.ExceptionProcessExecute(e, $"{typeof(T).Name} don't have in item list, exception in main game settings - {GetType().Name}");
                return default;
            }
        }
    }
}
