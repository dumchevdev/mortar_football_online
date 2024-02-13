using System;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using Runtime._Game.Scripts.Runtime.Gameplay.States;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.Services.PunService
{
    public class PunService : MonoBehaviourPunCallbacks, IService
    {
        private const string LoadGameplayRpcMethod = "LoadGameplay";
        private const string ChangeColorRpcMethod = "ChangeColorRpc";
        private const string ToggleReadyStatusRpcMethod = "ToggleReadyStatusRpc";
        
        public PlayersDataContainer PlayersDataContainer { get; private set; }
        public List<RoomInfo> Rooms { get; } = new();
        
        public bool IsMasterClient => PhotonNetwork.IsMasterClient;
        public string Nickname => PhotonNetwork.NickName;
        public Room CurrentRoom => PhotonNetwork.CurrentRoom;
        public bool IsConnected => PhotonNetwork.IsConnected;

        public event Action OnJoinedRoomEvent;
        public event Action OnMasterClientSwitchedEvent;
        public event Action OnPlayerEnteredRoomEvent;
        public event Action OnPlayerLeftRoomEvent;
        public event Action<List<RoomInfo>> OnRoomListUpdateEvent;
        public event Action<string> OnCreateRoomFailedEvent;
        public event Action<string> OnJoinRoomFailedEvent;
        public event Action OnPlayerColorChanged;
        public event Action OnPlayerReadyStatusChanged;

        public void Connect()
        {
            PlayersDataContainer = new PlayersDataContainer();
            PhotonNetwork.ConnectUsingSettings();
        }
        
        public void Disconnect()
        {
            PhotonNetwork.Disconnect();
        }
        
        public void SetUserInfo(string nickname)
        {
            PhotonNetwork.NickName = nickname;
        }

        public void JoinRoom(string roomName)
        {
            PhotonNetwork.JoinRoom(roomName);
        }
        
        public void CreateRoom(string roomName)
        {
            var roomOptions = new RoomOptions
            {
                MaxPlayers = 4
            };

            PhotonNetwork.CreateRoom(roomName, roomOptions);
        }
        
        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public void StartGame()
        {
            PhotonNetwork.CurrentRoom.IsVisible = false;
            photonView.RPC(LoadGameplayRpcMethod, RpcTarget.AllBuffered);
        }
        
        public void ChangeColor(PlayerData playerData)
        {
            photonView.RPC(ChangeColorRpcMethod, RpcTarget.AllBuffered, playerData.Id, playerData.NextColorId());
        }
        
        public void ToggleReadyStatus(PlayerData playerData)
        {
            photonView.RPC(ToggleReadyStatusRpcMethod, RpcTarget.AllBuffered, playerData.Id, !playerData.IsReady);
        }
        
        public override void OnConnectedToMaster()
        {
            PhotonNetwork.JoinLobby();
        }
        
        public override void OnJoinedRoom()
        {
            PlayersDataContainer.AddPlayers(PhotonNetwork.PlayerList);
            OnJoinedRoomEvent?.Invoke();
        }

        public override void OnMasterClientSwitched(Player newMasterClient)
        {
            OnMasterClientSwitchedEvent?.Invoke();
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            UpdateRoomList(roomList);
            OnRoomListUpdateEvent?.Invoke(roomList);
        }
        
        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            OnCreateRoomFailedEvent?.Invoke(message);
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            OnJoinRoomFailedEvent?.Invoke(message);
        }

        public override void OnPlayerLeftRoom(Player player)
        {
            PlayersDataContainer.RemovePlayer(player);
            OnPlayerLeftRoomEvent?.Invoke();
        }

        public override void OnLeftRoom()
        {
            PlayersDataContainer.Clear();
        }

        public override void OnPlayerEnteredRoom(Player player)
        {
            PlayersDataContainer.AddPlayers(player);
            OnPlayerEnteredRoomEvent?.Invoke();
        }
        
        private void UpdateRoomList(List<RoomInfo> roomList)
        {
            Rooms.Clear();
            Rooms.AddRange(roomList);
        }

        [PunRPC]
        private void LoadGameplay()
        {
            SequenceSsm.CreateAndRun(new GameplayLoadingState());
        }
        
        [PunRPC]
        private void ChangeColorRpc(int playerId, int colorId)
        {
            var playerData = PlayersDataContainer.PlayersData[playerId];
            playerData.ColorId = colorId;
            OnPlayerColorChanged?.Invoke();
        }
        
        [PunRPC]
        private void ToggleReadyStatusRpc(int playerId, bool isReady)
        {
            var playerData = PlayersDataContainer.PlayersData[playerId];
            playerData.IsReady = isReady;
            OnPlayerReadyStatusChanged?.Invoke();
        }
    }
}