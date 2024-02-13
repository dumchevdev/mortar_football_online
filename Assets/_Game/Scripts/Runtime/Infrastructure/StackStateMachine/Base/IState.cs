namespace Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base
{
    public interface IState
    {
        public void Enter(IStackStateMachine stateMachine);
        public void Exit();
    }
}