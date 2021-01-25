using UnityEngine;

using SmallBaseDevKit.Pool;
using SmallBaseDevKit.GameModule;

namespace Invaders.GameModule
{
    internal sealed class VisualModule : BaseGameModule
    {
        private IPool<GameObject> _visualPool;
        protected override void CreateModule()
        {
            _visualPool = new TablePool<GameObject>();
        }

        internal GameObject GetCharacterVisual(GameObject visualPrefab)
        {
            var resultGO = _visualPool.GetObject(visualPrefab);
            resultGO.SetActive(true);
            return resultGO;
        }

        internal void ReturnCharacterVisual(GameObject characterVisual)
        {
            characterVisual.SetActive(false);
            _visualPool.ReturnObject(characterVisual);
        }
    }
}
