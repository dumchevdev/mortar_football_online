using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
using Runtime._Game.Scripts.Runtime.UI.Base;
using Runtime._Game.Scripts.Runtime.Infrastructure;

namespace Runtime._Game.Scripts.Runtime.UI.OtherScreens
{
    public class SignUpScreen : UIElement
    {
        public override UIElementType UIElementType => UIElementType.SignUpScreen;
        
        [SerializeField] private TMP_InputField userNameInputField;
        [SerializeField] private Button createButton;

        private void Start()
        {
            createButton.onClick.AddListener(SignUp);
        }

        private void SignUp()
        {
            if (!userNameInputField.text.IsNullOrEmpty())
            {
                Game.SingUpService.SignUp(userNameInputField.text);
            }
        }
    }
}