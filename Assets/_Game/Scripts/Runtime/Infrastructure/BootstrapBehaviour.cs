using UnityEngine;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services.PunService;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.InitializeStates;

namespace Runtime._Game.Scripts.Runtime.Infrastructure
{
    public class BootstrapBehaviour : MonoBehaviour, ICoroutineService
    {
        [SerializeField] private PunService punService;
        
        private void Awake()
        {
            SequenceSsm.CreateAndRun(new BootstrapState(punService, this));
        }
    }
}