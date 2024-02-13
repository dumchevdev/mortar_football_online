using System;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base
{
    public class ActionState : InstantState
    {
        public ActionState(Action action)
        {
            _action = action;
        }

        private readonly Action _action;
        
        public override void Enter(IStackStateMachine stateMachine)
        {
            _action?.Invoke();
            stateMachine.StateCompleted(this);
        }
    }
}