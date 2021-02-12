using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using SmallBaseDevKit;
using SmallBaseDevKit.GameModule;
using SmallBaseDevKit.GameException;

using Invaders.Links;
using Invaders.Events;
using Invaders.GameState.Core;

namespace Invaders.GameModule
{
    internal sealed class GUIModule : BaseGameModule
    {
        private IDictionary<GUIType, GUILink> _guiTable;

        protected override void CreateModule()
        {
            _guiTable = new Dictionary<GUIType, GUILink>();

            var allGuiLink = MonoBehaviour.FindObjectsOfType<GUILink>();

            for(int i = 0; i < allGuiLink.Length; ++i)
            {
                if (!_guiTable.ContainsKey(allGuiLink[i].GUIType))
                {
                    _guiTable.Add(allGuiLink[i].GUIType, allGuiLink[i]);
                }
                else
                {
                    _Debug.Log($"GUI module contains key - {allGuiLink[i].GUIType} check gameobject - {allGuiLink[i].gameObject}", DebugColor.orange);
                }
                allGuiLink[i].gameObject.SetActive(allGuiLink[i].GUIStartGameStatus == InteractiveStatus.Enable);
            }

            Game.AddEventListner<GUIButtonPressedEventArg>(GUIButtonEventCallback);
            Game.AddEventListner<GUISetValueEventArg>(GUISetValueEventCallback);
            Game.AddEventListner<GUIActivePanelEventArg>(GUISetActivePanelEventCallback);
        }
        #region Event Callback

        private void GUIButtonEventCallback(object sender, EventArgs eventArgs)
        {
            var convertArg = eventArgs as GUIButtonPressedEventArg;

            switch (convertArg.buttonType)
            {
                case GUIType.PlayerInputArea:
                    if (GlobalGameParams.Instance.gameOnPause) return;
                    Game.ExecuteEvent<PlayerInputEventArg>();
                    break;
                case GUIType.StartGameButton:
                    Game.AddUnitState<CreateGameFieldState>(GameInstance.Instance.GetGameModule<GameCoreModule>().GameFieldUnit, AddStateType.AddFirst);
                    ChangeGUIElementActiveStatus(GUIType.StartGamePanel, InteractiveStatus.Disable);
                    ChangeGUIElementActiveStatus(GUIType.GameInfoPanel, InteractiveStatus.Enable);
                    break;
                case GUIType.RestartGameButton:
                    Game.AddUnitState<ClearGameFieldState>(GameInstance.Instance.GetGameModule<GameCoreModule>().GameFieldUnit, AddStateType.AddFirst);
                    GameInstance.Instance.GetGameModule<GameCoreModule>().GamePause(InteractiveStatus.Disable);
                    ChangeGUIElementActiveStatus(GUIType.RestartPanel, InteractiveStatus.Disable);
                    break;
                default:
                    break;
            }
        }

        private void GUISetValueEventCallback(object sender, EventArgs eventArgs)
        {
            var converArg = eventArgs as GUISetValueEventArg;
            _guiTable.TryGetValue(converArg.guiType, out var guiElement);
            var gameInfoModule = GameInstance.Instance.GetGameModule<GameInfoModule>();
            switch (converArg.guiType)
            {
                case GUIType.PlayerScore:
                    ChangeValue(guiElement.gameObject, gameInfoModule.LevelScore,"D7");
                    break;
                case GUIType.PlayerLives:
                    ChangeValue(guiElement.gameObject, gameInfoModule.PlayerLives);
                    break;
                default:
                    GUIElementException(converArg.guiType);
                    break;
            }
        }

        private void GUISetActivePanelEventCallback(object sender, EventArgs eventArgs)
        {
            var converArg = eventArgs as GUIActivePanelEventArg;
            ChangeGUIElementActiveStatus(converArg.guiType, converArg.status);
            switch (converArg.guiType)
            {
                case GUIType.StartGamePanel:
                    break;
                case GUIType.RestartPanel:
                    GameInstance.Instance.GetGameModule<GameCoreModule>().GamePause(converArg.status);
                    break;
                default:
                    GUIElementException(converArg.guiType);
                    break;
            }
        }

        private void GUISetActiveScreenEventCallback(object sender, EventArgs eventArgs)
        {

        }
        
        #endregion

        private void ChangeGUIElementActiveStatus(GUIType elementType, InteractiveStatus status)
        {
            if(_guiTable.TryGetValue(elementType, out var elementLink))
            {
                elementLink.gameObject.SetActive(status == InteractiveStatus.Enable);
            }
        }
        
        private void ChangeValue(GameObject guiElement, int value, string valueFormat = "")
        {
            try
            {
                if (guiElement.TryGetComponent<Text>(out var text))
                {
                    text.text = value.ToString(valueFormat);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.ExceptionProcessExecute(e, $"Object - <b>{guiElement.name}</b> not found component - TEXT!");
            }
        }
        private void GUIElementException(GUIType type)
        {
            _Debug.Log($"Default or null Setuped GUI element - {type}.", DebugColor.orange);
        }
    }
}
