using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Runtime._Game.Scripts.Runtime.Extensions;
using Runtime._Game.Scripts.Runtime.Infrastructure;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.PunService;

namespace Runtime._Game.Scripts.Runtime.UI.RoomScreen
{
    public class PlayerRoomPanel : MonoBehaviour
    {
        [SerializeField] private Button colorChangeButton;
        [SerializeField] private Image colorImage;
        [SerializeField] private Button readyButton;
        [SerializeField] private GameObject checkMarkerImage;
        [SerializeField] private TMP_Text playerNameText;

        private PlayerData _playerData;

        private void Start()
        {
            colorChangeButton.onClick.AddListener(ChangeColor);
            readyButton.onClick.AddListener(ToggleReadyStatus);
        }
        
        public void Show(PlayerData playerData)
        {
            _playerData = playerData;
            SetupPanel();

            gameObject.SetActive(true);
        }

        private void SetupPanel()
        {
            playerNameText.text = _playerData.IsLocal? $"{_playerData.Nickname} (you)" : _playerData.Nickname;
            
            colorImage.color = _playerData.ColorId.ToColorById();
            checkMarkerImage.SetActive(_playerData.IsReady);

            colorChangeButton.interactable = _playerData.IsLocal;
            readyButton.interactable = _playerData.IsLocal;
        }

        private void ChangeColor()
        {
            Game.PunService.ChangeColor(_playerData);
        }
        
        private void ToggleReadyStatus()
        {
            Game.PunService.ToggleReadyStatus(_playerData);
        }

        public void Hide()
        {
            _playerData = default;
            gameObject.SetActive(false);
        }
    }
}