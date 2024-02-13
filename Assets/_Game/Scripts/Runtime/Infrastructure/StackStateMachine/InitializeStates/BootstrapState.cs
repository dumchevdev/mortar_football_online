using Runtime._Game.Scripts.Runtime.Constants;
using Runtime._Game.Scripts.Runtime.Infrastructure.Factories.UI;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.AssetsService;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.PunService;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.SceneLoaderService;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.StaticDataService;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.UIService;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.PunStates;
using Runtime._Game.Scripts.Runtime.UI.Base;
using UnityEngine.SceneManagement;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.InitializeStates
{
    public class BootstrapState : InstantState
    {
        private readonly PunService _punService;
        private readonly ICoroutineService _coroutineService;
        private IAssetService _assetService;
        private StaticDataService _staticDataService;
        private SingUpService _singUpService;
        private IUIService _uiService;
        private ISceneLoadService _sceneLoadService;

        public BootstrapState(PunService punService, ICoroutineService coroutineService)
        {
            _punService = punService;
            _coroutineService = coroutineService;
        }

        public override void Enter(IStackStateMachine stateMachine)
        {
            stateMachine.ReplaceStates(
                new ActionState(RegisterServices),
                new UIInitializeState(),
                new SceneLoadingState(new SceneLoadingInfo(SceneNameConstants.LobbyScene, LoadSceneMode.Single)),
                new ConnectedState(),
                new SignUpState(),
                new UIShowState(UIElementType.MainScreen, null));
        }
        
        private void RegisterServices()
        {
            ServiceLocator.RegisterService(_coroutineService);
            ServiceLocator.RegisterService(_punService);

            _assetService = new AssetService();
            ServiceLocator.RegisterService(_assetService);

            _staticDataService = new StaticDataService();
            _staticDataService.Initialize();
            ServiceLocator.RegisterService(_staticDataService);

            _singUpService = new SingUpService(_punService);
            ServiceLocator.RegisterService(_singUpService);
            
            var uiFactory = new UIFactory(_assetService, _staticDataService);
            _uiService = new UIService(uiFactory);
            ServiceLocator.RegisterService(_uiService);

            _sceneLoadService = new SceneLoadService(_coroutineService);
            ServiceLocator.RegisterService(_sceneLoadService);
        }
    }
}