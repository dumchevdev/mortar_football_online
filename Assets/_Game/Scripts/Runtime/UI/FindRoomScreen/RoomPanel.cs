using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Runtime._Game.Scripts.Runtime.Infrastructure;

namespace Runtime._Game.Scripts.Runtime.UI.FindRoomScreen
{
    public class RoomPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text roomNameText;
        [SerializeField] private Button joinRoomButton;

        private string _roomName;
        
        private void Start()
        {
            joinRoomButton.onClick.AddListener(OnClick);
        }

        public void Show(string roomName)
        {
            _roomName = roomName;
            roomNameText.text = roomName;
            
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        private void OnClick()
        {
            Game.CreateOrJoinRoom(_roomName);
        }
    }
}