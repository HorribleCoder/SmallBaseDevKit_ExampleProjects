using System;
using System.Collections.Generic;

using SmallBaseDevKit;
using SmallBaseDevKit.GameModule;
using SmallBaseDevKit.USH.Unit;

using Invaders.Events;

namespace Invaders.GameModule
{
    internal sealed class GameInfoModule : BaseGameModule
    {
        private IDictionary<IUnit, int> _enemyLiveTable;
        internal string CurrentLevelName { get => string.Format(GlobalGameParams.LevelNameTitle, _currentLevelNumber); }

        internal int LevelScore { get => _currentLevelScore; }
        internal int PlayerLives { get => _currentPlayerLives; }

        private int _currentLevelNumber;
        private int _currentLevelScore;
        private int _currentPlayerLives;

        protected override void CreateModule()
        {
            _enemyLiveTable = new Dictionary<IUnit, int>();
            RestartGame();
        }

        internal void RestartGame()
        {
            _currentLevelScore = 0;
            _currentPlayerLives = 3;

            _currentLevelNumber = 1;

            _enemyLiveTable.Clear();
        }

        internal void SetLevelNumber(int value)
        {
            _currentLevelNumber = value;
        }

        internal void AddGameScore(int value)
        {
            _currentLevelScore += value;
        }

        internal void PlayerLostLive()
        {
            _currentPlayerLives--;
            Game.ExecuteEvent<GUISetValueEventArg>(eventArgSetupCallback: SetupEventArg);
            void SetupEventArg(GUISetValueEventArg eventArg)
            {
                eventArg.guiType = GUIType.PlayerLives;
            }
        }

        #region Enemy Lives
        internal void AddUnitInLiveTable(IUnit unit, int live)
        {
            if (!_enemyLiveTable.ContainsKey(unit))
            {
                _enemyLiveTable.Add(unit, live);
            }
        }

        internal void TryGetUnitLive(IUnit unit, out int live)
        {
            _enemyLiveTable.TryGetValue(unit, out live);
        }

        internal void SetNewLiveValueInTable(IUnit unit, int value)
        {
            _enemyLiveTable[unit] = value;
        }


        #endregion
    }
}
