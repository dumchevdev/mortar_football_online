using UnityEngine;
using Runtime._Game.Scripts.Runtime.Gameplay.Factories.FootballFactory;
using Runtime._Game.Scripts.Runtime.Gameplay.Factories.PunGateFactory;
using Runtime._Game.Scripts.Runtime.Gameplay.Factories.PunPlayerFactory;
using Runtime._Game.Scripts.Runtime.Gameplay.Mortar;
using Runtime._Game.Scripts.Runtime.Gameplay.Services.GoalService;
using Runtime._Game.Scripts.Runtime.Gameplay.Services.InputService;
using Runtime._Game.Scripts.Runtime.Infrastructure;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.PunStates;
using Runtime._Game.Scripts.Runtime.UI.Base;

namespace Runtime._Game.Scripts.Runtime.Gameplay.States
{
    public class GameplayInitializeState : InstantState
    {
        private readonly SpawnPointsContainer _spawnPointsContainer;
        private readonly IInputService _inputServiceBehaviour;
        private MortarFactory _mortarFactory;
        private GateFactory _gateFactory;
        private FootballFactory _footballFactory;
        private GoalService _goalService;

        public GameplayInitializeState(IInputService inputService, SpawnPointsContainer spawnPointsContainer)
        {
            _inputServiceBehaviour = inputService;
            _spawnPointsContainer = spawnPointsContainer;
        }

        public override void Enter(IStackStateMachine stateMachine)
        {
            SequenceSsm.CreateAndRun(
                new ActionState(() => Cursor.lockState = CursorLockMode.Locked),
                new ActionState(RegisterServices),
                new ActionState(() => Game.MortarFactory.CreatePlayer()),
                new ActionState(() => Game.GateFactory.CreateGate()),
                new UIShowState(UIElementType.Hud, null),
                new WaitEscapeClicked());
        }
        
        private void RegisterServices()
        {
            _mortarFactory = new MortarFactory(_spawnPointsContainer);
            ServiceLocator.RegisterService(_mortarFactory);
            
            _gateFactory = new GateFactory(_spawnPointsContainer);
            ServiceLocator.RegisterService(_gateFactory);

            var footballPool = new FootballPool();
            footballPool.Initialize();
            
            _footballFactory = new FootballFactory(footballPool);
            ServiceLocator.RegisterService(_footballFactory);

            ServiceLocator.RegisterService(_inputServiceBehaviour);

            _goalService = new GoalService();
            ServiceLocator.RegisterService(_goalService);
        }
    }
}