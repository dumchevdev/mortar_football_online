using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Runtime._Game.Scripts.Runtime.UI.Base;
using Runtime._Game.Scripts.Runtime.Infrastructure;

namespace Runtime._Game.Scripts.Runtime.UI.OtherScreens
{
    public class ErrorScreen : UIElement
    {
        public override UIElementType UIElementType => UIElementType.ErrorScreen;

        [SerializeField] private TMP_Text errorNameText;
        [SerializeField] private Button leaveButton;

        private void Start()
        {
            leaveButton.onClick.AddListener(ShowMainMenu);
        }

        protected override void OnShow(object ctx)
        {
            errorNameText.text = (string) ctx;
        }
        
        private void ShowMainMenu()
        {
            Game.UIService.Show(UIElementType.MainScreen, null);
        }
    }
}