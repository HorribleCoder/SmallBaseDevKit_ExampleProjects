using System.Threading.Tasks;

using SmallBaseDevKit;
using SmallBaseDevKit.USH.Handler;
using SmallBaseDevKit.USH.State;

using Invaders.Units;
using Invaders.Events;
using Invaders.GameState;
using Invaders.GameModule;
using Invaders.GameSettings;

namespace Invaders.GameHandler
{
    internal sealed class DestroyHandler : BaseGameHandler
    {
        public override void ExecuteHandlerLogic(IState currentState)
        {
            var convertState = currentState.ConvertTo<DestroyState>();
            convertState.Deconstruct(out var stateParam);

            if(stateParam is EnemyShip)
            {
                stateParam.ReadUnitData<EnemyShipSetting>(out var data);
                GameInstance.Instance.GetGameModule<GameInfoModule>().AddGameScore(data.scoreValue);
                Game.ExecuteEvent<GUISetValueEventArg>(stateParam, SetupAddScore);

                void SetupAddScore(GUISetValueEventArg eventArg)
                {
                    eventArg.guiType = GUIType.PlayerScore;
                }
            }
            if(stateParam is PlayerShip)
            {
                Game.ExecuteEvent<GUIActivePanelEventArg>(eventArgSetupCallback: SetupPanelEventArg);
                void SetupPanelEventArg(GUIActivePanelEventArg eventArg)
                {
                    eventArg.guiType = GUIType.RestartPanel;
                    eventArg.status = InteractiveStatus.Enable;
                }
                Game.ExecuteEvent<PlayerInputAreaControllerEventArg>(eventArgSetupCallback: SetupEventArg);
                void SetupEventArg(PlayerInputAreaControllerEventArg eventArg)
                {
                    eventArg.status = InteractiveStatus.Disable;
                }
            }

            Game.DestroyUnit(stateParam);
        }

        protected override void SetupHandlerOnCreate()
        {

        }
    }
}
