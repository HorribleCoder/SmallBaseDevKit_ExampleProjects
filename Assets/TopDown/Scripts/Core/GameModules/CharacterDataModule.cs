using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SmallBaseDevKit.Pool;
using SmallBaseDevKit.GameModule;
using TD.Characters;

namespace TD.GameModules
{
    internal sealed class CharacterDataModule : BaseGameModule
    {
        private IDictionary<int, CharacterData> _characterDataTable;
        private IPool<CharacterData> _characterDataPool;

        protected override void CreateModule()
        {
            _characterDataTable = new Dictionary<int, CharacterData>();
            _characterDataPool = new LinePool<CharacterData>();
        }

        internal void AddCharacterData(int unitHash)
        {
            if (_characterDataTable.ContainsKey(unitHash)) return;
            _characterDataTable.Add(unitHash, _characterDataPool.GetObject(typeof(CharacterData)));
        }

        internal bool TryGetCharacterData(int unitHash, out CharacterData data)
        {
            return _characterDataTable.TryGetValue(unitHash, out data);
        }

        internal void RemoveCharacterData(int unitHash)
        {
            if(_characterDataTable.TryGetValue(unitHash, out var data))
            {
                data.ResetData();
                _characterDataPool.ReturnObject(data);
                _characterDataTable.Remove(unitHash);
            }
        }
    }
}
