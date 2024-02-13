using Runtime._Game.Scripts.Runtime.UI.Base;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base
{
    public class UIShowState : InstantState
    {
        private readonly UIElementType _type;
        private readonly object _context;

        public UIShowState(UIElementType type, object context)
        {
            _type = type;
            _context = context;
        }

        public override void Enter(IStackStateMachine stateMachine)
        {
            Game.UIService.Show(_type, _context);
            stateMachine.StateCompleted(this);
        }
    }
}