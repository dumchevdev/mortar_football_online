using System;
using System.Collections;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.Services.SceneLoaderService
{
    public class SceneLoadService : ISceneLoadService
    {
        private readonly ICoroutineService _coroutineService;

        public SceneLoadService(ICoroutineService coroutineService)
        {
            _coroutineService = coroutineService;
        }

        void ISceneLoadService.Load(SceneLoadingInfo sceneLoadingInfo, Action onCallback)
        {
            _coroutineService.StartCoroutine(LoadScene(sceneLoadingInfo, onCallback));
        }

        private IEnumerator LoadScene(SceneLoadingInfo sceneLoadingInfo, Action onCallback)
        {
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneLoadingInfo.SceneName, sceneLoadingInfo.LoadSceneMode);

            while (!waitNextScene.isDone)
            {
                yield return null;
            }
            
            onCallback?.Invoke();
        }
    }
}