using System;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.Services.SceneLoaderService
{
    public interface ISceneLoadService : IService
    {
        public void Load(SceneLoadingInfo sceneLoadInfo, Action onCallback = null);
    }
}