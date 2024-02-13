using UnityEngine;
using System.Collections;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services;

namespace Runtime._Game.Scripts.Runtime.Infrastructure
{
    public interface ICoroutineService : IService
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}