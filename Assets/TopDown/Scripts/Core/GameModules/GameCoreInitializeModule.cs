using UnityEngine;

using SmallBaseDevKit;
using SmallBaseDevKit.GameModule;

using TD.Level;

namespace TD.GameModules
{
    internal sealed class GameCoreInitializeModule : BaseGameModule
    {
        internal LevelCreator LevelCreator { get => _levelCreator; }
        private LevelCreator _levelCreator;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void ExtendedGameInitialize()
        {
            var self = GameInstance.Instance.GetGameModule<GameCoreInitializeModule>();
        }

        protected override void CreateModule()
        {
            _levelCreator = Game.CreateUnit<LevelCreator>();
            Game.AddUnitState<CreateGameFieldState>(_levelCreator, AddStateType.AddFirst); 
        }
    }
}
