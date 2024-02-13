namespace Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base
{
    public interface IStackStateMachine
    {
        public void ReplaceStates(params IState[] states);
        public void StateCompleted(IState state);
    }
}