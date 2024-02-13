using Runtime._Game.Scripts.Runtime.Gameplay.Factories.FootballFactory;
using Runtime._Game.Scripts.Runtime.Gameplay.Factories.PunGateFactory;
using Runtime._Game.Scripts.Runtime.Gameplay.Factories.PunPlayerFactory;
using Runtime._Game.Scripts.Runtime.Gameplay.Services.GoalService;
using Runtime._Game.Scripts.Runtime.Gameplay.Services.InputService;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base;
using UnityEngine;

namespace Runtime._Game.Scripts.Runtime.Gameplay.States
{
    public class GameplayUnloadingState : InstantState
    {
        public override void Enter(IStackStateMachine stateMachine)
        {
            stateMachine.ReplaceStates(
                new ActionState(() => Cursor.lockState = CursorLockMode.Confined),
                new ActionState(UnregisterServices));
        }

        private void UnregisterServices()
        {
            ServiceLocator.UnregisterService<MortarFactory>();
            ServiceLocator.UnregisterService<GateFactory>();
            ServiceLocator.UnregisterService<FootballFactory>();
            ServiceLocator.UnregisterService<InputServiceBehaviour>();
            ServiceLocator.UnregisterService<GoalService>();
        }
    }
}