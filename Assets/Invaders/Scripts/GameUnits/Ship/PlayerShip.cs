using System;
using System.Threading.Tasks;
using UnityEngine;

using SmallBaseDevKit;

using Invaders.Links;
using Invaders.Events;
using Invaders.GameSettings;
using Invaders.GameState;

namespace Invaders.Units
{
    [RequireComponent(typeof(FirePointLink))]
    internal sealed class PlayerShip : BaseGameUnit<PlayerShipSetting>
    {
        protected override void ExtendedSetupUnit(PlayerShipSetting unitData)
        {
            base.ExtendedSetupUnit(unitData);
            LateStartGame();
        }

        protected override void ExtendedDestroyUnit()
        {
            base.ExtendedDestroyUnit();

            SetupInputArea(InteractiveStatus.Disable);
        }

        private void PlayerInputCallback(object sender, EventArgs eventArg)
        {
            var converEventArg = eventArg as PlayerInputEventArg;
            Game.RemoveUnitState<JumpState>(this);

            Game.AddUnitState<JumpState>(this, AddStateType.AddLast);

            FlipDirection();

            Game.AddUnitState<FireSingleShoot>(this, AddStateType.AddLast);
        }

        //метод для балансировки игрока.
        private async void LateStartGame()
        {
            await Task.Delay(1000);
            //добавляем движение в рандомную сторону
            if (UnityEngine.Random.Range(-1f, 1f) > 0)
            {
                Game.AddUnitState<MoveToRightState>(this, AddStateType.AddFirst);
            }
            else
            {
                Game.AddUnitState<MoveToLeftState>(this, AddStateType.AddFirst);
            }
            Game.AddUnitState<GravityState>(this, AddStateType.AddLast);
            Game.AddUnitState<PlayerSelfControlCollisionState>(this, AddStateType.AddLast);
            Game.AddEventListner<PlayerInputEventArg>(PlayerInputCallback);

            SetupInputArea(InteractiveStatus.Enable);
        }

        private void FlipDirection()
        {
            var rb = componentHandler.GetComponent<Rigidbody>();
            if (rb.velocity.x > 0)
            {
                Game.RemoveUnitState<MoveToRightState>(this);
                Game.AddUnitState<MoveToLeftState>(this, AddStateType.AddFirst);
            }
            else
            {
                Game.RemoveUnitState<MoveToLeftState>(this);
                Game.AddUnitState<MoveToRightState>(this, AddStateType.AddFirst);
            }
        }

        private void SetupInputArea(InteractiveStatus status)
        {
            Game.ExecuteEvent<PlayerInputAreaControllerEventArg>(eventArgSetupCallback: SetupEventArg);
            void SetupEventArg(PlayerInputAreaControllerEventArg eventArg)
            {
                eventArg.isActive = status == InteractiveStatus.Enable;
            }

        }
    }
}
