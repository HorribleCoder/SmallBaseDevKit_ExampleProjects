using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.Handler;
using SmallBaseDevKit.USH.State;
using SmallBaseDevKit.USH.Unit;

using Invaders.GameState.Core;
using Invaders.GameModule;

namespace Invaders.GameHandler.Core
{
    internal sealed class TestPlayerInputHandler : BaseGameHandler
    {
        public override void ExecuteHandlerLogic(IState currentState)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                var convertState = currentState.ConvertTo<TestModePlayerInputState>();
                convertState.Deconstruct(out var stateParam);
                Game.AddUnitState<ClearGameFieldState>(GameInstance.Instance.GetGameModule<GameCoreModule>().GameFieldUnit, AddStateType.AddFirst);
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                Game.ForEachAllUnitInRegistor<Rigidbody>((IUnit unit) =>
                {
                    var b_unit = (BaseUnit)unit;
                    b_unit.DebugViewUnit();
                });
            }
        }

        protected override void SetupHandlerOnCreate()
        {

        }
    }
}
