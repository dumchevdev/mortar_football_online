using Photon.Pun;
using UnityEngine;
using Runtime._Game.Scripts.Runtime.Constants;
using Runtime._Game.Scripts.Runtime.Gameplay.Gate;
using Runtime._Game.Scripts.Runtime.Gameplay.Mortar;
using Runtime._Game.Scripts.Runtime.Infrastructure;
using Runtime._Game.Scripts.Runtime.Infrastructure.Services;

namespace Runtime._Game.Scripts.Runtime.Gameplay.Factories.PunGateFactory
{
    public class GateFactory : IService
    {
        private readonly SpawnPointsContainer _spawnPointsContainer;

        public GateFactory(SpawnPointsContainer spawnPointsContainer)
        {
            _spawnPointsContainer = spawnPointsContainer;
        }
        
        public void CreateGate()
        {
            var playerData = Game.PunService.PlayersDataContainer.LocalPlayerData;
            var spawnTransform = _spawnPointsContainer.GetGateSpawnPoint(playerData.Id - 1);
            
            var gate = PhotonNetwork.Instantiate(PathConstants.GatePath, Vector3.zero, Quaternion.identity);
            gate.GetComponent<GateBehaviour>().SetupGateToPlayer(playerData.Id, playerData.ColorId, spawnTransform);
        }
    }
}