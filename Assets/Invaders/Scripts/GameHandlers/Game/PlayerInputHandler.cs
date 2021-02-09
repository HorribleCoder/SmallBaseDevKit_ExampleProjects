using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.Unit;
using SmallBaseDevKit.USH.Handler;
using SmallBaseDevKit.USH.State;

using Invaders.GameState;
using Invaders.Events;

namespace Invaders.GameHandler
{
    internal sealed class PlayerInputHandler : BaseGameHandler
    {
        private bool _isTap;
        public override void ExecuteHandlerLogic(IState currentState)
        {
            if (_isTap)
            {
                var convertState = currentState.ConvertTo<PlayerInputState>();
                convertState.Deconstruct(out var stateParam);
                ExecutePlayerInputLogic(stateParam.unit, stateParam.currentDirection);
                _isTap = false;
            }
        }

        protected override void SetupHandlerOnCreate()
        {
            Game.AddEventListner<PlayerInputEventArg>(PlayerInputEventCallback);
        }

        private void PlayerInputEventCallback(object sender, EventArgs eventArg)
        {
            _isTap = true;
        }
       
        private void ExecutePlayerInputLogic(IUnit unit, Vector3 direction)
        {
            Game.RemoveUnitState<JumpState>(unit);
            if (direction.x > 0)
            {
                Game.RemoveUnitState<PlayerMoveToRightState>(unit);
                Game.AddUnitState<PlayerMoveToLeftState>(unit, AddStateType.AddFirst);
            }
            else
            {
                Game.RemoveUnitState<PlayerMoveToLeftState>(unit);
                Game.AddUnitState<PlayerMoveToRightState>(unit, AddStateType.AddFirst);
            }
            Game.AddUnitStateGroup<SingleShootState, JumpState>(unit, AddStateType.AddLast);
        }
    }
}
