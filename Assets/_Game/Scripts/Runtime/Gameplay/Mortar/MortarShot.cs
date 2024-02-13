using Photon.Pun;
using UnityEngine;
using System.Collections;
using Runtime._Game.Scripts.Runtime.Infrastructure;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Mortar
{
    public class MortarShot : MonoBehaviour
    {
        private const string ShotRpcMethod = "ShotRpc";

        [SerializeField] private PhotonView photonView;
        [SerializeField] private Transform footballSpawnPoint;
        [SerializeField] private MortarBallisticTrajectory ballisticTrajectory;

        private bool _isReload;
        
        private void OnEnable()
        {
            Game.InputService.OnMouseButtonHolding += DrawBallisticTrajectory;
            Game.InputService.OnMouseButtonUp += Shot;
        }

        private void OnDisable()
        {
            Game.InputService.OnMouseButtonHolding -= DrawBallisticTrajectory;
            Game.InputService.OnMouseButtonUp -= Shot;
        }

        private void DrawBallisticTrajectory()
        {
            if (_isReload)
                return;
            
            var velocity = footballSpawnPoint.forward * Game.StaticDataService.MortarConfig.CalculateHoldDownForce(Game.InputService.HoldTime);
            ballisticTrajectory.ShowTrajectory(footballSpawnPoint.position, velocity);
        }

        private void Shot()
        {
            if (_isReload)
                return;
            
            ballisticTrajectory.SetActiveLineRenderer(false);
            
            var playerData = Game.PunService.PlayersDataContainer.LocalPlayerData;
            var velocity = footballSpawnPoint.forward * Game.StaticDataService.MortarConfig.CalculateHoldDownForce(Game.InputService.HoldTime);

            StartCoroutine(Reload());
            
            photonView.RPC(ShotRpcMethod, RpcTarget.AllViaServer, playerData.Id, playerData.ColorId, velocity);
        }

        private IEnumerator Reload()
        {
            _isReload = true;

            yield return new WaitForSeconds(0.5f);

            _isReload = false;
        }
        
        [PunRPC]
        private void ShotRpc(int playerId, int colorId, Vector3 impulseVector)
        {
            
            var football = Game.FootballFactory.CreateFootball(playerId, colorId, footballSpawnPoint.position);

            if (football != null)
            {
                var soccerBallRigidBody = football.GetComponent<Rigidbody>();
                soccerBallRigidBody.AddForce(impulseVector, ForceMode.Impulse);
            }
        }
    }
}