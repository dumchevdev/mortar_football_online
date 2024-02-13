using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.InitializeStates
{
    public class WaitOnSignUpState : InstantState
    {
        private IStackStateMachine _stateMachine;
        
        public override void Enter(IStackStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            Game.SingUpService.OnSignUp += OnSignUp;
        }

        public override void Exit()
        {
            Game.SingUpService.OnSignUp -= OnSignUp;
        }

        private void OnSignUp(string name)
        {
            _stateMachine.StateCompleted(this);
        }
    }
}