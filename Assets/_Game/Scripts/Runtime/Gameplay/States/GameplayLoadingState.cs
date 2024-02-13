using Photon.Pun;
using Runtime._Game.Scripts.Runtime.UI.Base;
using Runtime._Game.Scripts.Runtime.Constants;
using Runtime._Game.Scripts.Runtime.Infrastructure.StackStateMachine.Base;

namespace Runtime._Game.Scripts.Runtime.Gameplay.States
{
    public class GameplayLoadingState : InstantState
    {
        public override void Enter(IStackStateMachine stateMachine)
        {
            stateMachine.ReplaceStates(
                new UIShowState(UIElementType.LoadingScreen, null),
                new ActionState(() => PhotonNetwork.AutomaticallySyncScene = true),
                new ActionState(() => PhotonNetwork.LoadLevel(SceneNameConstants.GameplayScene)));
        }
    }
}