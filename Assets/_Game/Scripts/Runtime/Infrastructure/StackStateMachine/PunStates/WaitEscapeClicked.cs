using UnityEngine.SceneManagement;
using Runtime._Game.Scripts.Runtime.UI.Base;
using Runtime._Game.Scripts.Runtime.Constants;
using Runtime._Game.Scripts.Runtime.Gameplay.States;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.PunStates
{
    public class WaitEscapeClicked : InstantState
    {
        private IStackStateMachine _stateMachine;
        
        public override void Enter(IStackStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            Game.InputService.OnEsc += BackMainMenu;
        }

        public override void Exit()
        {
            Game.InputService.OnEsc -= BackMainMenu;
        }

        private void BackMainMenu()
        {
            _stateMachine.ReplaceStates(
                new UIShowState(UIElementType.LoadingScreen, null),
                new GameplayUnloadingState(),
                new DisconnectedState(),
                new SceneLoadingState(new SceneLoadingInfo(SceneNameConstants.LobbyScene, LoadSceneMode.Single)),
                new ConnectedState(),
                new UIShowState(UIElementType.MainScreen, null));
        }
    }
}