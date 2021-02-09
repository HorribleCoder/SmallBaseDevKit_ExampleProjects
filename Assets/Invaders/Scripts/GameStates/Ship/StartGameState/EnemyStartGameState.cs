using System;
using UnityEngine;

using SmallBaseDevKit;

using Invaders.GameModule;

namespace Invaders.GameState
{
    internal sealed class EnemyStartGameState : StartGameState
    {
        protected override float SetTimeValue()
        {
            return Time.time + GlobalGameParams.AwaitGameStartTime
                + GameInstance.Instance.GetGameModule<GameResourcesModule>().CurrentLevelData.enemyData[Game.GetUnitIndexInRegistor<Rigidbody>(owner)].startMovementTimer;
        }

        protected override void TimerAction()
        {
            var startMovementType = GameInstance.Instance.GetGameModule<GameResourcesModule>().CurrentLevelData.enemyData[Game.GetUnitIndexInRegistor<Rigidbody>(owner)].startMovementType;
            switch (startMovementType)
            {
                case StartMovementType.MoveToRight:
                    Game.AddUnitState<EnemyMoveToRightState>(owner, AddStateType.AddFirst);
                    break;
                case StartMovementType.MoveToLeft:
                    Game.AddUnitState<EnemyMoveToLeftState>(owner, AddStateType.AddFirst);
                    break;
                default:
                    break;
            }
            Game.AddUnitState<EnemyReloadState>(owner, AddStateType.AddLast);
            SetComplite();
        }
    }
}
