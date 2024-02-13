using System.Collections;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base;

namespace Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.PunStates
{
    public class DisconnectedState : InstantState
    {
        private IStackStateMachine _stateMachine;

        public override void Enter(IStackStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            Game.CoroutineService.StartCoroutine(WaitDisconnect());
        }

        private IEnumerator WaitDisconnect()
        {
            Game.PunService.Disconnect();

            while (Game.PunService.IsConnected)
            {
                yield return null;
            }
            
            _stateMachine.StateCompleted(this);
        }
    }
}