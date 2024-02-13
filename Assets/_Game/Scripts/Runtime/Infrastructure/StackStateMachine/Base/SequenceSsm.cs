using System.Collections.Generic;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base
{
    public class SequenceSsm : IStackStateMachine
    {
        private bool _isStarted;
        private readonly Stack<IState> _stackStates;

        private IState CurrentState => _stackStates.Count == 0 || !_isStarted ? null : _stackStates.Peek();
        
        private SequenceSsm()
        {
            _stackStates = new Stack<IState>();
        }
        
        public static void CreateAndRun(params IState[] states)
        {
            var sequence = new SequenceSsm();
            sequence.PushStates(states);
            sequence.Start();
        }
        
        void IStackStateMachine.ReplaceStates(params IState[] states)
        {
            var lastState = _stackStates.Pop();
            if (_isStarted)
                lastState.Exit();
            PushStates(states);
        }

        void IStackStateMachine.StateCompleted(IState state)
        {
            if (!StateCheck(state))
            {
                return;
            }

            var lastState = _stackStates.Pop();
            if (_isStarted)
                lastState.Exit();
            
            if (_stackStates.Count == 0)
            {
                Complete();
                return;
            }

            if (_isStarted)
                _stackStates.Peek().Enter(this);
        }
        
        private void Start()
        {
            if (_isStarted)
                return;

            if (_stackStates.Count == 0)
            {
                Complete();
                return;
            }

            _isStarted = true;
            _stackStates.Peek().Enter(this);
        }
        
        private void PushStates(params IState[] steps)
        {
            for (int i = steps.Length - 1; i >= 0; i--)
            {
                _stackStates.Push(steps[i]);
            }

            if (_isStarted)
                _stackStates.Peek().Enter(this);
        }
    
        private bool StateCheck(IState state)
        {
            return state == CurrentState;
        }
        
        private void Complete()
        {
            _stackStates.Clear();
        }
    }
}