using UnityEngine;

using SmallBaseDevKit;
using Invaders.LevelSetting;
using Invaders.GameModule;


namespace Invaders.GameState
{
    internal sealed class EnemyReloadState : TimerState
    {
        private EnemyData _currentData;
        protected override void ExtendedSetupState()
        {
            _currentData = GameInstance.Instance.GetGameModule<GameResourcesModule>().CurrentLevelData.enemyData[Game.GetUnitIndexInRegistor<Rigidbody>(owner)];
            base.ExtendedSetupState();
        }

        protected override bool EndState()
        {
            return false;
        }

        protected override float SetTimeValue()
        {
            return Time.time + _currentData.reloadTimer;
        }

        protected override void TimerAction()
        {
            if(Random.Range(0f,1f) <= _currentData.shootChance)
            {
                switch (_currentData.actionType)
                {
                    case ActionType.SingleShoot:
                        Game.AddUnitState<SingleShootState>(owner, AddStateType.AddFirst);
                        break;
                    case ActionType.DoubleShoot:
                        Game.AddUnitState<DoubleShootState>(owner, AddStateType.AddFirst);
                        break;
                    case ActionType.TripleShoot:
                        Game.AddUnitState<TripleShootState>(owner, AddStateType.AddFirst);
                        break;
                    default:
                        Game.AddUnitState<SingleShootState>(owner, AddStateType.AddFirst);
                        break;
                }
            }
            ResetTimer();
        }
    }
}
