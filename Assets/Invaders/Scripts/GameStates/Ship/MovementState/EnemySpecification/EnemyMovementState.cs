using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using SmallBaseDevKit;

using Invaders.LevelSetting;
using Invaders.GameModule;

namespace Invaders.GameState
{
    internal abstract class EnemyMovementState : MovementState
    {
        protected EnemyData enemyData;

        protected override void ExtendedSetupState()
        {
            base.ExtendedSetupState();
            enemyData = GameInstance.Instance.GetGameModule<GameResourcesModule>().CurrentLevelData.enemyData[Game.GetUnitIndexInRegistor<Rigidbody>(owner)];
        }
    }
}
