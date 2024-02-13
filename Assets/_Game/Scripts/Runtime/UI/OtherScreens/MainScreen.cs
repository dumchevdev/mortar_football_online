using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Runtime._Game.Scripts.Runtime.UI.Base;
using Runtime._Game.Scripts.Runtime.Infrastructure;

namespace Runtime._Game.Scripts.Runtime.UI.OtherScreens
{
    public class MainScreen : UIElement
    {
        public override UIElementType UIElementType => UIElementType.MainScreen;

        [SerializeField] private TMP_Text userNameText;
        [SerializeField] private Button findRoomButton;
        [SerializeField] private Button createRoomButton;
        
        private void Start()
        {
            createRoomButton.onClick.AddListener(ShowCreateRoomScreen);
            findRoomButton.onClick.AddListener(ShowFindRoomScreen);
        }
        
        protected override void OnShow(object ctx)
        {
            userNameText.text = Game.PunService.Nickname;
        }

        private static void ShowFindRoomScreen()
        {
            Game.UIService.Show(UIElementType.FindRoomScreen, Game.PunService.Rooms);
        }

        private static void ShowCreateRoomScreen()
        {
            Game.UIService.Show(UIElementType.CreateRoomScreen, null);
        }
    }
}