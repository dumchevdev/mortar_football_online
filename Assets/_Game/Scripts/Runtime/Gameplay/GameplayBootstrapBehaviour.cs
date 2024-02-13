using UnityEngine;
using Runtime._Game.Scripts.Runtime.Gameplay.Mortar;
using Runtime._Game.Scripts.Runtime.Gameplay.Services.InputService;
using Runtime._Game.Scripts.Runtime.Gameplay.States;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base;

namespace Runtime._Game.Scripts.Runtime.Gameplay
{
    public class GameplayBootstrapBehaviour : MonoBehaviour
    {
        [SerializeField] private InputServiceBehaviour inputService;
        [SerializeField] private SpawnPointsContainer spawnPointsContainer;

        private void Awake()
        {
            SequenceSsm.CreateAndRun(new GameplayInitializeState(inputService, spawnPointsContainer));
        }
    }
}
