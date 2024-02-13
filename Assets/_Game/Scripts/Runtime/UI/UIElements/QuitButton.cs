using UnityEngine;
using UnityEngine.UI;

namespace Runtime._Game.Scripts.Runtime.UI.UIElements
{
    [RequireComponent(typeof(Button))]
    public class QuitButton : MonoBehaviour
    {
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}