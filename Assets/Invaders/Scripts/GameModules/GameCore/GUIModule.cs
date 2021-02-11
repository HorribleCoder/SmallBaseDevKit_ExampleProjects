using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using SmallBaseDevKit;
using SmallBaseDevKit.GameModule;
using SmallBaseDevKit.GameException;

using Invaders.Links;
using Invaders.Events;
using Invaders.GameModule;

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
                _guiTable.Add(allGuiLink[i].GUIType, allGuiLink[i]);
            }

            Game.AddEventListner<GUISetValueEventArg>(GUISetValueEventCallback);
        }
        #region Event Callback
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
            _guiTable.TryGetValue(converArg.guiType, out var guiPanel);
            switch (converArg.guiType)
            {
                case GUIType.StartGamePanel:
                    break;
                case GUIType.RestartPanel:
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
