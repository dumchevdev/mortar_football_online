using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
using Runtime._Game.Scripts.Runtime.Infrastructure;
using Runtime._Game.Scripts.Runtime.UI.Base;

namespace Runtime._Game.Scripts.Runtime.UI.OtherScreens
{
    public class CreateRoomScreen : UIElement
    {
        public override UIElementType UIElementType => UIElementType.CreateRoomScreen;

        [SerializeField] private TMP_InputField roomNameInputField;
        [SerializeField] private Button createButton;
        [SerializeField] private Button backButton;
        
        private void Start()
        {
            createButton.onClick.AddListener(OnCreateButtonClick);
            backButton.onClick.AddListener(ShowMainMenu);
        }

        private void ShowMainMenu()
        {
            Game.UIService.Show(UIElementType.MainScreen, null);
        }

        private void OnCreateButtonClick()
        {
            if (!roomNameInputField.text.IsNullOrEmpty())
            {
                Game.CreateOrJoinRoom(roomNameInputField.text);
            }
        }
    }
}