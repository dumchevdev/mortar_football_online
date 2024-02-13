using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using System.Collections.Generic;
using Runtime._Game.Scripts.Runtime.Infrastructure;
using Runtime._Game.Scripts.Runtime.UI.Base;

namespace Runtime._Game.Scripts.Runtime.UI.FindRoomScreen
{
    public class FindRoomScreen : UIElement
    {
        public override UIElementType UIElementType => UIElementType.FindRoomScreen;

        [SerializeField] private Button backButton;
        [SerializeField] private RoomPanel[] roomListItems;

        private void Start()
        {
            backButton.onClick.AddListener(ShowMainMenu);
        }

        private void OnEnable()
        {
            Game.PunService.OnRoomListUpdateEvent += UpdateRooms;
        }
        
        private void OnDisable()
        {
            Game.PunService.OnRoomListUpdateEvent -= UpdateRooms;
        }

        protected override void OnShow(object ctx)
        {
            UpdateRooms(Game.PunService.Rooms);
        }

        private void UpdateRooms(List<RoomInfo> rooms)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i < roomListItems.Length)
                {
                    if (CanShowRoomPanel(rooms[i]))
                    {
                        roomListItems[i].Show(rooms[i].Name);
                    }
                    else
                    {
                        roomListItems[i].Hide();
                    }
                }
            }
            
            for (int i = rooms.Count; i < roomListItems.Length; i++)
            {
                roomListItems[i].Hide();
            }
        }

        private bool CanShowRoomPanel(RoomInfo roomInfo)
        {
            if (!roomInfo.IsVisible)
                return false;

            if (!roomInfo.IsOpen)
                return false;

            if (roomInfo.RemovedFromList)
                return false;
            
            return true;
        }
        
        private void ShowMainMenu()
        {
            Game.UIService.Show(UIElementType.MainScreen, null);
        }

        protected override void OnHide()
        {
            foreach (var roomListItem in roomListItems)
            {
                roomListItem.Hide();
            }
        }
    }
}