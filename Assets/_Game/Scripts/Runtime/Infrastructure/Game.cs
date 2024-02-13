using Runtime._Game.Scripts.Runtime.Gameplay.Factories.FootballFactory;
using Runtime._Game.Scripts.Runtime.Gameplay.Factories.PunGateFactory;
using Runtime._Game.Scripts.Runtime.Gameplay.Factories.PunPlayerFactory;
using Runtime._Game.Scripts.Runtime.Gameplay.Services.GoalService;
using Runtime._Game.Scripts.Runtime.Gameplay.Services.InputService;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.AssetsService;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.PunService;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.SceneLoaderService;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.StaticDataService;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.UIService;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.PunStates;
using Runtime._Game.Scripts.Runtime.UI.Base;

namespace Runtime._Game.Scripts.Runtime.Infrastructure
{
    public static class Game
    {
        public static PunService PunService => ServiceLocator.Get<PunService>();
        public static IUIService UIService => ServiceLocator.Get<IUIService>();
        public static GoalService GoalService => ServiceLocator.Get<GoalService>();
        public static SingUpService SingUpService => ServiceLocator.Get<SingUpService>();
        public static IInputService InputService => ServiceLocator.Get<IInputService>();
        public static ICoroutineService CoroutineService => ServiceLocator.Get<ICoroutineService>();
        public static ISceneLoadService SceneLoadService => ServiceLocator.Get<ISceneLoadService>();
        public static StaticDataService StaticDataService => ServiceLocator.Get<StaticDataService>();
        public static IAssetService AssetService => ServiceLocator.Get<IAssetService>();
        public static FootballFactory FootballFactory => ServiceLocator.Get<FootballFactory>();
        public static MortarFactory MortarFactory => ServiceLocator.Get<MortarFactory>();
        public static GateFactory GateFactory => ServiceLocator.Get<GateFactory>();
        
        public static void CreateOrJoinRoom(string roomName) =>
            SequenceSsm.CreateAndRun(new CreateOrJoinRoomState(roomName));
        
        public static void ShowErrorScreen(string message)
        {
            var screen = UIService.Get(UIElementType.ErrorScreen);
            if (screen == null)
                UIService.Show(UIElementType.ErrorScreen, message);
        }
    }
}