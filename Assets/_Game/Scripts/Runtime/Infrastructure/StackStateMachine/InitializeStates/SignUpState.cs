using Runtime._Game.Scripts.Runtime.UI.Base;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.InitializeStates
{
    public class SignUpState : InstantState
    {
        public override void Enter(IStackStateMachine stateMachine)
        {
            stateMachine.ReplaceStates(
                new UIShowState(UIElementType.SignUpScreen, null),
                new WaitOnSignUpState());
        }
    }
}