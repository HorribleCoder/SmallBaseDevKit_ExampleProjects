using System;
using System.Threading.Tasks;
using UnityEngine;

using SmallBaseDevKit;
using SmallBaseDevKit.GameModule;

using Invaders.Units.Core;
using Invaders.GameState.Core;

namespace Invaders.GameModule
{
    internal sealed class GameCoreModule : BaseGameModule
    {
        internal GameFieldUnit GameFieldUnit
        {
            get
            {
                if(_gameFieldUnit is null)
                {
                    _gameFieldUnit = Game.CreateUnit<GameFieldUnit>();
                }
                return _gameFieldUnit;
            }
        }
        private GameFieldUnit _gameFieldUnit;
        protected override void CreateModule()
        {
            //Game.AddUnitState<CreateGameFieldState>(this.GameFieldUnit, AddStateType.AddFirst);
            //this is test
            Game.AddUnitStateGroup<CreateGameFieldState, TestModePlayerInputState>(this.GameFieldUnit, AddStateType.AddFirst);
        }
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void GameInitialize()
        {
            var self = GameInstance.Instance.GetGameModule<GameCoreModule>();
            GameInstance.Instance.GetGameModule<GUIModule>();
        }

    }
}
