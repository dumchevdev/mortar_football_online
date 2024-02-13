using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Runtime._Game.Scripts.Runtime.UI.Base;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.PunService;
using Runtime._Game.Scripts.Runtime.Infrastructure;

namespace Runtime._Game.Scripts.Runtime.UI.RoomScreen
{
    public class RoomScreen : UIElement
    {
        public override UIElementType UIElementType => UIElementType.RoomScreen;

        [SerializeField] private TMP_Text roomNameText;
        [SerializeField] private PlayerRoomPanel[] playerListItems;
        [SerializeField] private Button leaveButton;
        [SerializeField] private Button startButton;
        
        private void Start()
        {
            startButton.onClick.AddListener(OnStartButtonClick);
            leaveButton.onClick.AddListener(OnLeaveButtonClick);
        }

        private void OnEnable()
        {
            Game.PunService.OnPlayerEnteredRoomEvent += UpdateViews;
            Game.PunService.OnPlayerLeftRoomEvent += UpdateViews;
            Game.PunService.OnPlayerColorChanged += UpdateViews;
            Game.PunService.OnPlayerReadyStatusChanged += UpdateViews;
            Game.PunService.OnMasterClientSwitchedEvent += UpdateMasteryClient;
        }
        
        private void OnDisable()
        {
            Game.PunService.OnPlayerEnteredRoomEvent -= UpdateViews;
            Game.PunService.OnPlayerLeftRoomEvent -= UpdateViews;
            Game.PunService.OnPlayerColorChanged -= UpdateViews;
            Game.PunService.OnPlayerReadyStatusChanged -= UpdateViews;
            Game.PunService.OnMasterClientSwitchedEvent -= UpdateMasteryClient;
        }

        protected override void OnShow(object ctx)
        {
            var room = Game.PunService.CurrentRoom;
            roomNameText.text = room.Name;

            UpdateViews();
        }

        private void UpdateViews()
        {
            UpdateOnPlayers();
            UpdateStartButtonState();
            UpdateMasteryClient();
        }

        private void UpdateMasteryClient()
        {
            startButton.gameObject.SetActive(Game.PunService.IsMasterClient);
        }

        private void UpdateStartButtonState()
        {
            foreach (var playersData in Game.PunService.PlayersDataContainer.PlayersData.Values)
            {
                if (!playersData.IsReady)
                {
                    startButton.interactable = false;
                    return;
                }
            }
            
            startButton.interactable = true;
        }

        private void UpdateOnPlayers()
        {
            var players = Game.PunService.PlayersDataContainer.PlayersData.Values;

            int index = 0;
            foreach (PlayerData playerData in players)
            {
                playerListItems[index].Show(playerData);
                index++;
            }
            
            for (int i = players.Count; i < playerListItems.Length; i++)
            {
                playerListItems[i].Hide();
            }
        }
        
        private void OnStartButtonClick()
        {
            Game.PunService.StartGame();
        }

        private void OnLeaveButtonClick()
        {
            Game.PunService.LeaveRoom();
            Game.UIService.Show(UIElementType.MainScreen, null);
        }

        protected override void OnHide()
        {
            foreach (var playerListItem in playerListItems)
            {
                playerListItem.Hide();
            }
        }
    }
}