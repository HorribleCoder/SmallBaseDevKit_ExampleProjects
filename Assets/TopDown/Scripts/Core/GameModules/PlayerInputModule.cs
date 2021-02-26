using System;
using UnityEngine;
using SmallBaseDevKit;
using SmallBaseDevKit.GameModule;
using SmallBaseDevKit.USH.Unit;

using TD.Events;
using TD.Characters;
using TD.Characters.State;


namespace TD.GameModules
{
    internal sealed class PlayerInputModule : BaseGameModule
    {
        internal Vector3 PlayerInputDirection { get; private set; }
        internal CharacterMovementType MovementType { get; private set; }

        private IUnit _playerUnit;

        protected override void CreateModule()
        {
            Game.AddEventListner<PlayerInputDirectionEventArg>(SetPlayerInputDirection);
            Game.AddEventListner<PlayerInputButtonEventArg>(PlayerInputButtonCallback);
        }

        internal void SetPlayer(IUnit unit)
        {
            _playerUnit = unit;
        }

        private void SetPlayerInputDirection(object sender, EventArgs eventArgs)
        {
            var cEventArg = eventArgs as PlayerInputDirectionEventArg;
            PlayerInputDirection = new Vector3(cEventArg.posX, 0f, cEventArg.posY);
        }

        private void PlayerInputButtonCallback(object sender, EventArgs eventArgs)
        {
            var cEventArg = eventArgs as PlayerInputButtonEventArg;
            switch (cEventArg.buttonType)
            {
                case GUIButtonType.ChangeMovementType:
                    var data = _playerUnit.GetData();
                    data.movementType = (data.movementType == CharacterMovementType.Walk) ? CharacterMovementType.Run : CharacterMovementType.Walk;
                    if(PlayerInputDirection != Vector3.zero)
                    {
                        if(data.movementType == CharacterMovementType.Walk)
                        {
                            Game.AddUnitState<WalkAnimationState>(_playerUnit, AddStateType.AddFirst);
                        }
                        else
                        {
                            Game.AddUnitState<RunAnimationState>(_playerUnit, AddStateType.AddFirst);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
