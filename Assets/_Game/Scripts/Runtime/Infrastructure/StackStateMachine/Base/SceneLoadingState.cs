using System;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base
{
    public class SceneLoadingState : InstantState
    {
        private readonly SceneLoadingInfo _sceneLoadingInfo;
        private readonly Action _onSceneLoaded;

        public SceneLoadingState(
            SceneLoadingInfo sceneLoadingInfo,
            Action onSceneLoaded = null)
        {
            _sceneLoadingInfo = sceneLoadingInfo;
            _onSceneLoaded = onSceneLoaded;
        }

        public override void Enter(IStackStateMachine stateMachine)
        {
            Game.SceneLoadService.Load(_sceneLoadingInfo, () =>
                {
                    _onSceneLoaded?.Invoke();
                    stateMachine.StateCompleted(this);
                });
        }
    }
}