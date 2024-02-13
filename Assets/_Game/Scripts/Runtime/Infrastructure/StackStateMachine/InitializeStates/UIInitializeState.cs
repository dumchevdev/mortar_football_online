using Runtime._Game.Scripts.Runtime.UI.Base;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.InitializeStates
{
    public class UIInitializeState : InstantState
    {
        public override void Enter(IStackStateMachine stateMachine)
        {
            Game.UIService.InitUIRoot();
            Game.UIService.Show(UIElementType.LoadingScreen, null);
            
            stateMachine.StateCompleted(this);
        }
    }
}