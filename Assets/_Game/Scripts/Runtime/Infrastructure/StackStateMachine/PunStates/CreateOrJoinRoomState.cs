using System.Linq;
using Runtime._Game.Scripts.Runtime.UI.Base;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.PunStates
{
    public class CreateOrJoinRoomState : InstantState
    {
        private readonly string _roomName;
        private IStackStateMachine _stateMachine;
        
        public CreateOrJoinRoomState(string roomName)
        {
            _roomName = roomName;
        }

        public override void Enter(IStackStateMachine stateMachine)
        {
            _stateMachine = stateMachine;

            var room = Game.PunService.Rooms.FirstOrDefault(room => room.Name == _roomName);
            if (room is {RemovedFromList: false})
            {
                Game.PunService.JoinRoom(_roomName);
            }
            else
            {
                Game.PunService.CreateRoom(_roomName);
            }
            
            Game.UIService.Show(UIElementType.LoadingScreen, null);

            SubscribeEvents();
        }

        public override void Exit()
        {
            UnsubscribeEvents();
        }
        
        private void SubscribeEvents()
        {
            Game.PunService.OnJoinedRoomEvent += OnJoinedRoom;
            Game.PunService.OnCreateRoomFailedEvent += OnJoinedRoomFailed;
            Game.PunService.OnJoinRoomFailedEvent += OnJoinedRoomFailed;
        }

        private void UnsubscribeEvents()
        {
            Game.PunService.OnJoinedRoomEvent -= OnJoinedRoom;
            Game.PunService.OnCreateRoomFailedEvent -= OnJoinedRoomFailed;
            Game.PunService.OnJoinRoomFailedEvent -= OnJoinedRoomFailed;
        }

        private void OnJoinedRoom()
        {
            Game.UIService.Show(UIElementType.RoomScreen, null);
            _stateMachine.StateCompleted(this);
        }
        
        private void OnJoinedRoomFailed(string message)
        {
            Game.ShowErrorScreen(message);
            _stateMachine.StateCompleted(this);
        }
    }
}