using Photon.Pun;
using UnityEngine;
using Runtime._Game.Scripts.Runtime.Infrastructure;
using Runtime._Game.Scripts.Runtime.Gameplay.Football;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Gate
{
    public class GateCollisionChecker : MonoBehaviour
    {
        private const string GoalRpcMethod = "GoalRpc";
        
        [SerializeField] private PhotonView photonView;
        [SerializeField] private PlayerId playerIdComponent;
        [SerializeField] private LayerMask footballLayerMask;
        [SerializeField] private BoxCollider boxCollider;
        
        private readonly Collider[] _cashColliders = new Collider[3];

        private void FixedUpdate()
        {
            CollisionCheck();
        }

        private void CollisionCheck()
        {
            Transform colliderTransform = boxCollider.transform;
            
            int hitDetected = Physics.OverlapBoxNonAlloc(
                boxCollider.bounds.center, 
                colliderTransform.lossyScale*0.5f, 
                _cashColliders, 
                colliderTransform.rotation, 
                footballLayerMask);
            
            if (hitDetected > 0 && playerIdComponent.Id != 0)
            {
                OnFootballDetected();
            }
        }

        private void OnFootballDetected()
        {
            foreach (var cashCollider in _cashColliders)
            {
                if (cashCollider == null)
                    continue;
                
                var footballPlayerId = cashCollider.GetComponent<PlayerId>();
                var footballIndex = cashCollider.GetComponent<FootballBehaviour>().PoolId;
                
                if (playerIdComponent.Id != footballPlayerId.Id)
                {
                    Goal(footballPlayerId.Id, footballIndex, 1);
                }
                else
                {
                    Goal(playerIdComponent.Id, footballIndex, -1);
                }
            }
        }

        private void Goal(int playerId, int footballIndex, int score)
        {
            var playerData = Game.PunService.PlayersDataContainer.PlayersData[playerId];
            playerData.Goal(score);
            
            Game.FootballFactory.ReturnToPool(footballIndex);
            
            photonView.RPC(GoalRpcMethod, RpcTarget.AllViaServer, playerData.Id, playerData.Score, footballIndex);
        }

        [PunRPC]
        private void GoalRpc(int footballPlayerId, int score, int footballIndex)
        {
            Game.FootballFactory.ReturnToPool(footballIndex);
            Game.GoalService.Goal(footballPlayerId, score);
        }
    }
}