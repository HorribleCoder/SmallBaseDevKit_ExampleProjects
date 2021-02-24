using UnityEngine;

namespace TD.Setting
{
    public sealed class CharacterSetting : ScriptableObject
    {
        public CharacterType characterType = CharacterType.None;
        public GameObject characterPrototype;
    }
}
