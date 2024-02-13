using UnityEngine.SceneManagement;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base
{
    public class SceneLoadingInfo
    {
        public SceneLoadingInfo(
            string sceneName, 
            LoadSceneMode loadSceneMode)
        {
            SceneName = sceneName;
            LoadSceneMode = loadSceneMode;
        }

        public string SceneName { get; }
        public LoadSceneMode LoadSceneMode { get; }
    }
}