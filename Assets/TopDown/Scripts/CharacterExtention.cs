using System;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.Unit;
using SmallBaseDevKit.GameException;

using TD.GameModules;

namespace TD.Characters
{
    internal static class CharacterExtention
    {
        internal static void AddData(this IUnit unit)
        {
            GameInstance.Instance.GetGameModule<CharacterDataModule>().AddCharacterData(unit.GetHashCode());
        }

        internal static CharacterData GetData(this IUnit unit)
        {
            CharacterData data = default;

            try
            {
                GameInstance.Instance.GetGameModule<CharacterDataModule>().TryGetCharacterData(unit.GetHashCode(), out data);
                if(data is null)
                {
                    throw new NullReferenceException();
                }
            }
            catch(Exception e)
            {
                ExceptionHandler.ExceptionProcessExecute(e, $"Unit - {unit.GetType().Name} don't have data");
            }

            return data;
        }

        internal static void RemoveData(this IUnit unit)
        {
            GameInstance.Instance.GetGameModule<CharacterDataModule>().RemoveCharacterData(unit.GetHashCode());
        }
    }
}
