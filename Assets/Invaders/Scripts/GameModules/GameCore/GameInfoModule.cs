using SmallBaseDevKit.GameModule;

namespace Invaders.GameModule
{
    internal sealed class GameInfoModule : BaseGameModule
    {
        internal string CurrentLevelName { get => string.Format(GlobalGameParams.LevelNameTitle, _currentLevelNumber); }

        internal int LevelScore { get => _currentLevelScore; }
        internal int PlayerLives { get => _currentPlayerLives; }

        private int _currentLevelNumber;
        private int _currentLevelScore;
        private int _currentPlayerLives;

        protected override void CreateModule()
        {
            RestartGame();
        }

        internal void RestartGame()
        {
            _currentLevelScore = 0;
            _currentPlayerLives = 3;

            _currentLevelNumber = 1;
        }

        internal void SetLevelNumber(int value)
        {
            _currentLevelNumber = value;
        }

        internal void AddGameScore(int value)
        {
            _currentLevelScore += value;
        }
    }
}
